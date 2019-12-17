using System;
using Ctci.Library;

namespace ExChapter04
{
    // See Q04_02_Minimal_Tree.jpg structure
    public class Q4_08_First_Common_Ancestor
    {

#region Question

        public class Question
        {
            static int NO_NODES_FOUND = 0;
            static int ONE_NODE_FOUND = 1;
            static int TWO_NODES_FOUND = 2;

            // Checks how many 'special' nodes are located under this root
            public static int Covers(TreeNodeJ root, TreeNodeJ p, TreeNodeJ q)
            {
                int ret = NO_NODES_FOUND;
                if (root == null) return ret;
                if (root == p || root == q) ret++;
                ret += Covers(root.Left, p, q);
                if (ret == TWO_NODES_FOUND) // Found p and q
                    return ret;
                return ret + Covers(root.Right, p, q);
            }
            public static TreeNodeJ CommonAncestor(TreeNodeJ root, TreeNodeJ p, TreeNodeJ q)
            {
                if (q == p && (root.Left == q || root.Right == q)) return root;
                int nodesFromLeft = Covers(root.Left, p, q);    // Check left side
                if (nodesFromLeft == TWO_NODES_FOUND)
                {
                    if (root.Left == p || root.Left == q) return root.Left;
                    else return CommonAncestor(root.Left, p, q);
                }
                else if (nodesFromLeft == ONE_NODE_FOUND)
                {
                    if (root == p) return p;
                    else if (root == q) return q;
                }

                int nodesFromRight = Covers(root.Right, p, q);  // Check right side
                if (nodesFromRight == TWO_NODES_FOUND)
                {
                    if (root.Right == p || root.Right == q) return root.Right;
                    else return CommonAncestor(root.Right, p, q);
                }
                else if (nodesFromRight == ONE_NODE_FOUND)
                {
                    if (root == p) return p;
                    else if (root == q) return q;
                }
                if (nodesFromRight == ONE_NODE_FOUND && nodesFromRight == ONE_NODE_FOUND) return root;
                else return null;
            }

            public static void Q04_08_Run(TreeNodeJ root, TreeNodeJ n3, TreeNodeJ n7)
            {
                TreeNodeJ ancestor = CommonAncestor(root, n3, n7);
                Console.WriteLine(ancestor.Data);
            }
        }

#endregion Question

#region QuestionA

        public class QuestionA
        {
            public static TreeNodeJ CommonAncestor(TreeNodeJ p, TreeNodeJ q)
            {
                if (p == q) return p;
                
                TreeNodeJ ancestor = p;
                while (ancestor != null)
                {
                    if (IsOnPath(ancestor, q)) return ancestor;
                    ancestor = ancestor.Parent;
                }
                return null;
            }

            public static bool IsOnPath(TreeNodeJ ancestor, TreeNodeJ node)
            {
                while (node != ancestor && node != null) node = node.Parent;
                return node == ancestor;
            }

            public static void Q04_08_Run(TreeNodeJ root, TreeNodeJ n3, TreeNodeJ n7)
            {
                TreeNodeJ ancestor = CommonAncestor(n3, n7);
                Console.WriteLine(ancestor.Data);
            }
        }

#endregion QuestionA

#region QuestionB

        // Solution #1: With Links to Parents
        public class QuestionB
        {
            public static TreeNodeJ GoUpBy(TreeNodeJ node, int delta)
            {
                while (delta > 0 && node != null)
                {
                    node = node.Parent;
                    delta--;
                }
                return node;
            }

            public static int Depth(TreeNodeJ node)
            {
                int depth = 0;
                while (node != null)
                {
                    node = node.Parent;
                    depth++;
                }
                return depth;
            }

            public static TreeNodeJ CommonAncestor(TreeNodeJ p, TreeNodeJ q)
            {
                int delta = Depth(p) - Depth(q);            // Get difference in depths
                TreeNodeJ first = delta > 0 ? q : p;        // Get shallower node
                TreeNodeJ second = delta > 0 ? p : q;       // Get deeper node
                second = GoUpBy(second, Math.Abs(delta));   // Move shallower node to depth of deeper
                while (first != second && first != null && second != null)
                {
                    first = first.Parent;
                    second = second.Parent;
                }
                return first == null || second == null ? null : first;
            }

