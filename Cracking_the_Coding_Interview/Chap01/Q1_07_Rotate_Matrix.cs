using System;
using System.Text;
using Ctci.Library;

namespace ExChapter01
{
    public class Q1_07_Rotate_Matrix
    {
        private static void Rotate(int[][] matrix, int size)
        {
            for (int layer = 0; layer < size / 2; layer++)
            {
                var first = layer;
                var last = size - 1 - layer;
                for (var i = first; i < last; i++)
                {
                    var offset = i - first;
                    var top = matrix[first][i]; // save top
                    // left -> top
                    matrix[first][i] = matrix[last - offset][first];
                    // bottom -> left
                    matrix[last - offset][first] = matrix[last][last - offset];
                    // right -> bottom
                    matrix[last][last - offset] = matrix[i][last];
                    // top -> right
                    matrix[i][last] = top;  // right <- saved top
                }
            }
        }
        public static void Q1_07_Run()
        {
            int[] sizeList = {3,4};
            foreach (var size in sizeList)
            {
                var matrix = AssortedMethods.RandomMatrix(size, size, 0, 9);
                AssortedMethods.PrintMatrix(matrix);
                Rotate(matrix, size);
                Console.WriteLine();
                AssortedMethods.PrintMatrix(matrix);
            }
        }
    }
}