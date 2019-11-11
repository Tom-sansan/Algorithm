using System;
using Ctci.Library;

namespace ExChapter04
{
    public class IntWrapper
    {
        public int Data;

        public IntWrapper(int m)
        {
            Data = m;
        }
    }

    public class Q4_05_Validate_BST
    {
#region Solution #1:In-Order Traversal
        public static class Q4_05_CheckBST_A
        {
            public static int? lastPrinted = null;

            public static bool CheckBST(TreeNodeJ node)
            {
                return CheckBST(node, true);
            }

            // Allow "equal" value only for left child. This validates the BST property.
            public static bool CheckBST(TreeNodeJ n, bool isLeft)
            {
                if (n == null) return true;

                // Check / recurse left
                if (!CheckBST(n.Left, true)) return false;

                // Check current
                if (lastPrinted != null)
                {
                    if (isLeft)
                    {
                        // left child "is allowed" be equal to parent.
                        if (n.Data < lastPrinted) return false;
                    }
                    else
                    {
                        // Right child "is not allowed" be equal to parent.
                        if (n.Data <= lastPrinted) return false;
                    }
                }
                lastPrinted = n.Data;

                // Check / recurse right
                if (!CheckBST(n.Right, false)) return false;

                return true;
            }

            public static void Q04_05_Run_J_A()
            {
                int[] array = {int.MinValue, int.MaxValue - 2, int.MaxValue - 1, int.MaxValue};
                TreeNodeJ node = TreeNodeJ.CreateMinimalBST(array);
                Console.WriteLine(CheckBST(node));
/* Expect true:
        2147483645
         /      \
        /        \
-2147483648     2147483646
                   \
                   2147483647
*/

                lastPrinted = null;
                node.Left.Data = 5;
                node.Right.Right.Data = 3;
                Console.WriteLine(CheckBST(node));
/* Expect false:
        2147483645
         /      \
        /        \
       5     2147483646
                   \
                    3
*/

                Test();
            }

            public static void Test()
            {
                TreeNodeJ node;
                bool condition;
                Console.WriteLine("test cases for equals condition.");

                int[] array2 = {1, 2, 3, 4};
                node = TreeNodeJ.CreateMinimalBST(array2);
                node.Left.Data = 2;
                // node.Print();
                lastPrinted = null;
                condition = CheckBST(node);
                Console.WriteLine("should be true: " + condition);
                /* Expect true: for left child: node.data <= last_printed.
   2
  / \
 /   \
2     3
       \
        4
                */

                int[] array3 = {1, 2, 3, 4};
                node = TreeNodeJ.CreateMinimalBST(array3);
                node.Right.Data = 2;
                // node.print();
                lastPrinted = null;
                condition = CheckBST(node);
                Console.WriteLine("should be false: " + condition);
                /* Expect false: for right child: node.data <= last_printed.
   2
  / \
 /   \
1     2
       \
        4
                */
            }
        }
#endregion Solution #1:In-Order Traversal

#region  Solution #2: The Min/Max Solution
        public static class Q4_05_CheckBST_B
        {
            public static bool CheckBST(TreeNodeJ n, int? min, int? max)
            {
                if (n == null) return true;
                if ((min != null && n.Data <= min) || (max != null && n.Data > max)) return false;
                if (!CheckBST(n.Left, min, n.Data) || !CheckBST(n.Right, n.Data, max)) return false;

                return true;
            }

            public static bool CheckBST(TreeNodeJ n)
            {
                return CheckBST(n, null, null);
            }

            public static bool CheckBSTAlternate(TreeNodeJ n)
            {
                return CheckBSTAlternate(n, new IntWrapper(0), new IntWrapper(0));
            }

            public static bool CheckBSTAlternate(TreeNodeJ n, IntWrapper min, IntWrapper max)
            {
                // An alternate, less clean approach. This is not provided in the book, but is used to test the other method.
                if (n.Left == null) min.Data = n.Data;
                else
                {
                    IntWrapper leftMin = new IntWrapper(0);
                    IntWrapper leftMax = new IntWrapper(0);
                    if (!CheckBSTAlternate(n.Left, leftMin, leftMax)) return false;
                    if (leftMax.Data > n.Data) return false;
                    min.Data = leftMin.Data;
                }
                if (n.Right == null) max.Data = n.Data;
                else
                {
                    IntWrapper rightMin = new IntWrapper(0);
                    IntWrapper rightMax = new IntWrapper(0);
                    if (!CheckBSTAlternate(n.Right, rightMin, rightMax)) return false;
                    if (rightMin.Data <= n.Data) return false;
                    max.Data = rightMax.Data;
                }
                return true;
            }

            // Create a tree that may or may not be a BST
            public static TreeNodeJ CreateTestTree()
            {
                // Create a randam BST
                TreeNodeJ head = AssortedMethods.RandomBST(10, -10, 10);
                
                // Insert an element into the BST and potentially ruin the BST property
                TreeNodeJ node = head;
                do
                {
                    int n = AssortedMethods.RandomIntInRange(-10, 10);
                    int rand = AssortedMethods.RandomIntInRange(0, 5);
                    if (rand == 0) node.Data = n;
                    else if (rand == 1) node = node.Left;
                    else if (rand == 2) node = node.Right;
                    else if (rand == 3 || rand == 4) break;
                } while (node != null);

                return head;
            }
            public static void Q04_05_Run_J_B()
            {
                /* Simple test -- create one */
                int[] array = {int.MinValue, 3, 5, 6, 10, 13, 15, int.MaxValue};
                TreeNodeJ node = TreeNodeJ.CreateMinimalBST(array);
                //node.left.data = 6; // "ruin" the BST property by changing one of the elements
                // node.Print();
                bool isBst = CheckBST(node);
                Console.WriteLine(isBst);
                /* Expect true:
                 6
              /     \
             /       \
            3        13
           / \     /    \
-2147483648   5   10    15
                          \
                        2147483647
                */

                /* More elaborate test -- creates 100 trees (some BST, some not) and compares the outputs of various methods. */
                for (int i = 0; i < 100; i++) {
                    TreeNodeJ head = CreateTestTree();
                    
                    // Compare results 
                    bool isBst1 = CheckBST(head);
                    bool isBst2 = CheckBSTAlternate(head);
                    
                    if (isBst1 != isBst2) {
                        Console.WriteLine("*********************** ERROR *******************");
                        //head.Print();
                        break;
                    } else {
                        Console.WriteLine(isBst1 + " | " + isBst2);
                        //head.Print();
                    }
                }

            }
        }
#endregion Solution #2: The Min/Max Solution

        public static void Q04_05_Run_J()
        {
            Q4_05_CheckBST_A.Q04_05_Run_J_A();
            Q4_05_CheckBST_B.Q04_05_Run_J_B();
        }
    }
}