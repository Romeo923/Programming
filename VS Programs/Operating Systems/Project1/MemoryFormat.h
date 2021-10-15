#pragma once
#define MAX_ROW 10
#define MAX_COL 40
struct MemoryFormat
{
	int version;
	int number_of_connection;
	wchar_t Buffer[MAX_ROW][MAX_COL];
};

