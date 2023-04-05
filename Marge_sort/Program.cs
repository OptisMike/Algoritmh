using System;

namespace Marge_sort
{
    class Program
    {
        public static int[] CopyArrayWithFlag(int[] array, int startIter, int endIter, int flag = 999, int flagToFirstArray = 0)
        {
            int copyEndIter = endIter - startIter + (1 - flagToFirstArray);
            int[] copyArray = new int[copyEndIter + 1];

            array[(startIter + flagToFirstArray)..(endIter + 1)].CopyTo(copyArray, 0);
            copyArray[copyEndIter] = flag;

            return copyArray;
        }

        public static void Merge(int[] arrayNum, int startArr, int middleArr, int endArr, int i = 0, int j = 0)
        {
            int[] copyArray_1 = CopyArrayWithFlag(arrayNum, startArr, middleArr);
            int[] copyArray_2 = CopyArrayWithFlag(arrayNum, middleArr, endArr, flagToFirstArray: 1);

            for (int k = startArr; k < endArr + 1; k++)
                arrayNum[k] = copyArray_1[i] <= copyArray_2[j] ? copyArray_1[i++] : arrayNum[k] = copyArray_2[j++];
        }

        public static void MergeSort(int[] arrayNum, int startArr, int endArr)
        {
            if (startArr == endArr) return;

            int middleArr = (startArr + endArr) / 2;

            MergeSort(arrayNum, startArr, middleArr);
            MergeSort(arrayNum, middleArr + 1, endArr);
            Merge(arrayNum, startArr, middleArr, endArr);
        }
        static void Main(string[] args)
        {
            int[] A = { 5, 1, 8, 2, 88, 3 };
            MergeSort(A, 0, A.Length - 1);
            Console.WriteLine(String.Join(", ", A));

        }
    }
}
