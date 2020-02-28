using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using QuickSort;

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
        public ArrayEmulator(string fileName, int size = sizeof(int))
        {
            this.elementSize = size;
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
            get => GetNumber(index);
            set => SetNumber(index, value);
        }

        private int GetNumber(int i)
        {
            int k = i * elementSize;
            br.BaseStream.Seek(k, SeekOrigin.Begin);
            return br.ReadInt32();
        }

        // priskiriame i-tajam elementui nauja reiksme
        private void SetNumber(int i, int value)
        {
            int k = i * elementSize;
            bw.BaseStream.Seek(k, SeekOrigin.Begin);
            bw.Write(value);
        }

        public void Dispose() => fn.Close();

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}