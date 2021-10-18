#include "pch.h"
#include "SharedData.h"
#include <time.h>
#include <wchar.h>

SharedData::SharedData()
{ 
	//pound of rice
	Rice = 5000;
	for (int i = 0; i < MAX_PHILOSOPHER; i++)
		chopstic[i] = CreateMutex();
	pMutex = CreateMutex();

	//TODO: replace the ? with a number
	pSeating = CreateSemaphore(1, 3);
}


SharedData::~SharedData()
{
	for (int i = 0; i < MAX_PHILOSOPHER; i++)
		if(chopstic[i] != NULL )
			CloseHandle(chopstic[i]);

	if (pMutex != NULL)
		CloseHandle(pMutex);

	if (pSeating != NULL)
		CloseHandle(pSeating);
}

//This function implements the critical section that protects the share variable Rice
void SharedData::Eat(int who, int* state, int new_state)
{ 
	bool got_rice = false;
	//////////////////////////////////////////////////////////
	//TODO

	wait(pMutex);
	signal_mutex(pMutex);
	requestToSit(who);
	UnSit(who);
	getLeftChopstic(who);
	putLeftChopstic(who);
	getRightChopstic(who);
	putRightChopstic(who);

	got_rice = MoreRice();
	if(got_rice) {
		Rice--; //getting rice
	}	

	//More than one philosopher is alloed to ConsumeRice in parallel
	if (got_rice) {
		ConsumeRice(state, new_state);
	}
    
}

//This function creates a nameless semaphore.
HANDLE SharedData::CreateSemaphore(int init_count, int max_count)
{
	HANDLE hSemaphore = NULL;
		hSemaphore = CreateSemaphoreA(
							NULL,         
			                init_count,           // Initial count
			                max_count,            // Max count                                  
						    NULL);        
	return hSemaphore;
}

//This function creates a nameless mutex.
HANDLE SharedData::CreateMutex()
{
	return CreateMutexA(NULL, FALSE, NULL);
}

bool SharedData::MoreRice()
{
	return (Rice > 0);
}

void SharedData::wait(HANDLE pParam)
{
	DWORD status;
	if (pParam != NULL)
		status = WaitForSingleObject(pParam, INFINITE);
	Sleep(5);
}

void SharedData::signal_semaphore(HANDLE pParam)
{
	if (pParam != NULL)
		ReleaseSemaphore(pParam, 1, NULL);
}

void SharedData::signal_mutex(HANDLE pParam)
{
	if (pParam != NULL)
		ReleaseMutex(pParam);
}

void SharedData::getLeftChopstic(int who)
{
	getChopstic(who);
}


void SharedData::getRightChopstic(int who)
{
	getChopstic((who+1) % MAX_PHILOSOPHER);
}

void SharedData::getChopstic(int who)
{
	wait(chopstic[who]);
}

void SharedData::putLeftChopstic(int who)
{
	putChopstic(who);
}


void SharedData::putRightChopstic(int who)
{
	putChopstic((who + 1) % MAX_PHILOSOPHER);
}

void SharedData::putChopstic(int who)
{
	signal_mutex(chopstic[who]);
}

void SharedData::requestToSit(int who)
{
	wait(pSeating);
}

void SharedData::UnSit(int who)
{
	signal_semaphore(pSeating);
}

void SharedData::ConsumeRice(int* state, int new_state)
{
	*state = new_state;
	Sleep(rand() % 20);
}
