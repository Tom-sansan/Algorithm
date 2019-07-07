using System;
using Ctci.Library;

namespace ExChapter02
{
    public class Q2_04_Partition
    {
        private static LinkedListNode Partition1(LinkedListNode node, int pivot)
        {
            LinkedListNode beforeStart = null;
            LinkedListNode beforeEnd = null;
            LinkedListNode afterStart = null;
            LinkedListNode afterEnd = null;

            // Partition List
            while (node != null)
            {
                var next = node.Next;
                node.Next = null;

                if (node.Data < pivot)
                {
                    if (beforeStart == null)
                    {
                        beforeStart = node;
                        beforeEnd = beforeStart;
                    }
                    else
                    {
                        beforeEnd.Next = node;
                        beforeEnd = node;
                    }
                }
                else
                {
                    if (afterStart == null)
                    {
                        afterStart = node;
                        afterEnd = afterStart;
                    }
                    else
                    {
                        afterEnd.Next = node;
                        afterEnd = node;
                    }
                }
                node = next;
            }

            // Marge before list and after list
            if (beforeStart == null) return afterStart;

            beforeEnd.Next = afterStart;
            return beforeStart;
        }

        private static LinkedListNode Partition2(LinkedListNode node, int pivot)
        {
            LinkedListNode beforeStart = null;
            LinkedListNode afterStart = null;

            // Partition List
            while (node != null)
            {
                var next = node.Next;
                if (node.Data < pivot)
                {
                    // Insert node into start of before list
                    node.Next = beforeStart;
                    beforeStart = node;
                }
                else
                {
                    // Insert node into front of after list
                    node.Next = afterStart;
                    afterStart = node;
                }
                node = next;
            }

            // Merge before list and after list
            if (beforeStart == null) return afterStart;

            var head = beforeStart;
            while (beforeStart.Next != null)
            {
                beforeStart = beforeStart.Next;
            }
            beforeStart.Next = afterStart;

            return head;
        }

        private static LinkedListNode Partition3(LinkedListNode listHead, int pivot)
        {
            var leftList = new LinkedListNode();    // empty temp to not have an IF inside the loop
            var rightList = new LinkedListNode(pivot, null, null);

            var leftListHead = leftList;    // Used at the end to remove the empty node.
            var rightListHead = rightList;  // Used at the end to merge lists.

            var currentNode = listHead;

            while (currentNode != null)
            {
                if (currentNode.Data < pivot) leftList = new LinkedListNode(currentNode.Data, null, leftList);
                else if (currentNode.Data > pivot) rightList = new LinkedListNode(currentNode.Data, null, rightList);

                currentNode = currentNode.Next;
            }

            leftList.Next = rightListHead;

            var finalList = leftListHead.Next;
            leftListHead.Next = null;   // remove the temp node, GC will release the mem
            return finalList;
        }

        private static LinkedListNode Partition4(LinkedListNode listHead, int pivot)
        {
            LinkedListNode leftSubList = null;
            LinkedListNode rightSubList = null;
            LinkedListNode rightSbuListHead = null;
            LinkedListNode pivotNode = null;

            var currentNode = listHead;
            while (currentNode != null)
            {
                var nextNode = currentNode.Next;
                currentNode.Next = null;

                if (currentNode.Data < pivot)
                {
                    leftSubList = leftSubList == null
                        ? currentNode
                        : leftSubList = leftSubList = leftSubList.Next = currentNode;
                }
                else if (currentNode.Data > pivot)
                {
                    rightSubList = rightSbuListHead == null
                        ? rightSbuListHead = currentNode
                        : rightSubList = rightSubList.Next = currentNode;
                }
                else
                {
                    pivotNode = currentNode;
                }
                currentNode = nextNode;
            }

            pivotNode.Next = rightSbuListHead;
            rightSbuListHead = pivotNode;
            leftSubList.Next = rightSbuListHead;

            return listHead;
        }
        public static void Q2_04_Run()
        {
           /* Create linked list */
            //int[] vals = { 1, 3, 7, 5, 2, 9, 4 };
            int[] vals = { 3, 5, 8, 5, 10, 2, 1 };
            var head = new LinkedListNode(vals[0], null, null);
            var current = head;

            for (var i = 1; i < vals.Length; i++)
            {
                current = new LinkedListNode(vals[i], null, current);
            }
            Console.WriteLine(head.PrintForward());

            var head2 = head.Clone();
            var head3 = head.Clone();
            var head4 = head.Clone();

            /* Partition */
            var h = Partition1(head, 5);
            var h2 = Partition2(head2, 5);
            var h3 = Partition3(head3, 5);
            var h4 = Partition4(head4, 5);

            /* Print Result */
            Console.WriteLine(h.PrintForward());
            Console.WriteLine(h2.PrintForward());
            Console.WriteLine(h3.PrintForward());
            Console.WriteLine(h4.PrintForward());
        }
    }
}