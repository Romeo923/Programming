#pragma once
#define NOT_FOUND			-1
class LinkedList
{
private:
	struct NODE
	{
		NODE *Previous;
		int m_page;
		int m_frame_index;
		NODE *Next;
	};

	NODE *Head;
	NODE* Tail;
	int Remove(int page);
	void List();
public:
	LinkedList();
	~LinkedList();
	int RemoveTail();
	void AddToHead(int page, int frame_index);
	void MoveToHead(int page);
};

