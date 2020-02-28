using System;
using NUnit.Framework;
using QuickSort;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(new[] {3, 2, 1}, new[] {1, 2, 3})]
        [TestCase(new[] {9, 6, 7, 1, 3, 2, 5, 4, 8, 10}, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10})]
        [TestCase(new[] {9, 8, 7, 6, 5, 4, 1, 2, 3, 3, 6, 9, 2, 5, 8, 1, 4, 7},
            new[] {1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9})]
        public void ArrayQuickort(int[] a, int[] b)
        {
            Console.WriteLine("Array before sorting ");
            foreach (int num in a)
                Console.Write(num + " ");

            Sort.QuickSort(a, 0, a.Length - 1);

            Console.WriteLine("\nArray after sorting ");
            foreach (int num in a)
                Console.Write(num + " ");

            Assert.AreEqual(b, a);
        }

        [Test]
        [TestCase(new[] {3, 2, 1}, "1 2 3")]
        [TestCase(new[] {9, 6, 7, 1, 3, 2, 5, 4, 8, 10}, "1 2 3 4 5 6 7 8 9 10")]
        [TestCase(new[] {9, 8, 7, 6, 5, 4, 1, 2, 3, 3, 6, 9, 2, 5, 8, 1, 4, 7}, "1 1 2 2 3 3 4 4 5 5 6 6 7 7 8 8 9 9")]
        public void LListQuickSort(int[] a, string b)
        {
            LinkedList list = new LinkedList();

            foreach (int num in a)
                list.AddLast(num);

            Console.WriteLine("Linked List before sorting ");
            Console.WriteLine(list);

            Sort.LinkedListQuickSort(list.Head, list.Tail);

            Console.WriteLine("Linked List after sorting");
            Console.WriteLine(list);

            Assert.AreEqual(b, list.ToString());
        }
    }
}