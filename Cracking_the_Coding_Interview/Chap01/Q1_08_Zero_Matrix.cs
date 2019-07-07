using System;
using Ctci.Library;

namespace ExChapter01
{
    public class Q1_08_Zero_Matrix
    {
        private static void NullifyRow(int[][] matrix, int row)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                matrix[row][j] = 0;
            }
        }

        private static void NullifyColumn(int[][] matrix, int col)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i][col] = 0;
            }
        }
        private static int[][] CloneMatrix(int[][] matrix)
        {
            var clone = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                clone[i] = new int[matrix[0].Length];
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    clone[i][j] = matrix[i][j];
                }
            }
            return clone;
        }

        private static bool MatricesAreEqual(int[][] matrix1, int[][] matrix2)
        {
            if (matrix1.Length != matrix2.Length || matrix1[0].Length != matrix2[0].Length) return false;
            for (int i = 0; i < matrix1.Length; i++)
            {
                for (int j = 0; j < matrix1[0].Length; j++)
                {
                    if (matrix1[i][j] != matrix2[i][j]) return false;
                }
            }
            return true;
        }
        private static void SetZeros1(int[][] matrix)
        {
            var row = new bool[matrix.Length];
            var column = new bool[matrix[0].Length];
            // Store the row and column index with value 0
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        row[i] = true;
                        column[j] = true;
                    }
                }
            }

            // Nullify rows
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i]) NullifyRow(matrix, i);
            }
            // Nullify columns
            for (int j = 0; j < column.Length; j++)
            {
                if (column[j]) NullifyColumn(matrix, j);
            }
        }

        private static void SetZeros2(int[][] matrix)
        {
            var rowHasZero = false;
            var colHasZero = false;
            // Check if first row has a zero.
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                {
                    rowHasZero = true;
                    break;
                }
            }
            // Check if first column has a zero.
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    colHasZero = true;
                    break;
                }
            }

            // Check for zeros in the rest of the array
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            // Nullify rows based on values in the first column
            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0) NullifyRow(matrix, i);
            }
            // Nullify columns based on values in the first row
            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0) NullifyColumn(matrix, j);
            }
            // Nullify first row
            if (rowHasZero) NullifyRow(matrix, 0);
            // Nullify first column
            if (colHasZero) NullifyColumn(matrix, 0);
        }

        public static void Q1_08_Run()
        {
            
            const int numberOfRows = 10;
            const int numberOfColumns = 15;
            var matrix1 = AssortedMethods.RandomMatrix(numberOfRows, numberOfColumns, 0, 100);
            var matrix2 = CloneMatrix(matrix1);

            AssortedMethods.PrintMatrix(matrix1);

            SetZeros1(matrix1);
            SetZeros2(matrix2);

            Console.WriteLine();

            AssortedMethods.PrintMatrix(matrix1);
            Console.WriteLine();
            AssortedMethods.PrintMatrix(matrix2);

            Console.WriteLine(MatricesAreEqual(matrix1, matrix2) ? "Equal" : "Not Equal");
            
        }
    }
}