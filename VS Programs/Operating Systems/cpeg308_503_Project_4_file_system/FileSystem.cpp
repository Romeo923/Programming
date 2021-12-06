#include "FileSystem.h"
#include <vector>
#include <stdio.h>
#include <sys/stat.h>
#include <time.h>
#include <sys/types.h>
#include <stdexcept>

FileSystem::FileSystem()
{
	super_block.Super.Blocks = 0;
	
	inode_blocks = NULL;
	inode_blocks_dirty = NULL;
	m_disk = new Disk();

	try {
		open_status = m_disk->open("disk_image");
		if (open_status)
		{
			m_disk->read(0, super_block.Data);
			m_disk->set_Blocks(super_block.Super.Blocks);
		}
	}
	catch (std::runtime_error& e) {
		fprintf(stderr, "Unable to open disk %s\n", e.what());
		open_status=false;
	}
}

FileSystem::~FileSystem()
{
	int total_inode_blocks = super_block.Super.InodeBlocks;
	bool update_bitmaps = false;
	if (inode_blocks_dirty != NULL)
	{
		//save all dirty inodes
		for (int i = 0; i < total_inode_blocks; i++)
		{
			if (inode_blocks_dirty[i])
			{
				m_disk->write(super_block.Super.Meta1_Block_start+i, inode_blocks[i].Data);
				update_bitmaps = true;
			}
		}
		if (update_bitmaps) {
			m_disk->write(META1_BITMAP, Meta1_BITMAP.Data);
			m_disk->write(META2_BITMAP, Meta2_BITMAP.Data);
			m_disk->write(DATA_BITMAP, Data_BITMAP.Data);
		}
		delete inode_blocks_dirty;
	}

	if (inode_blocks != NULL)
		delete inode_blocks;
}

bool FileSystem::isDiskMounted()
{
	return((m_disk != NULL) && (m_disk->mounted()));
}

bool FileSystem::isValidInode(uint32_t inode)
{
    return isDiskMounted() && inode>=0 && inode < (super_block.Super.InodeBlocks * INODES_PER_BLOCK);
}

void* FileSystem::getINode(uint32_t inode_number){
	if (isValidInode(inode_number)) {
		uint32_t block_number = inode_number / INODES_PER_BLOCK;
		uint32_t inode_offset = inode_number % INODES_PER_BLOCK;
		return getINode(block_number, inode_offset);
	}
	return NULL;
}

void* FileSystem::getINode(uint32_t block_number, uint32_t inode_offset) {
	if(block_number>=0 && block_number<super_block.Super.InodeBlocks && inode_offset<INODES_PER_BLOCK)
		return &inode_blocks[block_number].Inodes[inode_offset];
	return NULL;
}

void FileSystem::debug() {
	Block block;
	Inode_Meta2*pInode = NULL;

	// Read Superblock
	m_disk->read(0, block.Data);

	printf("SuperBlock:\n");
	printf("    %u blocks\n", block.Super.Blocks);
	printf("    %u inode blocks\n", block.Super.InodeBlocks);
	printf("    %u inodes\n", block.Super.Inodes);
}

// Format file system ----------------------------------------------------------
bool FileSystem::format(size_t size)
{
	try {
		open_status = m_disk->open("disk_image", size);
	}
	catch (std::runtime_error& e) {
		fprintf(stderr, "Unable to open disk %s\n", e.what());
		open_status = false;
	}
	if(open_status)
		open_status=format();
	return open_status;
}