            public static void Q04_08_Run(TreeNodeJ root, TreeNodeJ n3, TreeNodeJ n7)
            {
                TreeNodeJ ancestor = CommonAncestor(n3, n7);
                Console.WriteLine(ancestor.Data);
            }
        }

#endregion QuestionB

#region QuestionC

        // Solution #2: With Links to Parents
        public class QuestionC
        {
            public static TreeNodeJ GetSibling(TreeNodeJ node)
            {
                if (node == null || node.Parent == null) return null;
                TreeNodeJ parent = node.Parent;
                return parent.Left == node ? parent.Right : parent.Left;
            }

            public static bool Covers(TreeNodeJ root, TreeNodeJ p)
            {
                if (root == null) return false;
                if (root == p) return true;
                return Covers(root.Left, p) || Covers(root.Right, p);
            }
            public static TreeNodeJ CommonAncestor(TreeNodeJ root, TreeNodeJ p, TreeNodeJ q)
            {
                if (!Covers(root, p) || !Covers(root, q)) return null;  // Check if p or q is included in root.
                else if (Covers(p, q)) return p;    // check if q is included in p.
                else if (Covers(q, p)) return q;    // check if p is included in q.

                TreeNodeJ sibling = GetSibling(p);
                TreeNodeJ parent = p.Parent;
                while (!Covers(sibling, q))
                {
                    sibling = GetSibling(parent);
                    parent = parent.Parent;
                }
                return parent;
            }

            public static void Q04_08_Run(TreeNodeJ root, TreeNodeJ n3, TreeNodeJ n7)
            {
                TreeNodeJ ancestor = CommonAncestor(root, n3, n7);
                Console.WriteLine(ancestor.Data);
            }
        }

#endregion QuestionC

#region QuestionD

        // Solution #3: Without Links to Parents
        public class QuestionD
        {
            public static bool Covers(TreeNodeJ root, TreeNodeJ p)
            {
                if (root == null) return false;
                if (root == p) return true;
                return Covers(root.Left, p) || Covers(root.Right, p);
            }

            public static TreeNodeJ AncestorHelper(TreeNodeJ root, TreeNodeJ p, TreeNodeJ q)
            {
                if (root == null || root == p || root == q) return root;

                bool pIsOnLeft = Covers(root.Left, p);
                bool qIsOnLeft = Covers(root.Left, q);
                if (pIsOnLeft != qIsOnLeft) return root;    // Nodes are on different side
                TreeNodeJ childSide = pIsOnLeft ? root.Left : root.Right;
                return AncestorHelper(childSide, p, q);
            }

            public static TreeNodeJ CommonAncestor(TreeNodeJ root, TreeNodeJ p, TreeNodeJ q)
            {
                if (!Covers(root, p) || !Covers(root, q)) return null;  // Error check - one node is not in tree.
                return AncestorHelper(root, p, q);
            }

            public static void Q04_08_Run(TreeNodeJ root, TreeNodeJ n3, TreeNodeJ n7)
            {
                TreeNodeJ ancestor = CommonAncestor(root, n3, n7);
                Console.WriteLine(ancestor.Data);
            }
        }

#endregion QuestionD

#region QuestionE

        // Solution #4: Optimized
        public class QuestionE
        {
            public class Result
            {
                public TreeNodeJ Node;
                public bool IsAncestor;
                public Result(TreeNodeJ n, bool isAnc)
                {
                    this.Node = n;
                    this.IsAncestor = isAnc;
                }
            }

            public static Result CommonAncestorHelper(TreeNodeJ root, TreeNodeJ p, TreeNodeJ q)
            {
                if (root == null) return new Result(null, false);
                if (root == p && root == q) return new Result(root, true);
                
                Result rx = CommonAncestorHelper(root.Left, p, q);
                if (rx.IsAncestor) return rx;   // Found common ancestor.
                
                Result ry = CommonAncestorHelper(root.Right, p, q);
                if (ry.IsAncestor) return ry;   // Found common ancestor.
                
                if (rx.Node != null && ry.Node != null) return new Result(root, true);  // This is the common ancestor
                else if (root == p || root == q)
                {
                    /* If we're currently at p or q, and we also found one of those
                    * nodes in a subtree, then this is truly an ancestor and the
                    * flag should be true. */
                    bool isAncestor = rx.Node != null || ry.Node != null;
                    return new Result(root, isAncestor);
                }
                else return new Result(rx.Node != null ? rx.Node : ry.Node, false);
            }

