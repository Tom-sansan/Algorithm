using System;
using Ctci.Library;

namespace ExChapter02
{
    public class Q2_03_Delete_Middle_Node
    {
        private static bool DeleteNode(LinkedListNode node)
        {
            if (node == null || node.Next == null) return false;    // Failure

            var next = node.Next;
            node.Data = next.Data;
            node.Next = next.Next;
            
            return true;
        }

        public static void Q2_03_Run()
        {
            var head = AssortedMethods.RandomLinkedList(10, 0, 10);
            Console.WriteLine(head.PrintForward());

            var deleted = DeleteNode(head.Next.Next.Next.Next); // delete node 4
            Console.WriteLine("deleted? {0}", deleted);
            Console.WriteLine(head.PrintForward());
        }
    }
}