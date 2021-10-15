#include <iostream>
#include <cwchar>
#include <ctime>
#include <windows.h>
#include "Utils.h"
#include "Document.h"

MemoryFormat empty_memory = { 0, 0, {0} };

Document::Document() : SharedMemoryIO((PVOID)(&empty_memory), sizeof(MemoryFormat))
{
	if (getStatus()) {
		IncRefPtr();
		previous_version = 0;
		srand((unsigned)time(0));
	}
}

//manage memory upon exit
Document::~Document()
{
	if (getStatus())
	{
		if (isLastPtr())
			ReleaseMem();
		else DecRefPtr();
	}
}

/*
This function is called to update a specific line in the document.
Note: You can use wcscpy_s to copy wide string (wchar_t)
*/
boolean Document::setText(string data, int line)
{
	boolean flag = false;
	int new_document_number = rand();
	wchar_t* data_to_copy = utf8_to_unicode(data);

	//TODO: If input is valid, make the necessary update to the document
	 
	MemoryFormat* buffer = (MemoryFormat*)getPtr();
	if (buffer->version != previous_version) {
		if (line < MAX_ROW)
		{
			buffer->version = new_document_number;
			wcscpy_s(buffer->Buffer[line], MAX_COL, data_to_copy);
			flag = true;

		}
	}
	
	return flag;
}

/*
* This function copy a specific line from the document and return the text.
* Note: wcscpy_s can be used to copy wide string (wchar_t)
*/
wchar_t* Document::getText(int line)
{
	wchar_t *data_to = new wchar_t[MAX_ROW];

	//TODO:

	MemoryFormat* buffer = (MemoryFormat*)getPtr();
	if (buffer->version != previous_version) {
		if (line < MAX_ROW)
		{
			wcscpy_s(data_to,MAX_COL,buffer->Buffer[line]);

		}
	}

	return data_to;
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////
//The following are utility functions. No modification needed.
///////////////////////////////////////////////////////////////////////////////////////////////////////////

/*This function is called to display the document
  wcout is used to display wchar_t* type
  Note: The function only display if document version changed.
        There are two ways to access the access content of the shared memory.
		1) directly by using the pointer ex: MemoryFormat* buffer = (MemoryFormat*)getPtr();
		2) by copy the content to a local memory buffer. ex:
				MemoryFormat buffer;
				read(&buffer);
*/
boolean Document::Display()
{
	boolean flag = false;
	int x = 60;
	//MemoryFormat* buffer = (MemoryFormat*)getPtr();
	MemoryFormat buffer;
	read(&buffer);
	if (buffer.version != previous_version) {
		Utils::clearScreen();
		Utils::setCursor(x, 0);
		cout << "Document version: " << buffer.version << endl;
		for (int i = 0; i < MAX_ROW; i++)
		{
			Utils::setCursor(x, i + 1);
			wcout << i << ": ";
			if (wcslen(buffer.Buffer[i]) > 0)
				wcout << buffer.Buffer[i] << endl;
		}
		Utils::setCursor(x, MAX_ROW + 1);
		cout << "< END OF DOCUMENT >" << endl;
		previous_version = buffer.version;
		flag = true;
	}
	return flag;
}

//test if this process the only process using the shared memory
boolean Document::isLastPtr()
{
	boolean flag = false;
	flag = (((MemoryFormat*)getPtr())->number_of_connection == 1);
	return flag;
}

//increment number of running processes
void Document::IncRefPtr()
{
	((MemoryFormat*)getPtr())->number_of_connection = ((MemoryFormat*)getPtr())->number_of_connection + 1;
}

//decrement number of running processes
void Document::DecRefPtr()
{
	((MemoryFormat*)getPtr())->number_of_connection = ((MemoryFormat*)getPtr())->number_of_connection - 1;
}

// Convert an UTF8 string to a wide Unicode String
wchar_t* Document::utf8_to_unicode(string str)
{
	if (str.empty()) return NULL;
	int size_needed = MultiByteToWideChar(CP_UTF8, 0, &str[0], (int)str.size(), NULL, 0);
	wchar_t* wstrTo = new wchar_t[size_needed + 1];
	MultiByteToWideChar(CP_UTF8, 0, &str[0], (int)str.size(), wstrTo, size_needed);
	wstrTo[size_needed] = 0;
	return wstrTo;
}