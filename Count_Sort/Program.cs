using System;
using System.Linq;

namespace Count_Sort
{
    class Program
    {
        /* n = array.Lenght
         * m = max(array)
         */
        public static int[] CountKeysEqual(int[] array, int n, int m)
        {
            int[] equal = new int[m];

            for (int i = 0; i < n; i++)
            {
                equal[array[i]]++;
            }

            return equal;
        }
        public static int[] CountKeyLess(int[] equal, int m)
        {
            int[] less = new int[m];

            for (int j = 1; j < m; j++)
            {
                less[j] = less[j - 1] + equal[j - 1];
            }

            return less;
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

            
            int[] equal = CountKeysEqual(array, n, m);

            int[] less = CountKeyLess(equal, m);

            int[] result = Rearrange(array, less, n, m);

            result.CopyTo(array, 0);
        }
            static void Main(string[] args)
        {
            int[] A = { 4, 1, 5, 0, 1, 6, 5, 1, 5, 3 };

            CountingSort(A);

            Console.WriteLine(String.Join(", ", A));
        }
    }
}