bool FileSystem::format() {
	if (m_disk->mounted())
	{
		printf("Unount the disk first.\n");
		return false;
	}

	memset(&super_block, 0, Disk::BLOCK_SIZE);
	memset(&Meta1_BITMAP, ALL_FREE, Disk::BLOCK_SIZE);
	memset(&Meta2_BITMAP, ALL_FREE, Disk::BLOCK_SIZE);
	memset(&Data_BITMAP, ALL_FREE, Disk::BLOCK_SIZE);
       
        //TODO IN CLASS 

	// initialize superblock
	super_block.Super.MagicNumber = MAGIC_NUMBER;	   // File system magic number
	super_block.Super.Blocks = m_disk->get_Blocks();   // Number of blocks in file system
	int temp = (int)(super_block.Super.Blocks * 0.1);
	super_block.Super.InodeBlocks = temp;	           // Number of blocks for meta1 & 2
	super_block.Super.Inodes = (int)(temp) * INODES_PER_BLOCK;	    // Number of inodes in file system
	
	super_block.Super.Meta1_Bitmap        = META1_BITMAP;
	super_block.Super.Meta2_Bitmap        = META2_BITMAP;
	super_block.Super.Data_Bitmap         = DATA_BITMAP;
	super_block.Super.Meta1_Block_start  = super_block.Super.Data_Bitmap+1;
	super_block.Super.Meta2_Block_start  = super_block.Super.Meta1_Block_start + (int)(temp/2);
	super_block.Super.Data_Block_start   = super_block.Super.Meta2_Block_start + (int)(temp/2);

	// Write superblock
	m_disk->write(0, super_block.Data);
	// Write inode bitmap
	m_disk->write(META1_BITMAP, Meta1_BITMAP.Data);
	m_disk->write(META2_BITMAP, Meta2_BITMAP.Data);
	// Write data bitmap
	m_disk->write(DATA_BITMAP, Data_BITMAP.Data);

	int i, j, k;
	int total_inodes_blocks = super_block.Super.InodeBlocks;
	inode_blocks = new Block[total_inodes_blocks];

	for (i = 0; i < (total_inodes_blocks/2); i++)
	{
		for (j = 0; j < INODES_DATA_PER_BLOCK; j++)
		{
			inode_blocks[i].FCB[j].Type = META1;
			inode_blocks[i].FCB[j].Valid = 0;
			inode_blocks[i].FCB[j].Inode = 0;
		}
		m_disk->write(super_block.Super.Meta1_Block_start + i, inode_blocks[i].Data);
	}

	for (; i < total_inodes_blocks; i++)
	{
		for (j = 0; j < INODES_PER_BLOCK; j++)
			{
			    inode_blocks[i].Inodes[j].Size = 0;
			    inode_blocks[i].Inodes[j].Valid = 0;
				inode_blocks[i].Inodes[j].Type = META2;
				for (k = 0; k < POINTERS_PER_INODE; k++)
				{
					inode_blocks[i].Inodes[j].Direct[k] = 0;
				}
				inode_blocks[i].Inodes[j].Indirect = 0;
			} 
		m_disk->write(super_block.Super.Meta2_Block_start+i, inode_blocks[i].Data);
	}

	return true;
}

// Mount file system -----------------------------------------------------------
//m
bool FileSystem::mount() {
	//TODO IN CLASS 

	// Read superblock
	m_disk->read(0, super_block.Data);

	// Set device and mount
	m_disk->mount();

	inode_blocks = new Block[super_block.Super.InodeBlocks];

	//create a durty block list and set them to false
	inode_blocks_dirty = new bool[super_block.Super.InodeBlocks];
	memset(inode_blocks_dirty, 0, super_block.Super.InodeBlocks);

	// Copy metadata
	// update free block bitmap
	m_disk->read(META1_BITMAP, Meta1_BITMAP.Data);
	m_disk->read(META2_BITMAP, Meta2_BITMAP.Data);
	// Write data bitmap
	m_disk->read(DATA_BITMAP, Data_BITMAP.Data);

	// Read all Inode blocks and hold them in memory
	// build the free block list
	int total_inodes = super_block.Super.InodeBlocks;
	for (int i = 0; i < total_inodes; i++)
	{
		//load inode block into memory
		m_disk->read(super_block.Super.Meta1_Block_start + i, inode_blocks[i].Data);
	}

	return true;
}

size_t FileSystem::get_Meta2_start_inode()
{
	return  (super_block.Super.Meta2_Block_start - super_block.Super.Meta1_Block_start)
		* INODES_PER_BLOCK;
}

// Create inode ----------------------------------------------------------------
size_t FileSystem::create(char* name) {
	// Locate free inode in inode table for meta1
	size_t meta1 = 0;
	size_t meta2 = 0;

	//TODO IN CLASS 

	// Locate free inode in inode table for meta1
	meta1 = getFreeSpot(&Meta1_BITMAP);
	meta2 = getFreeSpot(&Meta2_BITMAP)+get_Meta2_start_inode();

	Inode_Meta1* pInode = (Inode_Meta1*)getINode(meta1);
	pInode->Valid = 1;
	pInode->Type = META1;
	pInode->Inode = meta2;
	name[MAX_FILE_NAME_LENGTH-1] = 0;
	strcpy_s(pInode->FileName, name);
	
	Inode_Meta2* pInode_2 = (Inode_Meta2*)getINode(meta2);
	pInode_2->Valid = 1;
	pInode_2->Type = META2;

	// Record inode if found
	inode_blocks_dirty[int(meta1/INODES_PER_BLOCK)] = true;
	inode_blocks_dirty[int(meta2/INODES_PER_BLOCK)] = true;
	
	return meta2;
}

