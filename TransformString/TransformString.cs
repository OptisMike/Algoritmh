using System;
using System.Collections.Generic;
using System.Text;

namespace TransformString
{
    public class TransformString
    {
        public static (int[,], string[,]) ComputeTransformTables(string X, string Y, int Cc = -1, int Cr = 1, int Cd = 2, int Cl = 2)
        {
            int m = X.Length + 1;
            int n = Y.Length + 1;
            int[,] cost = new int[m, n];
            string[,] op = new string[m, n];
            

            for (int i = 1; i < m; i++)
            {
                cost[i, 0] = i * Cd;
                op[i, 0] = $"del {X[i - 1]}";
            }

            for (int j = 1; j < n; j++)
            {
                cost[0, j] = j * Cl;
                op[0, j] = $"ins {Y[j - 1]}     ";
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (X[i - 1] == Y[j - 1])
                    {
                        cost[i, j] = cost[i - 1, j - 1] + Cc;
                        op[i, j] = $"copy {X[i - 1]}";
                    }
                    else
                    {
                        cost[i, j] = cost[i - 1, j - 1] + Cr;
                        op[i, j] = $"rep {X[i - 1]} by {Y[j - 1]}";
                    }
                    if (cost[i - 1, j]+ Cd < cost[i, j])
                    {
                        cost[i, j] = cost[i - 1, j] + Cd;
                        op[i, j] = $"del {X[i - 1]}";
                    }
                    if (cost[i, j - 1] + Cl < cost[i, j])
                    {
                        cost[i, j] = cost[i, j - 1] + Cl;
                        op[i, j] = $"ins {Y[j - 1]}";
                    }
                }
            }

            return (cost, op);
        }

        public static string AssemleTrans(string[,] op, int i = -1, int j = -1)
        {
            if (i == 0 && j == 0) return "start transf";

            if (i == -1 || j == -1) return AssemleTrans(op, op.GetLength(0) - 1, op.GetLength(1) - 1);

            string oper = op[i, j][..2];

            if (oper == "co" || oper == "re") return AssemleTrans(op, i - 1, j - 1) + ", " + op[i, j];

            if (oper == "de") return AssemleTrans(op, i - 1, j) + ", " + op[i, j];

            if (oper == "in") return AssemleTrans(op, i, j - 1) + ", " + op[i, j];

            return "Error AssemleTransformation";
            
        }
    }
}
