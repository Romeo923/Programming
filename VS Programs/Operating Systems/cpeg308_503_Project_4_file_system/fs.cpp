// fs.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <iostream>
#include <stdlib.h>
#include "FileSystem.h"

#define _CRT_SECURE_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS_GLOBALS

// Macros

#define streq(a, b) (strcmp((a), (b)) == 0)

// Command prototypes
void do_debug(int args, char* arg1, char* arg2);
void do_format(int args, char* arg1, char* arg2);
void do_mount(int args, char* arg1, char* arg2);
void do_cat(int args, char* arg1, char* arg2);
void do_ls(int args, char* arg1, char* arg2);
bool do_copyout(int args, char* arg1, const char* arg2);
void do_remove(int args, char* arg1, char* arg2);
void do_copyin(int args, char* arg1, char* arg2);
void do_help(int args, char* arg1, char* arg2);
bool copyout(const char* file_name, FILE* stream);
bool copyin(const char* path);
//
char* get_name(const char* path);

FileSystem fs;

// Main execution
int main()
{
	char line[BUFSIZ], *cmd=NULL, *arg1=NULL, *arg2=NULL;
	char* context;
	if (fs.get_status() != true){
		fprintf(stderr, "Virtual Disk Size (in MB)? ");
		fflush(stderr);
		if (fgets(line, BUFSIZ, stdin) != NULL) {
			if (atoi(line) > 0 && atoi(line) < 11)
			{
				size_t size = atoi(line) * 1024000;
				fs.format(size);
			}
		}
	}
	int args;
	while (fs.get_status()) {
		fprintf(stderr, "UB fs> ");
		fflush(stderr);
		args = 0;
		if (fgets(line, BUFSIZ, stdin) == NULL) {
			break;
		}
		try {
			args++;
			cmd = strtok_s(line, " ", &context);
			if (context != NULL && strlen(context) > 0) {
				arg1 = strtok_s(context, " ", &context);
				args++;
				if (context != 0 && strlen(context) > 0) {
					arg2 = strtok_s(context, " ", &context);
					arg2[strlen(arg2)-1] = 0;
					args++;
				}
				else arg1[strlen(arg1)-1] = 0;
			}
			else cmd[strlen(cmd)-1] = 0;
		}
		catch (std::runtime_error& e) {}

		if (streq(cmd, "debug")) {
			do_debug(args, arg1, arg2);
		}
		else if (streq(cmd, "format")) {
			do_format(args, arg1, arg2);
		}
		else if (streq(cmd, "mount")) {
			do_mount(args, arg1, arg2);
		}
		else if (streq(cmd, "cat")) {
			do_cat(args, arg1, arg2);
		}
		else if (streq(cmd, "ls")) {
			do_ls(args, arg1, arg2);
		}
		else if (streq(cmd, "copyout")) {
			do_copyout(args, arg1, arg2);
		}
		else if (streq(cmd, "remove")) {
			do_remove(args, arg1, arg2);
		}
		else if (streq(cmd, "copyin")) {
			do_copyin(args, arg1, arg2);
		}
		else if (streq(cmd, "help")) {
			do_help(args, arg1, arg2);
		}
		else if (streq(cmd, "exit") || streq(cmd, "quit")) {
			break;
		}
		else {
			printf("Unknown command: %s", line);
			printf("Type 'help' for a list of commands.\n");
		}
	}
}

// Command functions

void do_debug(int args, char* arg1, char* arg2) {
	if (args != 1) {
		printf("Usage: debug\n");
		return;
	}

	fs.debug();
}

void do_format(int args, char* arg1, char* arg2) {
	if (args != 1) {
		printf("Usage: format\n");
		return;
	}

	if (fs.format()) {
		printf("disk formatted.\n");
	}
	else {
		printf("format failed!\n");
	}
}

void do_mount(int args, char* arg1, char* arg2) {
	if (args != 1) {
		printf("Usage: mount\n");
		return;
	}

	if (fs.mount()) {
		printf("disk mounted.\n");
	}
	else {
		printf("mount failed!\n");
	}
}

void do_cat(int args, char* arg1, char* arg2) {
	if (args != 2) {
		printf("Usage: cat <file_name>\n");
		return;
	}

	if (!do_copyout(3, arg1, "stdout.txt")) {
		printf("cat failed!\n");
	}
}

