using System;
using System.Collections.Generic;
using System.Text;

namespace StringMatcher
{
    public static class NextStateTable
    {
        public static Dictionary<string, int> GetDictionaryPattern(string pattern)
        {
            var result = new Dictionary<string, int>();

            for (int i = 0; i < pattern.Length; i++)
            {
                result[pattern[i].ToString()] = i;
            }

            return result;
        }
        public static void FiniteStateTable(int[,] array, string pattern)
        {
            int m = array.GetLength(0);
            int n = array.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i < m - 1) && pattern[..i] + pattern[j] == pattern[..(i + 1)])
                    {
                        array[i, j] = i + 1;
                    }
                    else
                    {
                        for (int k = 1; k < i + 1; k++)
                        {
                            if (pattern[..(i - k + 1)] == pattern[k..i] + pattern[j])
                            {
                                array[i, j] = pattern[..(i - k + 1)].Length;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
