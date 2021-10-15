// UBOS_Project1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <sstream>
#include <string.h>
#include <cwchar>

#include <conio.h>
#include "Document.h"
#include "SharedMemoryIO.h"
#include "Utils.h"

#define THREAD_RUN 1
#define THREAD_STOP 0
#define NO_INPUT -1

Document* document = NULL;
SharedMemoryIO* shared_memory = NULL;
boolean skip_user_input = false;
int thread_signal = THREAD_RUN;

//Note: MAX_ROW abd MAX_COL are defined in MemoryFormat.h and can be used throughout the project.

/*
This procedure display the content of the document at a specified location on the screen.
*/
void Display()
{
    while (document!=NULL && thread_signal == THREAD_RUN)
    {
        if (document->Display()) {
            Utils::setCursor(9, 0);
            skip_user_input = true;
        }
        Sleep(500);
        skip_user_input = false;
    }
}

/*
This function get the cessary inputs (line number and text) from the user and update the document.
*/
void Input()
{
    int line = NO_INPUT;
    std::string data;
    Utils::setCursor(0, 0);
    std::cout << "Line # (-1 to end): ";
    while (!_kbhit() && !skip_user_input) {}
    if (!skip_user_input) {
        std::cin >> line;
        std::cin.ignore();
        if (line != NO_INPUT) {
            wchar_t* tmp = document->getText(line);
            Utils::setCursor(0, 1);
            std::cout << "Input data: ";
            if (wcslen(tmp) > 0)
                wcout << tmp;
            Utils::setCursor(13, 1);
            std::getline(std::cin, data);
            std::cin.clear();
            document->setText(data, line);
        }
        else  //The user has entered -1 to end the program
        {
            thread_signal = THREAD_STOP;
        }
    }
}


//TODO: Modify the main program as needed.
int main()
{
    HANDLE pThread = NULL;
    DWORD thread_id = 0;
    std::string data;
    int line = 0;
    document = new Document();
    if (document->getStatus()) {
        //shared memory established

        pThread = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)Display, NULL, 0, &thread_id);

        do {
            
            Input();

        } while (thread_signal != THREAD_STOP);

        //exiting
        Sleep(5);
    }
    document = NULL;
}
