using System;

namespace TransformString
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] cost;
            string[,] op;
            (cost, op) = TransformString.ComputeTransformTables("adsfqwdqwf", "qwdqwd");

            Console.WriteLine(TransformString.AssemleTrans(op));
        }
    }
}
