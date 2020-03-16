using System;
using QuickSort;
using System.Diagnostics;
using QuickSort_OnlyFile;
using Sort = QuickSort.Sort;

namespace SortSpeedTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            int i = int.Parse(args[0]);
            string t = args[1];
            if (t == "A")
            {
                var arr = GetRandomArrayFile(i);
                Console.WriteLine("Length: " + i + " Seconds: " + TestArrayFile(arr));
            }
            else if (t == "L")
            {
                var list = GetRandomListFile(i);
                Console.WriteLine("Length: " + i + " Seconds: " + TestListFile(list));
            }
        }

        static LinkedList GetRandomList(int length)
        {
            var list = new LinkedList();
            var random = new Random();
            for (int i = 0; i < length; i++)
                list.AddLast(random.Next(int.MinValue, int.MaxValue));

            return list;
        }

        static LinkedListEmulator GetRandomListFile(int length)
        {
            var list = new LinkedListEmulator("testlist.dat");
            var random = new Random();
            for (int i = 0; i < length; i++)
                list.AddLast(random.Next(int.MinValue, int.MaxValue));

            return list;
        }

        static int[] GetRandomArray(int length)
        {
            var arr = new int[length];
            var random = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = random.Next(int.MinValue, int.MaxValue);

            return arr;
        }

        static ArrayEmulator GetRandomArrayFile(int length)
        {
            var arr = new ArrayEmulator("testarray.dat", 4, length);
            var random = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = random.Next(int.MinValue, int.MaxValue);

            return arr;
        }

        static string TestArray(int[] arr)
        {
            var time = Stopwatch.StartNew();
            Sort.QuickSort(arr, 0, arr.Length - 1);
            time.Stop();
            return time.Elapsed.Minutes + "." + time.Elapsed.Seconds + "." + time.Elapsed.Milliseconds;
        }

        static string TestArrayFile(ArrayEmulator arr)
        {
            var time = Stopwatch.StartNew();
            QuickSort_OnlyFile.Sort.QuickSort(arr, 0, arr.Length - 1);
            time.Stop();
            return time.Elapsed.Minutes + "." + time.Elapsed.Seconds + "." + time.Elapsed.Milliseconds;
        }

        static string TestList(LinkedList list)
        {
            var time = Stopwatch.StartNew();
            Sort.LinkedListQuickSort(list.Head, list.Tail);
            time.Stop();
            return time.Elapsed.Minutes + "." + time.Elapsed.Seconds + "." + time.Elapsed.Milliseconds;
        }

        static string TestListFile(LinkedListEmulator list)
        {
            var time = Stopwatch.StartNew();
            QuickSort_OnlyFile.Sort.LinkedListQuickSort(list, list.Head, list.Tail);
            time.Stop();
            return time.Elapsed.Minutes + "." + time.Elapsed.Seconds + "." + time.Elapsed.Milliseconds;
        }
    }
}