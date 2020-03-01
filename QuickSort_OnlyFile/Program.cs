//#define array
#define linkedList

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace QuickSort_OnlyFile
{
    internal class Program
    {
        public static void Main(string[] args)
        {
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
#if array
                //Taškus verčiame į spalvų kodus
                ArrayEmulator bs = new ArrayEmulator("bs.txt"); //<--netikras masyvas (failas)
#endif
#if linkedList
                LinkedListEmulator bsLinked = new LinkedListEmulator("bsLinked.txt");
#endif

                int j = 54;
                for (int i = 0; i < plotis * aukštis; i++)
                {
#if array
                    bs.Add((((b[j + 2] << 8) + b[j + 1]) << 8) + b[j]); //<-- netikras masyvas (failas)
#endif
#if linkedList
                    bsLinked.AddLast((((b[j + 2] << 8) + b[j + 1]) << 8) + b[j]); //<-- netikras LinkedList (failas)
#endif
                    j += 3;
                }

#if array
                Sort.QuickSort(bs, 0, bs.Length - 1);
#endif
#if linkedList
                Sort.LinkedListQuickSort(bsLinked, bsLinked.Head, bsLinked.Tail);
                byte[] bLinked = (byte[]) b.Clone(); // kopija Linked Listo failui
#endif

#if array
                // paruosiam surikiuota nuotrauka is masyvo
                j = 54;
                foreach (int number in QuickSort.Spiral.SpiralOrder(bs.ToArray(), aukštis, plotis))
                {
                    byte[] p = BitConverter.GetBytes(number);
                    b[j] = p[0];
                    b[j + 1] = p[1];
                    b[j + 2] = p[2];
                    j += 3;
                }

                //--
                bs.Dispose();
#endif

#if linkedList
                // paruosiam surikiuota nuotrauka is LinkedListo
                j = 54;
                foreach (int number in QuickSort.Spiral.SpiralOrder(bsLinked.ToArray(), aukštis, plotis))
                {
                    byte[] p = BitConverter.GetBytes(number);
                    bLinked[j] = p[0];
                    bLinked[j + 1] = p[1];
                    bLinked[j + 2] = p[2];
                    j += 3;
                }

                //--
                bsLinked.Dispose();
#endif

#if array
                using (FileStream file2 = new FileStream(name + "_surikiuota.bmp", FileMode.Create, FileAccess.Write))
                {
                    file2.Seek(0, SeekOrigin.Begin);
                    file2.Write(b, 0, b.Length);
                }
#endif

#if linkedList
                using (FileStream file3 = new FileStream(name + "_surikiuota_LinkedList.bmp", FileMode.Create,
                    FileAccess.Write))
                {
                    file3.Seek(0, SeekOrigin.Begin);
                    file3.Write(bLinked, 0, b.Length);
                }
#endif
            }
        }
    }
}