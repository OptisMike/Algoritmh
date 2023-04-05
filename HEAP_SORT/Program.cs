using System;

namespace HEAP_SORT
{
    public static class Heap_Sort
    {
        private static void SwapItemsArray(this int[] array, int first, int second)
        {
            (array[first], array[second]) = (array[second], array[first]);
        }
        private static void CheckParentAndChild(int[] array, int child)
        {
            int parent = (child - 1) / 2;

            while (child > 0 && array[child] < array[parent])
            {
                array.SwapItemsArray(child, parent);
                child = parent;
                parent = (child - 1) / 2;
            }
        }
        private static int[] CreateBinaryPyramid(int[] array)
        {
            int[] binaryPyramid = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                binaryPyramid[i] = array[i];
                CheckParentAndChild(binaryPyramid, i);
            }

            return binaryPyramid;
        }
        private static int ExtractMin(int[] array, int i)
        {
            int minItems = array[0];
            array[0] = array[^(i + 1)];

            DrownRootReсursion(array, i);

            return minItems;
        }
        private static void DrownRootReсursion(int[] array, int i, int parent = 0)
        {
            if (parent * 2 + 1 >= array.Length - 1 - i) return;

            int child_1 = parent * 2 + 1;
            int child_2 = (child_1 + 1) >= (array.Length - 1 - i) ? child_1 : child_1 + 1;
            int indexMinChild = array[child_1] <= array[child_2] ? child_1 : child_2;

            if (array[parent] > array[indexMinChild])
            {
                array.SwapItemsArray(parent, indexMinChild);

                DrownRootReсursion(array, i, indexMinChild);
            }
        }
        public static void HeapSort(this int[] array)
        {
            int[] heap = CreateBinaryPyramid(array);

            for (int i = 0; i < heap.Length; i++)
            {
                array[i] = ExtractMin(heap, i);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 16, 17, 11, 18, 8, 15, 10, 4, 14, 2 };
            A.HeapSort();
            Console.WriteLine(String.Join(", ", A));
        }
    }
}
