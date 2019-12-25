using System;
using System.Collections.Generic;
using System.Text;
using Ctci.Library;

namespace ExChapter04
{
    public class Q4_09_BST_Sequences
    {
        public static void WeaveLists(LinkedList<int> first, LinkedList<int> second, List<LinkedList<int>> results, LinkedList<int> prefix)
        {
            /* One list is empty. Add the remainder to [a cloned] prefix and
             * store result. */
            if (first.Count == 0 || second.Count == 0)
            {
                LinkedList<int> result = new LinkedList<int>();
                foreach (var p in prefix) result.AddLast(p);
                if (first.Count != 0) foreach (var f in first) result.AddLast(f);
                if (second.Count != 0) foreach (var s in second) result.AddLast(s);
                results.Add(result);
                return;
            }

            /* Recurse with head of first added to the prefix. Removing the
            * head will damage first, so we’ll need to put it back where we
            * found it afterwards. */
            int headFirst = first.First.Value;
            first.RemoveFirst();
            prefix.AddLast(headFirst);
            WeaveLists(first, second, results, prefix);
            prefix.RemoveLast();
            first.AddFirst(headFirst);

            /* Do the same thing with second, damaging and then restoring
            * the list.*/
            int headSecond = second.First.Value;
            second.RemoveFirst();
            prefix.AddLast(headSecond);
            WeaveLists(first, second, results, prefix);
            prefix.RemoveLast();
            second.AddFirst(headSecond);
        }
        public static List<LinkedList<int>> AllSequences(TreeNodeJ node)
        {
            List<LinkedList<int>> result = new List<LinkedList<int>>();
            if (node == null)
            {
                result.Add(new LinkedList<int>());
                return result;
            }

            LinkedList<int> prefix = new LinkedList<int>();
            prefix.AddLast(node.Data);

            // Recurse on left and right subtrees.
            List<LinkedList<int>> leftSeq = AllSequences(node.Left);
            List<LinkedList<int>> rightSeq = AllSequences(node.Right);

            // Weave together each list from the left and right sides.
            foreach (var left in leftSeq)
            {
                foreach (var right in rightSeq)
                {
                    var weaved = new List<LinkedList<int>>();
                    WeaveLists(left, right, weaved, prefix);
                    result.AddRange(weaved);
                }
            }
            return result;
        }
        public static void Q04_09_Run_J()
        {
            TreeNodeJ node = new TreeNodeJ(5);
            int[] array = {1, 3, 6, 9};
            // int[] array = {100, 50, 20, 75, 150, 120, 170};
            foreach (var a in array) node.InsertInOrder(a);
            List<LinkedList<int>> allSeq = AllSequences(node);
            StringBuilder sb = new StringBuilder();
            foreach (LinkedList<int> list in allSeq)
            {
                sb.Append("{");
                foreach (var value in list)
                {
                    sb.Append(value).Append(",");
                }
                sb.Append("}").AppendLine();
            }
            sb.Replace(",}", "}");
            Console.WriteLine(sb.ToString());
            Console.WriteLine(allSeq.Count);
        }
    }
}