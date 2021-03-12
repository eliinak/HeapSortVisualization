using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSortVisualization
{
    public static class HeapSort
    {
        public static void Heapify(List<int>arr, int n, int i)
        {
            int smallest = i; 
            int l = 2 * i + 1; 
            int r = 2 * i + 2; 
            if (l < n && arr[l] < arr[smallest])
                smallest = l;

            if (r < n && arr[r] < arr[smallest])
                smallest = r;

            if (smallest != i)
            {
                int temp = arr[i];
                arr[i] = arr[smallest];
                arr[smallest] = temp;

                Heapify(arr, n, smallest);
            }
        }

        public static List<int> SortHeap(List<int> arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);

            for (int i = n - 1; i >= 0; i--)
            {

                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(arr, i, 0);
            }
            return arr.ToList();
        }
    }
}
