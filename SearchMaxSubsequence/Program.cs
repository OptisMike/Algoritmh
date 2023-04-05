using System;

namespace SearchMaxSubsequence
{
    class SubSeq
    {
        private static void ComputeArrayLCS(int[,] result, string str1, string str2)
        {
            for (int i = 1; i < result.GetLength(0); i++)
            {
                for (int j = 1; j < result.GetLength(1); j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                    {
                        result[i, j] = result[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        result[i, j] = result[i, j - 1] > result[i - 1, j] ? result[i, j - 1] : result[i - 1, j];
                    }

                }
            }
        }
        private static int[,] ArrayLCS(string str1, string str2)
        {
            int[,] result = new int[str1.Length + 1, str2.Length + 1];

            ComputeArrayLCS(result, str1, str2);

            return result;
        }
        private static string AssemblyLCS(string str1, string str2, int[,] array, int i, int j)
        {

            if (array[i, j] == 0) return "";

            if (str1[i - 1] == str2[j - 1]) return AssemblyLCS(str1, str2, array, (i - 1), (j - 1)) + str1[i - 1].ToString();

            if (array[i, j - 1] > array[i - 1, j]) return AssemblyLCS(str1, str2, array, i, (j - 1));

            if (array[i, j - 1] <= array[i - 1, j]) return AssemblyLCS(str1, str2, array, (i - 1), j);

            return "\tERROR in <AssemblyLCS>\t";
        }
        public static string LargeCountString(string str1, string str2)
        {
            int[,] array = ArrayLCS(str1, str2);

            return AssemblyLCS(str1, str2, array, str1.Length - 1, str2.Length - 1);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "я дома,а?";
            string str2 = "иди домой!";
            string str3 = SubSeq.LargeCountString(str1, str2);

            Console.WriteLine(str3);
        }
    }
}
