using System.Collections;
using System.Collections.Generic;

namespace QuickSort
{
    public class LinkedList : IEnumerable<int>
    {
        private Node First { get; set; }
        private Node Last { get; set; }
        public int Count { get; private set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (Node i = First; i != null; i = i.Right)
                yield return i.Data;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        public void AddLast(int number)
        {
            if (First is null)
            {
                First = new Node(number);
                Last = First;
            }
            else
            {
                Last.Right = new Node(number, Last);
                Last = Last.Right;
            }

            Count++;
        }

        private sealed class Node
        {
            internal Node Left { get; set; }
            internal Node Right { get; set; }
            internal int Data { get; set; }

            public Node()
            {
            }

            public Node(int data, Node left = null, Node right = null)
            {
                Left = left;
                Right = right;
                Data = data;
            }
            
            public override string ToString() => Data.ToString();
        }
    }
}