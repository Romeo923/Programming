#pragma once
//#include <wincontypes.h>
//#include <WinBase.h>
//#include <consoleapi2.h>
//#include <WinNls.h>
#include <iostream>
#include <Windows.h>
#include <iostream>
#include <cwchar>
#include <string.h>
class Utils
{
public:
	//support functions
	static void setCursor(int x, int y)
	{
		COORD coord;
		coord.X = x;
		coord.Y = y;
		SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
	}

	static void clearScreen()
	{
		COORD topLeft = { 0, 0 };
		HANDLE console = GetStdHandle(STD_OUTPUT_HANDLE);
		CONSOLE_SCREEN_BUFFER_INFO screen;
		DWORD written;

		GetConsoleScreenBufferInfo(console, &screen);
		FillConsoleOutputCharacterA(
			console, ' ', screen.dwSize.X * screen.dwSize.Y, topLeft, &written
		);
		FillConsoleOutputAttribute(
			console, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_BLUE,
			screen.dwSize.X * screen.dwSize.Y, topLeft, &written
		);
		setCursor(topLeft.X, topLeft.Y);
	}
};

