using System;
using Ctci.Library;

namespace ExChapter04
{
    public class Q4_02_Minimal_Tree
    {
        public static TreeNode Create(params int[] sortedArray)
        {
            return Create(sortedArray, 0, sortedArray.Length - 1);
        }

        private static TreeNode Create(int[] sortedArray, int left, int right)
        {
            if (left > right) return null;
            var mid = left + (right - left) / 2;
            var treeNode = new TreeNode(sortedArray[mid]);
            treeNode.SetLeftChild(Create(sortedArray, left, mid - 1));
            treeNode.SetRightChild(Create(sortedArray, mid + 1, right));
            return treeNode;
        }

        public static void Q04_02_Run_C()
        {
            var root = Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            BTreePrinter.Print(root);
        }

        public static void Q04_02_Run_J()
        {
            int[] array = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            // We needed this code for other files, so check out the code in the library
            TreeNodeJ root = TreeNodeJ.CreateMinimalBST(array);
            Console.WriteLine("Root? " + root.Data);
            Console.WriteLine("Created BST? " + root.IsBST());
            Console.WriteLine("Height: " + root.Height());
        }
    }
}