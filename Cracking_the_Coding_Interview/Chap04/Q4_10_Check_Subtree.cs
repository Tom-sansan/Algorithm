using System;
using System.Text;
using Ctci.Library;

namespace ExChapter04
{
    public class Q4_10_Check_Subtree
    {

#region QuestionA

        public class QuestionA
        {
            public static void GetOrderString(TreeNodeJ nodeJ, StringBuilder sb)
            {
                if (nodeJ == null)
                {
                    sb.Append("X");                 // Add null indicator
                    return;
                }
                sb.Append(nodeJ.Data);              // Add root
                GetOrderString(nodeJ.Left, sb);     // Add left
                GetOrderString(nodeJ.Right, sb);    // Add right
            }
            public static bool ContainsTree(TreeNodeJ t1, TreeNodeJ t2)
            {
                var sb1 = new StringBuilder();
                var sb2 = new StringBuilder();
                
                GetOrderString(t1, sb1);
                GetOrderString(t2, sb2);
                return sb1.ToString().IndexOf(sb2.ToString()) != -1;
            }

            public static void ContainsTree(TreeNodeJ t1, TreeNodeJ t2, TreeNodeJ t3, TreeNodeJ t4)
            {
                var result1 = ContainsTree(t1, t2);
                var result2 = ContainsTree(t3, t4);
                WriteResult(result1, result2);
            }
        }

#endregion QuestionA

#region  QuestionB
        public class QuestionB
        {
            /* Checks if the binary tree rooted at r1 contains the 
             * binary tree rooted at r2 as a subtree starting at r1.
             */
             public static bool MatchTree(TreeNodeJ r1, TreeNodeJ r2)
             {
                 if (r1 == null && r2 == null) return true;         // nothing left in the subtree
                 else if (r1 == null || r2 == null) return false;   // exactly one tree is empty, therefore trees don't match
                 else if (r1.Data != r2.Data) return false;         // data doesn't match
                 else return MatchTree(r1.Left, r2.Left) && MatchTree(r1.Right, r2.Right);
             }

            /* Checks if the binary tree rooted at r1 contains the binary tree 
             * rooted at r2 as a subtree somewhere within it.
             */
            public static bool SubTree(TreeNodeJ r1, TreeNodeJ r2)
            {
                if (r1 == null) return false;   // big tree empty & subtree still not found.
                else if (r1.Data == r2.Data && MatchTree(r1, r2)) return true;
                return SubTree(r1.Left, r2) || SubTree(r1.Right, r2);
            }

            public static bool ContainsTree(TreeNodeJ t1, TreeNodeJ t2)
            {
                if (t2 == null) return true;    // The empty tree is a subtree of every tree.
                return SubTree(t1, t2);
            }

            public static void ContainsTree(TreeNodeJ t1, TreeNodeJ t2, TreeNodeJ t3, TreeNodeJ t4)
            {
                var result1 = ContainsTree(t1, t2);
                var result2 = ContainsTree(t3, t4);
                WriteResult(result1, result2);
            }
        }

#endregion QuestionB

        public static void WriteResult(bool result1, bool result2)
        {
            if (result1) Console.WriteLine("t2 is a subtree of t1");
            else Console.WriteLine("t2 is not a subtree of t1");

            if (result2) Console.WriteLine("t4 is a subtree of t3");
            else Console.WriteLine("t4 is not a subtree of t3");
        }
        public static void Q04_10_Run_J()
        {
            // t2 is a subtree of t1
            int[] array1 = {1, 2, 1, 3, 1, 1, 5};
            int[] array2 = {2, 3, 1};
            
            TreeNodeJ t1 = AssortedMethods.CreateTreeFromArray(array1);
            TreeNodeJ t2 = AssortedMethods.CreateTreeFromArray(array2);

            // t4 is not a subtree of t3
            int[] array3 = {1, 2, 3};
            TreeNodeJ t3 = AssortedMethods.CreateTreeFromArray(array1);
            TreeNodeJ t4 = AssortedMethods.CreateTreeFromArray(array3);

            int[] array4 = {1, 2, 1};
            TreeNodeJ t5 = AssortedMethods.CreateTreeFromArray(array4);
            
            int[] array5 = {1, 2, 1, 3, 1, 1, 5, 1, 2};
            TreeNodeJ t6 = AssortedMethods.CreateTreeFromArray(array5);

            int[] array6 = {3, 1, 2};
            TreeNodeJ t7 = AssortedMethods.CreateTreeFromArray(array6);

            QuestionA.ContainsTree(t1, t2, t3, t4);
            QuestionA.ContainsTree(t1, t2, t6, t7);
            QuestionB.ContainsTree(t1, t2, t3, t4);
            QuestionB.ContainsTree(t1, t5, t6, t7);

        }
    }
}