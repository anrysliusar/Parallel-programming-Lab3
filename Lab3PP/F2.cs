using System;
using System.Threading;

namespace Lab3PP 
{
    public class F2
    {
        private Data data;

        public F2(Data data)
        {
            this.data = data;
        }

        public void Run()
        {

            Console.WriteLine("F2 started");

            int[,] MK = data.GetMatrixFilledWithValue(1);
            int[,] MH = data.GetMatrixFilledWithValue(1);
            int[,] MF = data.GetMatrixFilledWithValue(1);

            int[,] result = data.F2(MK, MH, MF);
            Thread.Sleep(1000);
            Console.WriteLine($"Result of F2: ");
            Console.WriteLine(MatrixToString(result));
            Console.WriteLine("F2 has finished\n");

        }

        private String MatrixToString(int[,] matrix)
        {
            var result = string.Empty;

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                result += "{";
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    result += $"{matrix[i, j]}, ";
                }

                result += "},\n";

            }
            return result.Replace(", }", "}").Trim();
        }
    }
}