// Remove inode ----------------------------------------------------------------

bool FileSystem::remove(char* name) {
	//TODO
	// search for file name
	uint32_t inode_meta2;
	uint32_t inode_meta1 = search(name, &inode_meta2);

	// get inode pointer for meta2 clear all direct pointers
	inode_meta2 = get_Meta2_start_inode();
	// mark data block as free free
	setDataBlockFreeSpot(&Data_BITMAP,0);
	// mark meta2 as free
	setMeta2FreeSpot(&Meta2_BITMAP,inode_meta2);
	// mark meta2 inode as dirty
	inode_blocks_dirty[int(inode_meta2/INODES_PER_BLOCK)] = true;
	// clear all info in meta1
	
	
	// mark meta1 as free
	setMeta1FreeSpot(&Meta1_BITMAP,inode_meta1);
	// mark meta1 inode as dirty
	inode_blocks_dirty[int(inode_meta1/INODES_PER_BLOCK)] = true;

	return false;
}

void FileSystem::ls() {
	// load master block
	// loop through inode information
	uint32_t inode_number = 0, size = 0;

	//loop through all inodes
	int Meta1_inode_end = (super_block.Super.Meta2_Block_start - super_block.Super.Meta1_Block_start)
		* INODES_PER_BLOCK;
	int Meta2_inode_end = (super_block.Super.Data_Block_start - super_block.Super.Meta2_Block_start)
		* INODES_PER_BLOCK;
	if((Meta1_inode_end + Meta2_inode_end) != (super_block.Super.InodeBlocks * INODES_PER_BLOCK))
		throw std::runtime_error("Inode error!");
	for (int i = 0; i < Meta1_inode_end; i++)
	{
		Inode_Meta1* pInode = (Inode_Meta1*)getINode(i);
		if (pInode != NULL && pInode->Valid==1) {
			int j = pInode->Inode;
			Inode_Meta2* pInode_2 = (Inode_Meta2*)getINode(j);
			if (pInode_2 != NULL && pInode_2->Valid==1)
			{
				size = pInode_2->Size;
				printf("Fule name %s is saved in iNode %u and the file size is %u\n", pInode->FileName, j , size);
			}
		}
	}
}


// Read from inode -------------------------------------------------------------
// returns the number of bytes read
size_t FileSystem::read(size_t inumber, unsigned char *data, size_t length, size_t offset) {
	int direct_pointer_index;
	int data_block_number;
	DWORD NumberOfBytesRead = 0;
	
	//TODO
	// calculate the direct_pointer_index based on the offset
	
	direct_pointer_index = int(offset /length);;
	// get the data block number
	data_block_number = getFreeSpot(&Data_BITMAP) + super_block.Super.Data_Block_start;;
	//if Inode is Valid and data block number greater than zero
	// read the data block
	if (isValidInode(inumber) && data_block_number > 0) {

		NumberOfBytesRead = m_disk->read(data_block_number,data);
	}

	return NumberOfBytesRead;
}

size_t FileSystem::search(const char* file_name)
{
	//loop through all inodes
	int Meta1_inode_end = (super_block.Super.Meta2_Block_start - super_block.Super.Meta1_Block_start)
		* INODES_PER_BLOCK;
	int Meta2_inode_end = (super_block.Super.Data_Block_start - super_block.Super.Meta2_Block_start)
		* INODES_PER_BLOCK;
	if ((Meta1_inode_end + Meta2_inode_end) != (super_block.Super.InodeBlocks * INODES_PER_BLOCK))
		throw std::runtime_error("Inode error!");
	size_t inode= INVALIDE_RETURN;
	for (int i = 0; i < Meta1_inode_end; i++)
	{
		Inode_Meta1* pInode = (Inode_Meta1*)getINode(i);
		if (pInode != NULL && pInode->Valid == 1 && strcmp(pInode->FileName, file_name)==0) {
			inode = pInode->Inode;
		}
	}
	return inode;
}

