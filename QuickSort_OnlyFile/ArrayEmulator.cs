using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace QuickSort_OnlyFile
{
    /// <summary>
    ///     Very magic class which lets to fake an array but actually its a file
    /// </summary>
    public class ArrayEmulator : IDisposable, IEnumerable<int>
    {
        private readonly BinaryReader br;
        private readonly BinaryWriter bw;
        private readonly FileStream fn;
        public int Length { get; private set; }

        private int elementSize;

        /// <param name="elementSize"> element size in bytes.</param>
        /// <param name="initialLength"> Just like declaring an array you specify total size.</param>
        public ArrayEmulator(string fileName, int size = sizeof(int), int initialLength = 0)
        {
            elementSize = size;
            Length = initialLength;

            fn = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            bw = new BinaryWriter(fn);
            br = new BinaryReader(fn);
        }

        public void Add(int element)
        {
            bw.Write(element);
            Length++;
        }

        // this is where the magic happens :)
        public int this[int index]
        {
            get
            {
                br.BaseStream.Seek(index * elementSize, SeekOrigin.Begin);
                return br.ReadInt32();
            }
            set
            {
                bw.BaseStream.Seek(index * elementSize, SeekOrigin.Begin);
                bw.Write(value);
            }
        }

        public void Dispose() => fn.Close();

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int[] ToArray()
        {
            int[] arr = new int[Length];
            var en = GetEnumerator();
            for (int i = 0; i < Length; i++)
            {
                arr[i] = en.Current;
                en.MoveNext();
            }

            return arr;
        }
    }
}