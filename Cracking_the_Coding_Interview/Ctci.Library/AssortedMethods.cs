using System;
using System.Text;
using System.Collections.Generic;

namespace Ctci.Library
{
    public class AssortedMethods
    {
        private static readonly Random RandomIntNumbers = new Random();
        public static int RandomInt(int n)
        {
            return RandomIntNumbers.Next(n);
        }

        public static int RandomIntInRange(int min, int max)
        {
            return RandomInt(max + 1 - min) + min;
        }

        public static bool RandomBoolean()
        {
            return RandomIntInRange(0, 1) == 0;
        }

        public static bool RandomBoolean(int percentTrue)
        {
            return RandomIntInRange(1, 100) <= percentTrue;
        }
        public static int[][] RandomMatrix(int m, int n, int min, int max)
        {
            int[][] matrix = new int[m][];
            for (int i = 0; i < m; i++)
            {
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = RandomIntInRange(min, max);
                }
            }
            return matrix;
        }

        public static LinkedListNode RandomLinkedList(int n, int min, int max)
        {
            LinkedListNode root = new LinkedListNode(RandomIntInRange(min, max), null, null);
            LinkedListNode prev = root;
            for (int i = 0; i < n; i++)
            {
                int data =  RandomIntInRange(min, max);
                LinkedListNode next = new LinkedListNode(data, null, null);
                prev.SetNext(next);
                prev = next;
            }
            return root;
        }

        public static string ArrayToString(int[] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int v in array)
            {
                sb.AppendFormat("{0}, ", v);
            }
            return sb.ToString();
        }

        public static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < 10  && matrix[i][j] > -10)  Console.Write(" ");
                    if (matrix[i][j] < 100 && matrix[i][j] > -100) Console.Write(" ");
                    if (matrix[i][j] >= 0) Console.Write(" ");
                    Console.Write("" + matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

        public static void PrintIntArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("");
        }

        public static LinkedListNode CreateLinkedListFromArray(int[] vals)
        {
            LinkedListNode head = new LinkedListNode(vals[0], null, null);
            LinkedListNode current = head;
            for (int i = 1; i < vals.Length; i++)
            {
                current = new LinkedListNode(vals[i], null, current);
            }
            return head;
        }

        public static TreeNodeJ RandomBST(int N, int min, int max)
        {
            int d = RandomIntInRange(min, max);
            TreeNodeJ root = new TreeNodeJ(d);
            for (int i = 1; i < N; i++)
            {
                root.InsertInOrder(RandomIntInRange(min, max));
            }
            return root;
        }

        // Creates tree by mapping the array left to right, top to bottom.
        public static TreeNodeJ CreateTreeFromArray(int[] array)
        {
            if (array.Length > 0)
            {
                TreeNodeJ root = new TreeNodeJ(array[0]);
                Queue<TreeNodeJ> queue = new Queue<TreeNodeJ>();
                queue.Enqueue(root);
                bool done = false;
                int i = 1;
                while (!done)
                {
                    TreeNodeJ r = (TreeNodeJ)queue.Peek();
                    if (r.Left == null)
                    {
                        r.Left = new TreeNodeJ(array[i]);
                        i++;
                        queue.Enqueue(r.Left);
                    }
                    else if (r.Right == null)
                    {
                        r.Right = new TreeNodeJ(array[i]);
                        i++;
                        queue.Enqueue(r.Right);
                    }
                    else queue.Dequeue();

                    if (i == array.Length) done = true;
                }
                return root;
            }
            else return null;
        }
    }
}