size_t FileSystem::search(const char* file_name, uint32_t* inode_meta2)
{
	//loop through all inodes
	int Meta1_inode_end = (super_block.Super.Meta2_Block_start - super_block.Super.Meta1_Block_start)
		* INODES_PER_BLOCK;
	int Meta2_inode_end = (super_block.Super.Data_Block_start - super_block.Super.Meta2_Block_start)
		* INODES_PER_BLOCK;
	if ((Meta1_inode_end + Meta2_inode_end) != (super_block.Super.InodeBlocks * INODES_PER_BLOCK))
		throw std::runtime_error("Inode error!");
	size_t inode = INVALIDE_RETURN;
	for (int i = 0; i < Meta1_inode_end; i++)
	{
		Inode_Meta1* pInode = (Inode_Meta1*)getINode(i);
		if (pInode != NULL && pInode->Valid == 1 && strcmp(pInode->FileName, file_name) == 0) {
			*inode_meta2 = pInode->Inode;
			return i;
		}
	}
	return inode;
}

// Write to inode --------------------------------------------------------------
// Limit file size to only 5 data blocks (POINTERS_PER_INODE)
size_t FileSystem::write(size_t inumber, unsigned char *data, size_t length, size_t offset) {
	int total_write = 0;
	int direct_pointer_index = int(offset / Disk::BLOCK_SIZE);
	int data_block_number = getFreeSpot(&Data_BITMAP) + super_block.Super.Data_Block_start;
	if (data_block_number > 0 && direct_pointer_index < POINTERS_PER_INODE) {
		Inode_Meta2* pInode = (Inode_Meta2*)getINode(inumber);
		pInode->Direct[direct_pointer_index] = data_block_number;
		total_write = m_disk->write(data_block_number, data);
	}
	return total_write;
}

void FileSystem::updateSize(uint32_t node_number, uint32_t size)
{
	Inode_Meta2* pInode = (Inode_Meta2*)getINode(node_number);
	pInode->Size = size;
}

//getFreeSpot and update status
int FileSystem::getFreeSpot(Block* bitmap)
{
	int j, i = 0;
	for (i = 0; i < Disk::BLOCK_SIZE; i++)
	{
		uint8_t map = bitmap->BitMap[i];
		if (map > 0)
			break;
	}
	if(i== Disk::BLOCK_SIZE)
		throw std::runtime_error("Inode error: no empty inode!");
	uint8_t mask = bitmap->BitMap[i];
	j = i * 8;
	if (mask&1)
	{
		mask = 0b11111110;
	}else
	if (mask & 2)
	{
		j = j + 1;
		mask = 0b11111101;
	}else
	if (mask & 4)
	{
		j = j + 2;
		mask = 0b11111011;
	}else
	if (mask & 8)
	{
		j = j + 3;
		mask = 0b11110111;
	}else
	if (mask & 16)
	{
		j = j + 4;
		mask = 0b11101111;
	}else
	if (mask & 32)
	{
		j = j + 5;
		mask = 0b11011111;
	}else
	if (mask & 64)
	{
		j = j + 6;
		mask = 0b10111111;
	}else
	if (mask & 128)
	{
		j = j + 7;
		mask = 0b01111111;
	}
	bitmap->BitMap[i] = bitmap->BitMap[i] & mask;
	return j;
}

//A bit is mark free by setting it to 1
void FileSystem::setFreeSpot(Block* bitmap, int index)
{
	int bitmap_index = index / 8;
	int bit_offset = index % 8;
	uint8_t mask = 1 << bit_offset;
	mask = mask | bitmap->BitMap[bitmap_index];    //logical or
	bitmap->BitMap[bitmap_index] = mask;
}
void FileSystem::setMeta1FreeSpot(Block* bitmap, int index)
{
	//index is the inode starting from zero
	setFreeSpot(bitmap, index);
}
void FileSystem::setMeta2FreeSpot(Block* bitmap, int index)
{
	//index is the inode starting from zero
	//However, Meta2 start half way through
	int meta2_index = get_Meta2_start_inode() + index;
	setFreeSpot(bitmap, meta2_index);
}
void FileSystem::setDataBlockFreeSpot(Block* bitmap, int index)
{
	//index is the block data starting from zero
	setFreeSpot(bitmap, index);
}