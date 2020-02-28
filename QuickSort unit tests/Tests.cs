using System;
using NUnit.Framework;
using QuickSort;

namespace QuickSort_unit_tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void QuicsortArrayTest()
        {
            int[] arr = {9, 6, 7, 1, 3, 2, 5, 4, 8, 10};
            Sort.QuickSort(arr, 0, arr.Length - 1);

            Assert.AreEqual(arr, new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
        }

        [Test]
        public void Test2()
        {
            Assert.True(true);
        }
    }
}