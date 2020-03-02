//#define masyvu_isvedimas

//#define linkedList
#define array

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
#if array
                int[] bs = new int[plotis * aukštis]; //<--masyvas
#endif
#if linkedList
                var bsLinked = new LinkedList(); //<--Linked List
#endif

                int j = 54;
                for (int i = 0; i < plotis * aukštis; i++)
                {
#if array
                    bs[i] = (((b[j + 2] << 8) + b[j + 1]) << 8) + b[j]; //<-- masyvas
#endif
#if linkedList
                    bsLinked.AddLast((((b[j + 2] << 8) + b[j + 1]) << 8) + b[j]); //<-- Linked List
#endif
                    j += 3;
                }


#if masyvu_isvedimas
                Show(bs, "Pries rikiavima");
#endif
#if array
                Sort.QuickSort(bs, 0, bs.Length - 1); //<-- rikiuojam masyva
#endif
#if linkedList
                Sort.LinkedListQuickSort(bsLinked.Head, bsLinked.Tail); //<-- rikiuojam Linked List
#endif
#if masyvu_isvedimas
                Show(bs, "Po rikiavimo");
#endif

#if linkedList
                byte[] bLinked = (byte[]) b.Clone(); // kopija Linked Listo failui
#endif
#if array
                int sappa = 0;
                // paruosiam surikiuota nuotrauka is masyvo
                j = 54;
                foreach (int number in Spiral.SpiralOrder(bs, aukštis, plotis))
                {
                    byte[] p = BitConverter.GetBytes(number);
                    if (sappa < 10)
                    {
                        Console.WriteLine(p[0] + " " + p[1] + " " + p[1]);
                        sappa++;
                    }

                    b[j] = p[0];
                    b[j + 1] = p[1];
                    b[j + 2] = p[2];
                    j += 3;
                }
                //--
#endif
#if linkedList
                // paruosiam surikiuota nuotrauka is Linked Listo
                j = 54;
                foreach (int number in Spiral.SpiralOrder(bsLinked.ToArray(), aukštis, plotis))
                {
                    byte[] p = BitConverter.GetBytes(number);
                    bLinked[j] = p[0];
                    bLinked[j + 1] = p[1];
                    bLinked[j + 2] = p[2];
                    j += 3;
                }
                //--
#endif
#if array
                using (FileStream file2 = new FileStream(name + "_surikiuota.bmp", FileMode.Create, FileAccess.Write))
                {
                    file2.Seek(0, SeekOrigin.Begin);
                    file2.Write(b, 0, b.Length);
                    file2.Close();
                }
#endif
#if linkedList
                using (FileStream file3 = new FileStream(name + "_surikiuota_LinkedList.bmp", FileMode.Create,
                    FileAccess.Write))
                {
                    file3.Seek(0, SeekOrigin.Begin);
                    file3.Write(bLinked, 0, bLinked.Length);
                    file3.Close();
                }
#endif
            }
        }

        static void Show(int[] bs, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Iveskite inkesus pradziai ir pabaigai:");
            string[] indexes = Console.ReadLine().Split();

            for (int i = int.Parse(indexes[0]); i <= int.Parse(indexes[1]); i++)
                Console.Write(bs[i] + " ");
        }
    }
}