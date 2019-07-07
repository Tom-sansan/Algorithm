using System;
using System.Text;
using Ctci.Library;

namespace ExChapter01
{
    public class Q1_Exercise
    {
        private static void Rotate(int[][] matrix, int size)
        {
            for (int layer = 0; layer < size / 2; layer++)
            {
                var first = layer;
                var last = size - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    var offset = i - first;
                    var top = matrix[first][i];// save top
                    // top <- left
                    matrix[first][i] = matrix[last - offset][first];
                    // left <- bottom
                    matrix[last - offset][first] = matrix[last][last - offset];
                    // bottom <- right
                    matrix[last][last - offset] = matrix[i][last];
                    // right <- top
                    matrix[i][last] = top;
                }
            }
        }

    }
}