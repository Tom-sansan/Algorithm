using System;
using Ctci.Library;

namespace ExChapter04
{
    public class Q4_06_Successor
    {
        public static TreeNodeJ InorderSucc(TreeNodeJ n)
        {
            if (n == null) return null;
            // Found right children -> return left most node of right subtree
            if (n.Parent == null || n.Right != null) return LeftMostChild(n.Right);
            else
            {
                TreeNodeJ node = n;
                TreeNodeJ parent = node.Parent;
                // Go up until we're on left instead of right
                while (parent != null && parent.Left != node)
                {
                    node = parent;
                    parent = parent.Parent;
                }
                return parent;
            }
        }

        public static TreeNodeJ LeftMostChild(TreeNodeJ n)
        {
            if (n == null) return null;
            while (n.Left != null) n = n.Left;
            return n;
        }

        public static void Q04_06_Run_J()
        {
            int[] array = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            TreeNodeJ root = TreeNodeJ.CreateMinimalBST(array);
            for (int i = 0; i < array.Length; i++)
            {
                TreeNodeJ node = root.Find(array[i]);
                TreeNodeJ next = InorderSucc(node);
                if (next != null) Console.WriteLine(node.Data + "->" + next.Data);
                else Console.WriteLine(node.Data + "->" + null);
            }

            /* For Debug parameters
            i
            d
            this.Data
            this.Left.Data
            this.Right.Data
            array[i]
            node.Data
            next.Data
            n.Data
            n.Parent.Data
            n.Left.Data
            n.Right.Data
            node.Data
            node.Parent.Data
            parent.Data
            parent.Parent.Data
            parent.Left.Data
            parent.Left != node
            */
        }
    }
}