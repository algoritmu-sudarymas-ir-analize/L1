using System.Collections.Generic;

namespace QuickSort
{
    public class Spiral
    {
        public static IEnumerable<int> SpiralOrder(int[] arr, int y, int x)
        {
            int[,] buffer = new int[y, x];
            int top = 0, bottom = y - 1;
            int left = 0, right = x - 1;

            int index = 0;

            while (true)
            {
                if (left > right)
                    break;

                // print top row
                for (int i = left; i <= right; i++)
                    buffer[top, i] = arr[arr.Length - 1 - index++];

                top++;

                if (top > bottom)
                    break;

                // print right column
                for (int i = top; i <= bottom; i++)
                    buffer[i, right] = arr[arr.Length - 1 - index++];

                right--;

                if (left > right)
                    break;

                // print bottom row
                for (int i = right; i >= left; i--)
                    buffer[bottom, i] = arr[arr.Length - 1 - index++];

                bottom--;

                if (top > bottom)
                    break;

                // print left column
                for (int i = bottom; i >= top; i--)
                    buffer[i, left] = arr[arr.Length - 1 - index++];

                left++;
            }

            foreach (int i in buffer)
                yield return i;
        }
    }
}