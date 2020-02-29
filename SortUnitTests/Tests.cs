using System;
using System.IO;
using System.Net;
using NUnit.Framework;
using QuickSort;
using QuickSort_OnlyFile;


namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(new[] {3, 2, 1}, new[] {1, 2, 3})]
        [TestCase(new[] {9, 6, 7, 1, 3, 2, 5, 4, 8, 10}, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10})]
        [TestCase(new[] {9, 8, 7, 6, 5, 4, 1, 2, 3, 3, 6, 9, 2, 5, 8, 1, 4, 7}, new[] {1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9})]
        public void ArrayQuickSort(int[] a, int[] b)
        {
            Console.WriteLine("Array before sorting ");
            foreach (int num in a)
                Console.Write(num + " ");

            QuickSort.Sort.QuickSort(a, 0, a.Length - 1);

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

            QuickSort.Sort.LinkedListQuickSort(list.Head, list.Tail);

            Console.WriteLine("Linked List after sorting");
            Console.WriteLine(list);

            Assert.AreEqual(b, list.ToString());
        }

        [Test]
        [TestCase(new[] {3, 2, 1}, new[] {1, 2, 3})]
        [TestCase(new[] {9, 6, 7, 1, 3, 2, 5, 4, 8, 10}, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10})]
        [TestCase(new[] {9, 8, 7, 6, 5, 4, 1, 2, 3, 3, 6, 9, 2, 5, 8, 1, 4, 7}, new[] {1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9})]
        public void ArrayEmulatorSort(int[] a, int[] b)
        {
            var arr = new ArrayEmulator("for_test.txt");
            for (int i = 0; i < a.Length; i++)
                arr.Add(a[i]);

            Assert.AreEqual(a.Length, arr.Length);
            Console.WriteLine("in Array  in Emulator");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"{a[i],8}  {arr[i],-8}");
                Assert.AreEqual(a[i], arr[i]);
            }

            QuickSort_OnlyFile.Sort.QuickSort(arr, 0, arr.Length - 1);

            Console.WriteLine("After Sort\nin Array  in Emulator");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"{b[i],8}  {arr[i],-8}");
                Assert.AreEqual(b[i], arr[i]);
            }

            arr.Dispose();
            File.Delete("for_test.txt");
        }
        
    }
}