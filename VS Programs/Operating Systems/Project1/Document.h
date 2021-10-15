#pragma once
#include <string.h>
#include <iostream>
#include <Windows.h>
#include "MemoryFormat.h"
#include "SharedMemoryIO.h"
using namespace std;

class Document : public SharedMemoryIO
{
public:
	Document();
	~Document();
	boolean Display();
	boolean setText(string data, int line);
	wchar_t* getText(int line);
private:
	wchar_t* utf8_to_unicode(string str);
	int previous_version;
    void IncRefPtr();
    void DecRefPtr();
	boolean isLastPtr();
};

