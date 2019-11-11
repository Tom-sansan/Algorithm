using System;
using Ctci.Library;


namespace ExChapter04
{
    public class Q4_04_Check_Balanced
    {

        public static int CheckHeight(TreeNodeJ root)
        {
            if (root == null) return -1;

            int leftHeight = CheckHeight(root.Left);
            if (leftHeight == int.MinValue) return int.MinValue;    // Propagate error up

            int rightHeight = CheckHeight(root.Right);
            if (rightHeight == int.MinValue) return int.MinValue;   // Propagate error up

            int heigthDiff = leftHeight - rightHeight;
            if (Math.Abs(heigthDiff) > 1) return int.MinValue;      // Found error -> pass it back
            else return Math.Max(leftHeight, rightHeight) + 1;
        }

        public static bool IsBalancedImproved(TreeNodeJ root)
        {
            return CheckHeight(root) != int.MinValue;
        }

        public static int GetHeight(TreeNodeJ root)
        {
            if (root == null) return -1;
            return Math.Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;
        }

        public static bool IsBalanced(TreeNodeJ root)
        {
            if (root == null) return true;

            int heightDiff = GetHeight(root.Left) - GetHeight(root.Right);
            if (Math.Abs(heightDiff) > 1) return false;
            else return IsBalanced(root.Left) && IsBalanced(root.Right);
        }

        public static void Q04_04_Run_J()
        {
            // Create balanced tree
            int[] array = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            TreeNodeJ root = TreeNodeJ.CreateMinimalBST(array);
            Console.WriteLine("Root? " + root.Data);
            Console.WriteLine("Is balanced? " + IsBalanced(root));
            
            // Could be balanced, actually, but it's very unlikely...
            TreeNodeJ unbalanced = new TreeNodeJ(10);
            for (int i = 0; i < 10; i++)
                unbalanced.InsertInOrder(AssortedMethods.RandomIntInRange(0, 100));
            Console.WriteLine("Root? " + unbalanced.Data);
            Console.WriteLine("Is balanced? " + IsBalanced(unbalanced));

            Console.WriteLine("Is balanced? " + IsBalancedImproved(root));
            root.InsertInOrder(4);  // Add 4 to make it unbalanced.
            Console.WriteLine("Is balanced? " + IsBalancedImproved(root));
        }

        /* For Debug parameters
        root
        r
        i.Current.Data
        i.Current
        Math.Max(GetHeight(root.Left), GetHeight(root.Right))
        GetHeight(root.Left)
        GetHeight(root.Right)
        Math.Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;
        root.Data
        root.Left.Data
        root.Right.Data
        IsBalanced(root.Left)
        IsBalanced(root.Right)
        Math.Max(leftHeight, rightHeight) + 1
        CheckHeight(root)
        CheckHeight(root) != int.MinValue
        */
    }
}