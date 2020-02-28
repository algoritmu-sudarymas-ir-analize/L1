using System;
using NUnit.Framework;
using QuickSort;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(new[]{3,2,1}, new[]{1,2,3})]
        [TestCase(new[]{9,6,7,1,3,2,5,4,8,10}, new[]{1,2,3,4,5,6,7,8,9,10})]
        [TestCase(new[]{9,8,7,6,5,4,1,2,3,3,6,9,2,5,8,1,4,7}, new[]{1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9})]
        public void ArrayQuickort(int[]a, int[]b)
        {
            Sort.QuickSort(a, 0, a.Length - 1);
            Assert.AreEqual(a,b);
        }

        [Test]
        public void LListQuickSort()
        {
            LinkedList list = new LinkedList();  
            list.AddLast(7);
            list.AddLast(3);
            list.AddLast(10);
            list.AddLast(8);
            list.AddLast(4);
            list.AddLast(2);
            list.AddLast(6);
            list.AddLast(1);
            list.AddLast(5);
            list.AddLast(9);
              
              
            Console.WriteLine("Linked List before sorting ");  
            list.printList(list.Head);  
            Console.WriteLine("\nLinked List after sorting");  
            Sort.LListQuickSort(list.Head, list.Tail);
            list.printList(list.Head);  
        }
    }
}