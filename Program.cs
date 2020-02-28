//#define ekranas

//#define linkedList // Jei sitas ijungtas tai skaito i linked list, jei uzkomentuotas tai i masyva

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace QuickSort
{
    internal class Program
    {
        public static void Main(string[] args)
        {
                 //Konvertuojame paveikslėlį if JPG į BMP
            var name = "dangus";
            Bitmap image = new Bitmap("dangus.jpg");
            image.Save(name + ".bmp", ImageFormat.Bmp);

            //BMP bylos nuskaitymas 
            using (FileStream file = new FileStream(name + ".bmp", FileMode.Open, FileAccess.Read))
            {
                byte[] b = new byte[file.Length];
                file.Read(b, 0, (int) file.Length);
                int plotis = BitConverter.ToInt32(b, 0x0012); //paveikslėlio plotis
                int aukštis = BitConverter.ToInt32(b, 0x0016); //paveikslėlio aukštis

                //Taškus verčiame į spalvų kodus
#if !linkedList
                int[] bs = new int[plotis * aukštis];
#else
                var bs = new LinkedList();
#endif
                int j = 54;
                for (int i = 0; i < plotis * aukštis; i++)
                {
#if !linkedList
                    bs[i] = (((b[j + 2] << 8) + b[j + 1]) << 8) + b[j];
#else
                    bs.AddLast((((b[j + 2] << 8) + b[j + 1]) << 8) + b[j]);
#endif
                    j += 3;
                }

#if ekranas
                ShowArray(bs, "Pries rikiavima");
#endif
                //Rikiuojame taškų kodus ir išvedame į bylą
                Sort.QuickSort(bs, 0, bs.Length - 1);
#if ekranas
                ShowArray(bs, "Po rikiavimo");
#endif
                j = 54;
                /*for (int i = 0; i < bs.Length; i++)
                {
                    byte[] p = BitConverter.GetBytes(bs[i]);
                    b[j] = p[0];
                    b[j + 1] = p[1];
                    b[j + 2] = p[2];
                    j += 3;
                }*/

                foreach (int number in bs)
                {
                    byte[] p = BitConverter.GetBytes(number);
                    b[j] = p[0];
                    b[j + 1] = p[1];
                    b[j + 2] = p[2];
                    j += 3;
                }

                using (FileStream file2 = new FileStream(name + "_surikiuota.bmp", FileMode.Create, FileAccess.Write))
                {
                    file2.Seek(0, SeekOrigin.Begin);
                    file2.Write(b, 0, b.Length);
                    file2.Close();
                }

                //
                file.Close();
        
            
        }

        }

        static void ShowArray(int[] bs, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Iveskite inkesus pradziai ir pabaigai:");
            string[] indexes = Console.ReadLine().Split();
            for (int i = int.Parse(indexes[0]); i < int.Parse(indexes[1]); i++)
                Console.Write(bs[i] + " ");
        }
    }
}