bool do_copyout(int args, char* arg1, const char* arg2) {
	if (args != 3) {
		printf("Usage: copyout <file_name> <desc path & file_name>\n");
		return false;
	}
	FILE* stream;
	errno_t errno;
	errno = fopen_s(&stream, arg2, "w");
	if (stream == nullptr) {
		fprintf(stderr, "Unable to open %s: %d\n", arg2, errno);
		return false;
	}
	if (!copyout(arg1, stream)) {
		printf("copyout failed!\n");
		return false;
	}
	return true;
}

void do_remove(int args, char* arg1, char* arg2) {
	if (args != 2) {
		printf("Usage: remove <file name>\n");
		return;
	}

	if (!fs.isDiskMounted())
	{
		printf("Disk not mounted!\n");
		return;
	}

	if (fs.remove(arg1)) {
		printf("removed file name %s.\n", arg1);
	}
	else {
		printf("remove failed!\n");
	}
}

void do_ls(int args, char* arg1, char* arg2) {
	if (args != 1) {
		printf("Usage: ls\n");
		return;
	}

	if (!fs.isDiskMounted())
	{
		printf("Disk not mounted!\n");
		return;
	}

	fs.ls();
}

void do_copyin(int args, char* arg1, char* arg2) {
	if (args != 2) {
		printf("Usage: copyin <file>\n");
		return;
	}

	if (!copyin(arg1)) {
		printf("copyin failed!\n");
	}
}

void do_help(int args, char* arg1, char* arg2) {
	printf("Commands are:\n");
	printf("    format\n");
	printf("    mount\n");
	printf("    debug\n");
	printf("    remove  <file_name>\n");
	printf("    cat     <file_name>\n");
	printf("    copyin  <file_name>\n");
	printf("    copyout <file_name>\n");
	printf("    help\n");
	printf("    quit\n");
	printf("    exit\n");
}

bool copyout(const char* file_name, FILE* stream) {
	if (!fs.isDiskMounted())
	{
		printf("Disk not mounted!\n");
		return false;
	}

	unsigned char buffer[8 * BUFSIZ] = { 0 };
	size_t offset = 0;
	size_t inumber = fs.search(file_name);
	bool flag = true;
	while (flag) {
		size_t result = fs.read(inumber, buffer, sizeof(buffer), offset);
		size_t actual = strlen((char*)buffer);
		flag = actual >= result;
		if (result <= 0) {
			break;
		}
		fwrite(buffer, 1, actual, stream);
		offset += actual;
	}

	printf("%lu bytes copied\n", offset);
	fclose(stream);
	return true;
}

bool copyin(const char* path) {
	FILE* stream;
	errno_t errno;
	errno = fopen_s(&stream, path, "r");
	if (stream == nullptr) {
		fprintf(stderr, "Unable to open %s: %d\n", path, errno);
		return false;
	}

	if (!fs.isDiskMounted())
	{
		printf("Disk not mounted!\n");
		return false;
	}

	//extract file name
	char* file_name = get_name(path);
	size_t inumber = fs.create(file_name);

	unsigned char buffer[8 * BUFSIZ] = { 0 };
	size_t offset = 0;
	while (true) {
		size_t result = fread(buffer, 1, sizeof(buffer), stream);
		if (result <= 0) {
			break;
		}

		size_t actual = fs.write(inumber, buffer, result, offset);
		if (actual <= 0) {
			fprintf(stderr, "fs.write returned invalid result %ld\n", actual);
			break;
		}
		offset += result;
		if (actual < result) {
			fprintf(stderr, "fs.write only wrote %ld bytes, not %ld bytes\n", actual, result);
			break;
		}
	}

	fs.updateSize(inumber, offset);

	printf("%lu bytes copied\n", offset);
	fclose(stream);
	return true;
}

char* get_name(const char* path)
{
	int i, j = 0, len = strlen(path);

	if (len == 0)
		return NULL;

	for (i = 0; i < len; i++)
	{
		if (path[i] == '\\')
			j = i+1;
	}
	char* file_name = new char[len - j + 1];
	for (i = 0; i < len; i++)
		file_name[i] = path[j + i];
	file_name[i] = 0;
	return file_name;
}
