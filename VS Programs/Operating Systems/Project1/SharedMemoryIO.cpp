#include "SharedMemoryIO.h"
#include <windows.h>
#include <tchar.h>
#include "MemoryFormat.h"

SharedMemoryIO::SharedMemoryIO()
{
	shared_memory_handle = INVALID_HANDLE_VALUE;
	MaxMessageSize = 0;
	Status = false;
}

/*
This class constructor establish a connection to a shared memory. The function should only create the memory if none exist.
Note: The handle to a chared memory is NULL or INVALID_HANDLE_VALUE if it does not exist.
      Shared memory can be created by calling “CreateFileMapping” which returns a handle identifier.  
      The handle identifier is then used to call “MapViewOfFile” to actually reserve/create the shared memory.
      If a shared memory is created, it should be initialized to empty or emptyMsg
      to create a shared memory, call the rapper function bellow: create_sm
      An already created shared memory can be accessed by calling the function “OpenFileMapping” which returns a handle identifier.  
      The handle identifier is then used to call “MapViewOfFile” to get a pointer to access the shared memory.    
      to open a shared memory, call the rapper function bellow: open_sm
      There rapper function to get the shared memory address is: GetBuffer
*/
SharedMemoryIO::SharedMemoryIO(PVOID emptyMsg, DWORD nMaxMessageSize)
{
	Status = false;
	boolean open_status = false;
	MaxMessageSize = nMaxMessageSize;
	const wchar_t tmp[] = L"Global\\Document";

	//TODO: open or create a shared memory
	//Note: save the handle to the shared memory to: shared_memory_handle
	//      save the pointer to the shared memory location to: memBuf
	//      If successfull set status to true

	
	shared_memory_handle = open_sm((LPTSTR)tmp);
	if (shared_memory_handle == NULL) {
		shared_memory_handle = create_sm((LPTSTR)tmp,NULL);
		open_status = true;
	}

	memBuf = GetBuffer(shared_memory_handle);
	if (open_status) {
		write(emptyMsg);
	}
	
	Status = true;

}

/*
* This destructor does not destroy the shared memory because it may not be the only one using the shared memory.
*/
SharedMemoryIO::~SharedMemoryIO()
{
}

/*
* This procedure is callsed by Document after it is establish that no other process is using the shared memory.
*/
void SharedMemoryIO::ReleaseMem()
{
	CloseHandle(shared_memory_handle);
	memBuf = NULL;
}

/*
To open (or access a already created shared memory) call the following Windows API function:
	OpenFileMapping
	OpenFileMapping returns a handle which is set to  NULL or INVALID_HANDLE_VALUE if no shared memory by that name exist
*/
HANDLE SharedMemoryIO::open_sm(LPTSTR memory_identifier)
{
	HANDLE hMapFile = NULL;
	DWORD access = FILE_MAP_ALL_ACCESS;
	boolean flag = false;

	//TODO:

	hMapFile = OpenFileMappingA(access,flag,(LPCSTR)memory_identifier);

	return hMapFile;
}

/*
To create a shared memory with a specific name, call the following Windows API function:
	CreateFileMapping
	CreateFileMapping returns a handle which is set to  NULL or INVALID_HANDLE_VALUE if no shared memory already exist or failed
	                          or a handle to identify the shared memory is it succeed
*/
HANDLE SharedMemoryIO::create_sm(LPTSTR memory_identifier, LPSECURITY_ATTRIBUTES lpSecurityAttributes)
{
	HANDLE hMapFile=NULL;
	DWORD access = PAGE_READWRITE;
    DWORD dwMaximumSizeHigh = 0;
    DWORD dwMaximumSizeLow = MaxMessageSize;

	//TODO:

	hMapFile = CreateFileMappingA(NULL, lpSecurityAttributes, access, dwMaximumSizeHigh, dwMaximumSizeLow, (LPCSTR)memory_identifier);
	
	return hMapFile;
}

/*
  This function takes as parameter a handle to a shared memory.
  To get a pointer to the shared memory location, call MapViewOfFile.
  MapViewOfFile returns NULL or INVALID_HANDLE_VALUE if failed
*/
LPCTSTR SharedMemoryIO::GetBuffer(HANDLE hMapFile)
{
	LPCTSTR pBuf = NULL;

	//TODO:

	pBuf = (LPCTSTR)MapViewOfFile(hMapFile,FILE_MAP_ALL_ACCESS,0, 0, MaxMessageSize);

	return pBuf;
}

/*
  This function copy the entire document to the shared memory.
  To copy data from one memory location to another, use the Windows API CopyMemory
  Note: the destination is "memBuf"  
        the size of the shared memory is saved in the constructor and its name is MaxMessageSize
*/
void SharedMemoryIO::write(PVOID source)
{
	//TODO:
	CopyMemory((PVOID)memBuf, source, MaxMessageSize);
}

/*
  This function copy the entire the shared memory to the document.
  To copy data from one memory location to another, use the Windows API CopyMemory
  Note: the source is "memBuf"
		the size of the shared memory is saved in the constructor and its name is MaxMessageSize
*/void SharedMemoryIO::read(PVOID dest)
{
	//TODO:
	CopyMemory(dest, memBuf, MaxMessageSize);
}