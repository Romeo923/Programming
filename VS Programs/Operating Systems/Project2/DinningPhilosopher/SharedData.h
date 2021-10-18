#pragma once
#include <windows.h>

#define MAX_PHILOSOPHER 5
class SharedData
{
public:
	SharedData();
	~SharedData();
	void Eat(int who, int* state, int new_state);
	bool MoreRice();
private:
	int Rice;
	HANDLE chopstic[MAX_PHILOSOPHER];
	HANDLE pMutex;
	HANDLE pSeating;
	HANDLE CreateSemaphore(int init_count, int max_count);
	HANDLE CreateMutex();

	void wait(HANDLE pParam);
	void signal_semaphore(HANDLE pParam);
	void signal_mutex(HANDLE pParam);
	void requestToSit(int who);
	void UnSit(int who);
	void getLeftChopstic(int who);
	void getRightChopstic(int who);
	void getChopstic(int who);
	void putLeftChopstic(int who);
	void putRightChopstic(int who);
	void putChopstic(int who);
	void ConsumeRice(int* state, int new_state);
};

