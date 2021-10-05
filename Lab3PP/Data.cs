using System;

namespace Lab3PP
{
    public class Data
    {
        private int N { get; }

        public Data(int n)
        {
            this.N = n;
        }

        public int[] InputVectorManually()
        {
            int[] vector = new int[N];

            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            }

            return vector;
        }

        public int[] GetVectorUsingRandom(int upperBound)
        {
            int[] vector = new int[N];
            Random random = new Random();
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = random.Next(upperBound);
            }

            return vector;
        }


        public int[] GetVectorFilledWithValue(int value)
        {
            int[] vector = new int[N];
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = value;
            }

            return vector;
        }

        public int[,] InputMatrixManually()
        {
            int[,] matrix = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                }
            }

            return matrix;
        }

        public int[,] GetMatrixUsingRandom()
        {
            int[,] matrix = new int[N, N];
            Random random = new Random();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    matrix[i, j] = random.Next(60);
                }
            }

            return matrix;
        }

        public int[,] GetMatrixFilledWithValue(int value)
        {
            int[,] matrix = new int[N, N];
            for (int i = 0; i < N; i++) { 
                for (int j = 0; j < N; j++) {
                    matrix[i, j] = value;
                }
            }
            return matrix;
        }


        private int[,] MultiplyMatrices(int[,] firstMatrix, int[,] secondMatrix)
        {
            //For matrix multiplication, the number of columns in the first matrix must be equal to the number of rows in the second matrix.
            int[,] result = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        result[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }

            return result;
        }

        //For multiplication, the number of columns in the first matrix must be equal to the number of rows in the second matrix
        private int[] VectorMultiplyByMatrix(int[] vector, int[,] matrix)
        {
            int[] result = new int[N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    result[i] += vector[j] * matrix[i, j];
                }
            }

            return result;
        }

        private int[] AddVectors(int[] firstVector, int[] secondVector)
        {
            //For addition, length of vectors must be equals
            if (firstVector.Length != N || secondVector.Length != N)
            {
                return null;
            }

            int[] result = new int[N];
            for (int i = 0; i < N; i++)
            {
                result[i] = firstVector[i] + secondVector[i];
            }

            return result;
        }

        private int[,] TransposeMatrix(int[,] matrix)
        {

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    (matrix[i, j], matrix[j, i]) = (matrix[j, i], matrix[i, j]);
                }
            }

            return matrix;
        }

        public int[] F1(int[] a, int[] c, int[,] ma, int[,] me, int[] b)
        {
            return AddVectors(AddVectors(a, VectorMultiplyByMatrix(c, MultiplyMatrices(ma, me))), b);
        }

        public int[,] F2(int[,] mk, int[,] mh, int[,] mf)
        {
            return MultiplyMatrices(TransposeMatrix(mk), MultiplyMatrices(mh, mf));
        }

        public int[] F3(int[] o, int[] p, int[,] mr, int[,] mt)
        {
            return VectorMultiplyByMatrix(AddVectors(o, p), TransposeMatrix(MultiplyMatrices(mr, mt)));
        }
    }
}