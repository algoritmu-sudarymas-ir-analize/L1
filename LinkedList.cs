using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace QuickSort
{
    public class LinkedList : IEnumerable<int>
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

/* a node of the doubly linked list */
        public class Node
        {
            public int Data;
            public Node Next;
            public Node Prev;

            public Node(int data, Node prev = null, Node next = null)
            {
                Data = data;
                Next = next;
                Prev = prev;
            }
        }


/* Considers last element as pivot, 
places the pivot element at its  
correct position in a sorted array, 
and places all smaller (smaller than  
pivot) to left of pivot and all  
greater elements to right of pivot */


        // A utility function to print contents of arr  
        public void printList(Node head)
        {
            while (head != null)
            {
                Console.Write(head.Data + " ");
                head = head.Next;
            }
        }


        /* Function to insert a node at the  
        beginging of the Doubly Linked List */
        public void AddFirst(int data)
        {
            if (Head is null)
            {
                Head = new Node(data);
                Tail = Head;
            }
            else
            {
                Head.Prev = new Node(data, null, Head);
                Head = Head.Prev;
            }
        }

        public void AddLast(int number)
        {
            if (Head is null)
            {
                Head = new Node(number);
                Tail = Head;
            }
            else
            {
                Tail.Next = new Node(number, Tail);
                Tail = Tail.Next;
            }
        }


        public IEnumerator<int> GetEnumerator()
        {
            for (Node i = Head; i != null; i = i.Next)
                yield return i.Data;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            var head = Head;
            var builder = new StringBuilder();
            while (head != null)
            {
                builder.Append(head.Data).Append(" ");
                head = head.Next;
            }

            return builder.ToString().TrimEnd();
        }

        public string GetRangeString(int start, int end)
        {
            var head = Head;
            var builder = new StringBuilder();
            for (int i = 0; i <= end; i++)
            {
                if (i >= start)
                    builder.Append(head.Data).Append(" ");
                head = head.Next;
            }

            return builder.ToString().TrimEnd();
        }
    }
}