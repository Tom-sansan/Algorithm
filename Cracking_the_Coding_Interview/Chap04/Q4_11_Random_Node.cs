using System;

namespace ExChapter04
{
    public class Q4_11_Random_Node
    {

#region Tree
        public class Tree
        {
            TreeNode root = null;

            public void InsertInOrder(int value)
            {
                if (root == null) root = new TreeNode(value);
                else root.InsertInOrder(value);
            }

            public int Size()
            {
                return root == null ? 0 : root.Size();
            }

            public TreeNode GetRandomNode()
            {
                if (root == null) return null;

                Random random = new Random();
                int i = random.Next(Size());
                return root.GetIthNode(i);
            }
        }

#endregion Tree

#region TreeNode11

        /* One node of a binary tree. The data element stored is a single 
         * character.
         */
        public class TreeNode
        {
            public int Data;
            public TreeNode Left;
            public TreeNode Right;
            private int size = 0;

            public TreeNode(int d)
            {
                this.Data = d;
                this.size = 1;
            }

            public void InsertInOrder(int d)
            {
                if (d <= this.Data)
                {
                    if (this.Left == null) this.Left = new TreeNode(d);
                    else this.Left.InsertInOrder(d);
                }
                else
                {
                    if (this.Right == null) this.Right = new TreeNode(d);
                    else this.Right.InsertInOrder(d);
                }
                this.size++;
            }

            public int Size()
            {
                return this.size;
            }

            public TreeNode Find(int d)
            {
                if (d == this.Data) return this;
                else if (d <= this.Data) return this.Left != null ? this.Left.Find(d) : null;
                else if (d > this.Data) return this.Right != null ? this.Right.Find(d) : null;
                return null;
            }

            public TreeNode GetRandomNode()
            {
                int leftSize = this.Left == null ? 0 : this.Left.Size();
                Random random = new Random();
                int index = random.Next(this.size);
                if (index < leftSize) return this.Left.GetRandomNode();
                else if (index == leftSize) return this;
                else return this.Right.GetRandomNode();
            }

            public TreeNode GetIthNode(int i)
            {
                int leftSize = this.Left == null ? 0 : this.Left.Size();
                if (i < leftSize) return this.Left.GetIthNode(i);
                else if (i == leftSize) return this;
                else return this.Right.GetIthNode(i - (leftSize + 1));
            }
        }

#endregion

        public static void Q04_10_Run_J()
        {
            int[] counts = new int[10];
            for (int i = 0; i < 1000000; i++) {
                Tree tree = new Tree();
                int[] array = {1, 0, 6, 2, 3, 9, 4, 5, 8, 7};
                foreach (int x in array) tree.InsertInOrder(x);
                int d = tree.GetRandomNode().Data;
                counts[d]++;
            }
            
            for (int i = 0; i < counts.Length; i++) {
                Console.WriteLine(i + ": " + counts[i]);
            }
        }
    }
}