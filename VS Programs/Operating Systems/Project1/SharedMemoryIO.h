#pragma once
#include <windows.h>
#include <stdlib.h>
#include <tchar.h>
class SharedMemoryIO
{
public:
	SharedMemoryIO();
	SharedMemoryIO(PVOID emptyMsg, DWORD nMaxMessageSize);
	~SharedMemoryIO();
	PVOID getPtr() { return (PVOID)memBuf; }
	HANDLE open_sm(LPTSTR memory_identifier);
	HANDLE create_sm(LPTSTR memory_identifier, LPSECURITY_ATTRIBUTES lpSecurityAttribute);
	void write(PVOID source);
	void read(PVOID dest);
	boolean getStatus() { return Status; }
    void ReleaseMem();
protected:
	LPCTSTR     memBuf;
private:
	int MaxMessageSize;
	boolean Status;
	HANDLE shared_memory_handle;
	LPCTSTR GetBuffer(HANDLE hMapFile);
	virtual void IncRefPtr() = 0;
	virtual void DecRefPtr() = 0;
	virtual boolean isLastPtr() = 0;
};

