using System;
using System.Collections.Generic;

namespace StringMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "ACACAGA";
            var A = NextStateTable.GetDictionaryPattern(str);
            foreach (var item in A)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.WriteLine();
        }
    }
}
