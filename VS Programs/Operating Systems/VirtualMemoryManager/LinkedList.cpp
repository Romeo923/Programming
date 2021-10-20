#include "LinkedList.h"

#define NULL 0

LinkedList::LinkedList()
{
	Head = NULL;
	Tail = Head;
}

LinkedList::~LinkedList()
{
	if (Head != NULL)
	{
		while (Head->Next != NULL)
		{
			Tail = Head;
			Head = Head->Next;
			delete Tail;
		}
		delete Head;
	}
}

//This function is to help debuging
void LinkedList::List()
{
	NODE *tmp = Head;
	
	while(tmp != NULL)
	{
		tmp = tmp->Next;
	} 
}

//This function return the frame index to free
int LinkedList::RemoveTail()
{
	int frame_index = NOT_FOUND;
	if (Tail != NULL)
	{
		NODE *tmp = Tail;
		frame_index = Tail->m_frame_index;
		if (Tail->Previous != NULL)
		{
			Tail = Tail->Previous;
			Tail->Next = NULL;
			delete tmp;
		}
	}
	return frame_index;
}

void LinkedList::MoveToHead(int page)
{
	if (Head!=NULL && Head->m_page!=page) //if it's already on top do nothing
	{
		int frame_index = Remove(page);
		if(frame_index!=NOT_FOUND)
			AddToHead(page, frame_index);
	}
}

int LinkedList::Remove(int page)
{
	int frame_index = NOT_FOUND;
	NODE *tmp = Head;
	if (tmp != NULL)
	{
		do
		{
			if (tmp->m_page == page)
			{
				NODE *save = tmp;
				frame_index = tmp->m_frame_index;
				if (tmp->Previous != NULL) //is head?
				{
					if (tmp->Next != NULL) //is tail?
					{
						tmp->Next->Previous = tmp->Previous;
						tmp->Previous->Next = tmp->Next;
					}
					else //removing tail
					{
						tmp->Previous->Next = NULL;
						Tail = tmp->Previous;
					}
				}
				else //removing head
				{
					Head = tmp->Next;
					Head->Previous = NULL;
				}
				
				delete save;
				return frame_index;
			}
			if(tmp->Next !=NULL)
				tmp = tmp->Next;
		} while (tmp!=NULL);
	}
	return NOT_FOUND;
}

void LinkedList::AddToHead(int page, int frame_index)
{
	NODE *tmp = new NODE;
	tmp->m_page = page;
	tmp->m_frame_index = frame_index;
	tmp->Previous = NULL;
	tmp->Next = Head;
	if(Head!=NULL)
		Head->Previous = tmp;
	if (Tail == NULL)
		Tail = tmp;
	Head = tmp;
}