            public static TreeNodeJ CommonAncestor(TreeNodeJ root, TreeNodeJ p, TreeNodeJ q)
            {
                Result r = CommonAncestorHelper(root, p, q);
                if (r.IsAncestor) return r.Node;
                return null;
            }

            public static void Q04_08_Run(TreeNodeJ root, TreeNodeJ n3, TreeNodeJ n7)
            {
                TreeNodeJ ancestor = CommonAncestor(root, n3, n7);
                if (ancestor != null) Console.WriteLine(ancestor.Data);
                else Console.WriteLine("null");
            }
        }

#endregion QuestionE

#region QuestionEBad

        // Solution #4: Optimized
        // This has a bug..
        public class QuestionEBad
        {
            public static TreeNodeJ CommonAncestorBad(TreeNodeJ root, TreeNodeJ p, TreeNodeJ q)
            {
                if (root == null) return null;
                if (root == p && root == q) return root;

                TreeNodeJ x = CommonAncestorBad(root.Left, p, q);
                if (x != null && x != p && x != q) return x;    // Found common ancestor.

                TreeNodeJ y = CommonAncestorBad(root.Right, p, q);
                if (y != null && y != p && y != q) return y;

                if (x != null && y != null) return root;    // This is the common ancestor.
                else if (root == p || root == q) return root;
                else return x == null ? y : x;
            }

            public static void Q04_08_Run(TreeNodeJ root, TreeNodeJ n3, TreeNodeJ n7)
            {
                TreeNodeJ ancestor = CommonAncestorBad(root, n3, n7);
                if (ancestor != null) Console.WriteLine(ancestor.Data);
                else Console.WriteLine("null");
            }
        }

#endregion QuestionEBad

#region QuestionF

        public class QuestionF
        {
            public static TreeNodeJ CommonAncestor(TreeNodeJ root, TreeNodeJ p, TreeNodeJ q)
            {
                if ((p == null) || (q == null)) return null;

                TreeNodeJ ap = p.Parent;
                while (ap != null)
                {
                    TreeNodeJ aq = q.Parent;
                    while (aq != null)
                    {
                        if (aq == ap) return aq;
                        aq = aq.Parent;
                    }
                    ap = ap.Parent;
                }
                return null;
            }
            public static void Q04_08_Run()
            {
                int[] array = {5, 3, 6, 1, 9, 11};
                TreeNodeJ root = new TreeNodeJ(20);
                foreach (int a in array) root.InsertInOrder(a);
                TreeNodeJ n1 = root.Find(1);
                TreeNodeJ n9 = root.Find(9);
                TreeNodeJ ancestor = CommonAncestor(root, n1, n9);
                if (ancestor != null) Console.WriteLine(ancestor.Data);
                else Console.WriteLine("null");
            }
        }

#endregion QuestionF

        public static void Q04_08_Run_J()
        {
            int[] array = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            TreeNodeJ root = TreeNodeJ.CreateMinimalBST(array);
            // Try (1, 7), (3, 4), (2, 2), (8, 10), (3, 7)
            TreeNodeJ n3 = root.Find(11);
            TreeNodeJ n7 = root.Find(4);
            // Question.Q04_08_Run(root, n3, n7);
            // QuestionA.Q04_08_Run(root, n3, n7);
            // QuestionB.Q04_08_Run(root, n3, n7);
            // QuestionC.Q04_08_Run(root, n3, n7);
            // QuestionD.Q04_08_Run(root, n3, n7);
            // QuestionE.Q04_08_Run(root, n3, n7);

            // For QuestionEBad
            // TreeNodeJ n8 = root.Find(9);
            // TreeNodeJ n9 = new TreeNodeJ(6);    // root.Find(10);
            // QuestionEBad.Q04_08_Run(root, n3, n7);
            QuestionF.Q04_08_Run();

            /* For Debug parameters
            root.Data
            root.Left.Data
            root.Right.Data
            p.Data
            q.Data
            Covers(root.Right, p, q)
            node.Data
            ancestor.Data
            node.Parent.Data
            ancestor.Parent.Data
            node != ancestor
            node == ancestor
            first.Data
            second.Data
            Covers(root.Left, p)
            Covers(root.Right, p)
            parent.Data
            parent.Left.Data
            parent.Right.Data
            sibling.Data
            parent.Left == node
            rx.Node.Data
            rx.IsAncestor
            ry.Node.Data
            ry.IsAncestor
            x.Data
            y.Data
            root == q
            ap.Data
            aq.Data
            */
        }
    }
}