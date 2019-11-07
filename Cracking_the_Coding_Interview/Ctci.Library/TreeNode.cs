using System;
using System.Diagnostics;

namespace Ctci.Library
{
/* One node of a binary tree. The data element stored is a single 
 * character.
 */
    public class TreeNodeJ
    {
        public int Data;
        public TreeNodeJ Left;
        public TreeNodeJ Right;
        public TreeNodeJ Parent;
        private int Size = 0;

        public TreeNodeJ(int data)
        {
            this.Data = data;
            Size = 1;
        }

        private void setLeftChild(TreeNodeJ left)
        {
            this.Left = left;
            if (left != null) left.Parent = this;
        }

        private void setRightChild(TreeNodeJ right)
        {
            this.Right = right;
            if (right != null) right.Parent = this;
        }

        public void InsertInOrder(int d)
        {
            if (d <= this.Data)
            {
                if (this.Left == null) setLeftChild(new TreeNodeJ(d));
                else this.Left.InsertInOrder(d);
            }
            else
            {
                if (this.Right == null) setRightChild(new TreeNodeJ(d));
                else this.Right.InsertInOrder(d);
            }
            this.Size++;
        }

        public bool IsBST()
        {
            if (this.Left != null)
                if (this.Data < this.Left.Data || !this.Left.IsBST()) return false;
            
            if (this.Right != null)
                if (this.Data >= this.Right.Data || !this.Right.IsBST()) return false;
            
            return true;
        }

        public int Height()
        {
            int leftHeight = this.Left != null ? this.Left.Height() : 0;
            int rightHeight = this.Right != null ? this.Right.Height() : 0;
            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public TreeNodeJ Find(int d)
        {
            if (d == this.Data) return this;
            else if (d <= this.Data) return this.Left != null ? this.Left.Find(d) : null;
            else if (d > this.Data) return this.Right != null ? this.Right.Find(d) : null;
            return null;
        }

        private static TreeNodeJ createMinimalBST(int[] arr, int start, int end)
        {
            if (end < start) return null;

            int mid = (start + end) / 2;
            TreeNodeJ n = new TreeNodeJ(arr[mid]);
            n.setLeftChild(createMinimalBST(arr, start, mid - 1));
            n.setRightChild(createMinimalBST(arr, mid + 1, end));
            return n;
        }

        public static TreeNodeJ CreateMinimalBST(int[] array)
        {
            return createMinimalBST(array, 0, array.Length - 1);
        }

        // public void Print()
        // {
        //     BTreePrinter.Print();
        // }
    }

    [DebuggerDisplay("{Data}")]
    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode Parent { get; set; }
        public int Size { get; set; }

        public TreeNode(int data)
        {
            this.Data = data;
            this.Size = 1;
        }

        public TreeNode(TreeNode node)
        {
            this.Data = node.Data;
            this.Size = node.Size;
            this.Left = node.Left;
            this.Right = node.Right;
            this.Parent = node.Parent;
        }

        public void SetLeftChild(TreeNode left)
        {
            this.Left = left;
            if (left != null) left.Parent = this;
        }

        public void SetRightChild(TreeNode right)
        {
            this.Right = right;
            if (right != null) right.Parent = this;
        }

        public void InsertInOrder(int data)
        {
            if (data <= this.Data)
            {
                if (this.Left == null) SetLeftChild(new TreeNode(data));
                else this.Left.InsertInOrder(data);
            }
            else
            {
                if (this.Right == null) SetRightChild(new TreeNode(data));
                else Right.InsertInOrder(data);
            }
            this.Size++;
        }

        public bool IsBst()
        {
            if (this.Left != null)
                if (this.Data < this.Left.Data || !this.Left.IsBst()) return false;
            if (this.Right != null)
                if (this.Data >= this.Right.Data || !this.Right.IsBst()) return false;
            
            return true;
        }

        public int Height()
        {
            var leftHeight = this.Left != null ? this.Left.Height() : 0;
            var rightHeight = this.Right != null ? this.Right.Height() : 0;
            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public TreeNode Find(int data)
        {
            if (data == this.Data) return this;
            else if (data <= this.Data) return this.Left != null ? this.Left.Find(data) : null;
            else if (data > this.Data) return this.Right != null ? this.Right.Find(data) : null;
            return null;
        }

        private static TreeNode CreateMinialBst(int[] array, int start, int end)
        {
            if (end < start) return null;

            var mid = (start + end) / 2;
            var n = new TreeNode(array[mid]);
            n.SetLeftChild(CreateMinialBst(array, start, mid - 1));
            n.SetRightChild(CreateMinialBst(array, mid + 1, end));
            return n;
        }

        public static TreeNode CreateMinimalBst(int[] array)
        {
            return CreateMinialBst(array, 0, array.Length - 1);
        }

        public void Print()
        {
            BTreePrinter.Print(this);
        }
    }
}