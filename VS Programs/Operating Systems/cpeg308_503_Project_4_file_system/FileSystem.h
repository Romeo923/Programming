
#pragma once
#include "disk.h"
#include <stdint.h>

const static uint32_t INVALIDE_RETURN = 2147483648;
const static uint32_t POINTERS_PER_INODE = 5;
const static uint32_t POINTERS_PER_BLOCK = 1024;
const static uint32_t INODES_PER_BLOCK = 128;
const static uint32_t INODES_DATA_PER_BLOCK = INODES_PER_BLOCK;
const static uint32_t MAX_FILE_NAME_LENGTH = 24;
const static uint32_t META1_BITMAP = 1;
const static uint32_t META2_BITMAP = 2;
const static uint32_t DATA_BITMAP = 3;
#define NOT_FREE 0
#define ALL_FREE 255

enum INODE_TYPE
{
	NONE,
	META1,
	META2,
	IND_PTR
};

struct SuperBlock {		    // Superblock structure
	uint32_t MagicNumber;	// File system magic number
	uint32_t Blocks;	    // Number of blocks in file system
	uint32_t InodeBlocks;	// Number of blocks reserved for inodes
	uint32_t Inodes;	    // Number of inodes in file system
	uint32_t Meta1_Bitmap;
	uint32_t Meta2_Bitmap;
	uint32_t Data_Bitmap;
	uint32_t Meta1_Block_start;
	uint32_t Meta2_Block_start;   //Meta1 are file names and pointer to Meta2
	uint32_t Data_Block_start;
};

struct Inode_Meta1 {
	uint16_t Valid;		// Whether or not inode is valid
	uint16_t Type;      // Indicate INode type see INODE_TYPE
	uint32_t Inode;		// file inode pointer
	char FileName[MAX_FILE_NAME_LENGTH];
};

struct Inode_Meta2 {
	uint16_t Valid;		// Whether or not inode is valid
	uint16_t Type;      // Indicate INode type see INODE_TYPE
	uint32_t Size;		// Size of file
	uint32_t Direct[POINTERS_PER_INODE]; // Direct pointers
	uint32_t Indirect;	// Indirect pointer
};

//all the elements in blocks have to be the same size 
union Block {
	SuperBlock     Super;			               // Superblock
	Inode_Meta1    FCB[INODES_DATA_PER_BLOCK];	   // FCB is half the size of INodes
	Inode_Meta2    Inodes[INODES_PER_BLOCK];	   // Inode block
	unsigned char  Data[Disk::BLOCK_SIZE];	       // Data block
	uint8_t        BitMap[Disk::BLOCK_SIZE];       // Free block Information
};

class FileSystem {
public:
	const static uint32_t MAGIC_NUMBER = 0xf0f03410;
	const static uint32_t INVALID_DATA_BLOCK = 0;
	FileSystem();
	~FileSystem();
	bool get_status() {
		return open_status;
	}
private:
	bool open_status;
	Disk *m_disk;
	Block super_block;
	Block Meta1_BITMAP;   //each bit represent one inode meta1 (not IBLOCK)
	Block Meta2_BITMAP;   //each bit represent one inode meta2 (not IBLOCK)
	Block Data_BITMAP;    //each bit represent one DATA BLOCK
	Block* inode_blocks;       //to hold all node blocks in memory
	bool* inode_blocks_dirty;  //which inode need saving

	void* getINode(uint32_t inode_number);
	void* getINode(uint32_t block_number, uint32_t inode_offset);

	// helper functions
	int getFreeSpot(Block* bitmap);
	size_t get_Meta2_start_inode();
	void setFreeSpot(Block* bitmap, int index);
	void setMeta1FreeSpot(Block* bitmap, int index);
	void setMeta2FreeSpot(Block* bitmap, int index);
	void setDataBlockFreeSpot(Block* bitmap, int index);
public:
	//already implemented
	size_t write(size_t inumber, unsigned char *data, size_t length, size_t offset);
	void updateSize(uint32_t Inode, uint32_t size);

	void debug();
	bool mount();

	size_t create(char* name);
	bool isDiskMounted();
	bool isValidInode(uint32_t inode);

	bool   format();
	bool   format(size_t size);
	bool   remove(char* name);
	void   ls();
	size_t read(size_t inumber, unsigned char *data, size_t length, size_t offset);
	size_t search(const char* file_name);
};
