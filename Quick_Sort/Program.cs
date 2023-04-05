using System;

namespace Quick_Sort
{
    class Program
    {
        /* p - the first index to iter. array
         * r - the last index to iter. array
         * q - the last index of sorted part of array
         * u - index for iter. unsorted part of array */
        public static int Partition(int[] array, int p, int r)
        {
            int q = p;

            for (int u = p;  u < r;  u++)
            {
                if (array[u] <= array[r])
                {
                    (array[q], array[u]) = (array[u], array[q++]);
                }
            }

            (array[q], array[r]) = (array[r], array[q]);

            return q;
        }

        public static void QuickSort(int[] array, int p, int r)
        {
            if (p >= r) return;

            int q = Partition(array, p, r);

            QuickSort(array, p, q - 1);

            QuickSort(array, q + 1, r);
            
        }
        static void Main(string[] args)
        {
            int[] A = { 6, 3, 8, 1, 9, 5 };
            QuickSort(A, 0, A.Length - 1);
            Console.WriteLine(String.Join(", ", A));
        }
    }
}
