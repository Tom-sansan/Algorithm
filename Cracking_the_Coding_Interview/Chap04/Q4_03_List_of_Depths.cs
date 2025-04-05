using System;
using System.Collections.Generic;
using Ctci.Library;


namespace ExChapter04
{
    public class Q4_03_List_of_Depths
    {

#region Q04_03_Run_J
        public static void CreateLevelLinkedListDFS(TreeNodeJ root, List<LinkedList<TreeNodeJ>> lists, int level)
        {
            if (root == null) return;
            LinkedList<TreeNodeJ> list = null;
            if (lists.Count == level)   // Level not contained in list
            {
                list = new LinkedList<TreeNodeJ>();
                /* Levels are always traversed in order. So, if this is the first time we've visited level i,
                 * we must have seen levels 0 through i - 1. We can therefore safely add the level at the end. */
                lists.Add(list);
            }
            else list = lists[level];

            list.AddLast(root);
            CreateLevelLinkedListDFS(root.Left, lists, level + 1);
            CreateLevelLinkedListDFS(root.Right, lists, level + 1);
        }

        public static List<LinkedList<TreeNodeJ>> CreateLevelLinkedListDFS(TreeNodeJ root)
        {
            List<LinkedList<TreeNodeJ>> lists = new List<LinkedList<TreeNodeJ>>();
            CreateLevelLinkedListDFS(root, lists, 0);
            return lists;
        }

        public static List<LinkedList<TreeNodeJ>> CreateLevelLinkedListBFS(TreeNodeJ root)
        {
            List<LinkedList<TreeNodeJ>> result = new List<LinkedList<TreeNodeJ>>();

            // "Visit" the root
            var current = new LinkedList<TreeNodeJ>();
            if (root != null) current.AddLast(root);
            while (current.Count > 0)
            {
                result.Add(current); // Add previous lerel
                LinkedList<TreeNodeJ> parents = current; // Go to next level
                current = new LinkedList<TreeNodeJ>();
                foreach (var parent in parents)
                {
                    // Visit the children
                    if (parent.Left != null) current.AddLast(parent.Left);
                    if (parent.Right != null) current.AddLast(parent.Right);
                }
            }
            return result;
        }

        public static void PrintResult(List<LinkedList<TreeNodeJ>> resutl)
        {
            int depth = 0;
            foreach (var entry in resutl)
            {
                var i = entry.GetEnumerator();
                Console.Write("Link list at depth " + depth + ":");
                while (i.MoveNext()) Console.Write(" " + i.Current.Data);
                Console.WriteLine();
                depth++;
            }
        }
        public static void Q04_03_Run_J()
        {
            int[] nodesFlattened = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            TreeNodeJ root = AssortedMethods.CreateTreeFromArray(nodesFlattened);
            List<LinkedList<TreeNodeJ>> list = CreateLevelLinkedListDFS(root);
            //List<LinkedList<TreeNodeJ>> list = CreateLevelLinkedListBFS(root);
            PrintResult(list);
        }

#endregion Q04_03_Run_J

#region Q04_03_Run_C

        private static void AddChildren(TreeNode node, List<TreeNode> list)
        {
            if (node.Left != null) list.Add(node.Left);
            if (node.Right != null) list.Add(node.Right);
        }
        public static List<List<TreeNode>> ListOfDepths(TreeNode root)
        {
            if (root == null) return null;
            var list = new List<List<TreeNode>>();
            var sbList = new List<TreeNode> { root };
            while (sbList.Count > 0)
            {
                list.Add(sbList);
                var prevList = sbList;
                sbList = new List<TreeNode>();
                foreach (var node in prevList) AddChildren(node, sbList);
            }
            return list;
        }
        public static void Q04_03_Run_C()
        {
            var tree = Q4_02_Minimal_Tree.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var listOfDepths = ListOfDepths(tree);

            // BTreePrinter.Print(tree);
            foreach(var list in listOfDepths)
            {
                foreach (var sbList in list) Console.Write($"{sbList.Data},");
                Console.WriteLine();
            }
        }
    }

#endregion Q04_03_Run_C
}