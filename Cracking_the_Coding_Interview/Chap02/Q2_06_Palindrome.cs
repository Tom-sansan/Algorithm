using System;
using System.Collections.Generic;
using Ctci.Library;

namespace ExChapter02
{
    public class Q2_06_Palindrome
    {
        private class Result
        {
            public LinkedListNode Node;
            public bool result;

            public Result(LinkedListNode node, bool res)
            {
                Node = node;
                result = res;
            }
        }
        private static Result IsPalindrome1Recurse(LinkedListNode head1, int length)
        {
            if (head1 == null || length == 0) return new Result(null, true);
            if (length == 1) return new Result(head1.Next, true);
            if (length == 2) return new Result(head1.Next.Next, head1.Data == head1.Next.Data);

            var res = IsPalindrome1Recurse(head1.Next, length - 2);
            if (!res.result || res.Node == null) return res;    // Only "result" member is actually used in the call stack.

            res.result = head1.Data == res.Node.Data;
            res.Node = res.Node.Next;

            return res;
        }

        private static bool IsPalindrome1(LinkedListNode head1)
        {
            var size = 0;
            var node = head1;
            while (node != null)
            {
                size++;
                node = node.Next;
            }
            
            var palindrome = IsPalindrome1Recurse(head1, size);

            return palindrome.result;
        }

        private static bool IsPalindrome2(LinkedListNode head2)
        {
            var fast = head2;
            var slow = head2;

            var stack = new Stack<int>();
            while (fast != null && fast.Next != null)
            {
                stack.Push(slow.Data);
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            // Has odd number of elements, so skip the middle
            if (fast != null) slow = slow.Next;
            while (slow != null)
            {
                var top = stack.Pop();
                Console.WriteLine(slow.Data + " " + top);
                if (top != slow.Data) return false;
                slow = slow.Next;
            }

            return true;
        }

        /// <summary>
        /// Another recursive approach.
        /// 
        /// We traverse the Linked List to the end while keeping a reference of the first node.
        /// Palindrome check begins when we recurse to the end of the Linked List:
        /// 1) Compare the two nodes (one from start and one from the back)
        /// 2) Advance the "front" node because by recursing back we get the node before "back"
        /// 3) Return isPalindrome
        /// </summary>
        /// <param name="head3">First node of the Linked List</param>
        /// <returns></returns>
        private static bool IsPalindrome3(LinkedListNode head3)
        {
            return (head3 == null) || (head3.Next == null) || IsPalindrome3Recurse(ref head3, head3.Next);
        }

        private static bool IsPalindrome3Recurse(ref LinkedListNode front, LinkedListNode back)
        {
            bool isPalindrome = true;
            if (back.Next != null) isPalindrome = IsPalindrome3Recurse(ref front, back.Next);

            isPalindrome &= front.Data == back.Data;
            front = front.Next;

            return isPalindrome;
        }

        private static bool IsPalindrome4(LinkedListNode head4)
        {
            var lifo = new Stack<LinkedListNode>();
            var fifo = new Queue<LinkedListNode>();

            // Fill the buffers
            while (head4 != null)
            {
                lifo.Push(head4);
                fifo.Enqueue(head4);
                head4 = head4.Next;
            }

            // Eeach cycle compare a node from start with the node from the end
            while (lifo.Count > 0 && fifo.Count > 0)
            {
                if (lifo.Pop().Data != fifo.Dequeue().Data) return false;
            }

            return true;
        }
        public static void Q2_06_Run()
        {
            const int length = 10;
            var nodes = new LinkedListNode[length];

            for (var i = 0; i < length; i++)
            {
                nodes[i] = new LinkedListNode(i >= length / 2 ? length - i - 1 : i, null, null);
            }

            for (var i = 0; i < length; i++)
            {
                if (i < length - 1)
                {
                    nodes[i].SetNext(nodes[i + 1]);
                }

                if (i > 0)
                {
                    nodes[i].SetPrevious(nodes[i - 1]);
                }
            }
            // nodes[length - 2].data = 9; // Uncomment to ruin palindrome

            var node = nodes[0];
            Console.WriteLine(node.PrintForward());
            Console.WriteLine(IsPalindrome1(node));
            Console.WriteLine(IsPalindrome2(node));
            Console.WriteLine(IsPalindrome3(node));
            Console.WriteLine(IsPalindrome4(node));
        }
    }
}