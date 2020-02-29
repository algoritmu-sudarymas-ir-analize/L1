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


        static int LListPartition(LinkedListEmulator list, int head, int tail)
        {
            // set pivot as h element  
            int pivot = list.GetNodeData(tail);

            // similar to i = l-1 for array implementation  
            int i = list.GetPrevAdress(head);
            int temp;

            // Similar to "for (int j = l; j <= h- 1; j++)"  
            for (int j = head; j != tail; j = list.GetNextAdress(j))
                if (list.GetNodeData(j) <= pivot)
                {
                    // Similar to i++ for array  
                    i = (i == -1) ? head : list.GetNextAdress(i);
                    temp = list.GetNodeData(i);
                    list.SetNodeData(i, list.GetNodeData(j));
                    list.SetNodeData(j, temp);
                    //TODO make swap function
                }

            i = (i == -1) ? head : list.GetNextAdress(i); // Similar to i++  
            temp = list.GetNodeData(i);
            list.SetNodeData(i, list.GetNodeData(tail));
            list.SetNodeData(tail, temp);
            return i;
        }


        public static void LinkedListQuickSort(LinkedListEmulator list, int head, int tail)
        {
            if (tail != -1 && head != tail && head != list.GetNextAdress(tail))
            {
                int temp = LListPartition(list, head, tail);
                LinkedListQuickSort(list, head, list.GetPrevAdress(temp));
                LinkedListQuickSort(list,list.GetNextAdress(temp), tail);
            }
        }
    }
}