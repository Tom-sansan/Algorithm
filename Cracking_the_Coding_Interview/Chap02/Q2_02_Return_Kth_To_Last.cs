using System;
//using System.Collections.Generic;
using Ctci.Library;

namespace ExChapter02
{
    internal class Result
    {
        public LinkedListNode Node { get; set; }
        public int Count { get; set; }

        public Result(LinkedListNode node, int count)
        {
            Node = node;
            Count = count;
        }
    }
    public class Q2_02_Return_Kth_To_Last
    {
        private static int NthToLastR1(LinkedListNode head, int n)
        {
            if (n == 0 || head == null) return 0;

            var k = NthToLastR1(head.Next, n) + 1;
            if(k == n)
            {
                Console.WriteLine("NthToLastR1;");
                Console.WriteLine(n + "th to last node is " + head.Data);
                Console.WriteLine();
            }
            return k;
        }

        private static LinkedListNode NthToLastR2(LinkedListNode head, int n, ref int x)
        {
            if (head == null) return null;

            var node = NthToLastR2(head.Next, n, ref x);
            x = x + 1;
            if (x == n) return head;
            
            return node;
        }

        private static Result NthToLastR3Helper(LinkedListNode head, int k)
        {
            if (head == null) return new Result(null, 0);

            var result = NthToLastR3Helper(head.Next, k);
            if(result.Node == null)
            {
                result.Count++;
                if(result.Count == k) result.Node = head;
            }

            return result;
        }

        private static LinkedListNode NthToLastR3(LinkedListNode head, int k)
        {
            var result = NthToLastR3Helper(head, k);
            if (result != null) return result.Node;
            return null; 
        }

        private static LinkedListNode NthToLast(LinkedListNode head, int n)
        {
            var p1 = head;
            var p2 = head;

            if (n <= 0) return null;

            // Move p2 n nodes into the list. Keep n1 in the same position.
            for (int i = 0; i < n - 1; i++)
            {
                if (p2 == null) return null;    // Error: list is too small.
                p2 = p2.Next;
            }
            // Another error check.
            if (p2 == null) return null;

            // Move them at the same pace. When p2 hits the end,
            // p2 will be at the right element.
            while (p2.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            return p1;
        }

        private static void WriteResult(string title, LinkedListNode node, int k)
        {
            Console.WriteLine(title);

            if (node != null)
            {
                Console.WriteLine(k + "th to last node is " + node.Data);
            }
            else
            {
                Console.WriteLine("Null.  n is out of bounds.");
            }
            Console.WriteLine();
        }

        public static void Q2_02_Run()
        {
            var head = AssortedMethods.RandomLinkedList(10, 0, 10);
            Console.WriteLine(head.PrintForward());
            const int nth = 3;

            var node = NthToLast(head, nth);
            WriteResult("NthToLast;", node, nth);

            NthToLastR1(head, nth);

            var x = 0;
            var node2 = NthToLastR2(head, nth, ref x);
            WriteResult("NthToLastR2;", node2, nth);

            var node3 = NthToLastR3(head, nth);
            WriteResult("NthToLastR3;", node3, nth);
        }
    }
}