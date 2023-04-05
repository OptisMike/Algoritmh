using System;
using System.Linq;

namespace Count_Sort
{
    class Program
    {
        /* n = array.Lenght
         * m = max(array)
         */
        public static void CountKeysEqual(int[] array, int[] equal, int n, int m)
        {
            for (int i = 0; i < n; i++) 
                equal[array[i]]++;
        }

        public static void CountKeyLess(int[] equal, int m)
        {
            int lastEqual = equal[0];
            equal[0] = 0;

            for (int j = 1; j < m; j++)
                (lastEqual, equal[j]) = (equal[j], lastEqual + equal[j - 1]);
        }

        public static int[] Rearrange(int[] array, int[] less, int n, int m)
        {
            int[] resultArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                resultArray[less[array[i]]] = array[i];
                less[array[i]]++;
            }
            return resultArray;
        }

        public static void CountingSort(int[] array)
        {
            int n = array.Length;
            int m = array.Max() + 1;
            int[] equal = new int[m];

            CountKeysEqual(array, equal, n, m);
            CountKeyLess(equal, m);
            Rearrange(array, equal, n, m).CopyTo(array, 0);
        }
        static void Main(string[] args)
        {
            int[] A = { 4, 1, 5, 0, 1, 6, 5, 1, 5, 3 };

            CountingSort(A);
            Console.WriteLine(String.Join(", ", A));
        }
    }
}
