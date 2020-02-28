namespace QuickSort_OnlyFile
{
    public class Sort
    {
        public static void QuickSort(ArrayEmulator arr, int start, int end)
        {
            if (start < end)
            {
                int i = Partition(arr, start, end);

                QuickSort(arr, start, i - 1);
                QuickSort(arr, i + 1, end);
            }
        }

        private static int Partition(ArrayEmulator arr, int start, int end)
        {
            int temp;
            int p = arr[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
                if (arr[j] <= p)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }

            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            return i + 1;
        }

      //----------------------
      /*
      static LinkedList.Node LListPartition(LinkedList.Node head, LinkedList.Node tail)
      {
          // set pivot as h element  
          int pivot = tail.Data;

          // similar to i = l-1 for array implementation  
          LinkedList.Node i = head.Prev;
          int temp;

          // Similar to "for (int j = l; j <= h- 1; j++)"  
          for (LinkedList.Node j = head; j != tail; j = j.Next)
              if (j.Data <= pivot)
              {
                  // Similar to i++ for array  
                  i = (i is null) ? head : i.Next;
                  temp = i.Data;
                  i.Data = j.Data;
                  j.Data = temp; //TODO make swap function
              }

          i = (i is null) ? head : i.Next; // Similar to i++  
          temp = i.Data;
          i.Data = tail.Data;
          tail.Data = temp;
          return i;
      }

     
      public static void LinkedListQuickSort(LinkedList.Node head, LinkedList.Node tail)
      {
          if (tail != null && head != tail && head != tail.Next)
          {
              LinkedList.Node temp = LListPartition(head, tail);
              LinkedListQuickSort(head, temp.Prev);
              LinkedListQuickSort(temp.Next, tail);
          }
      }
*/
    }
}