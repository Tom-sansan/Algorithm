using System;
using System.Collections.Generic;
using Ctci.Library;

namespace ExChapter03
{
    public class Q3_04_Queue_via_Stacks
    {
        public class MyQueue<T>
        {
            Stack<T> stackNewest, stackOldest;

            public MyQueue()
            {
                stackNewest = new Stack<T>();
                stackOldest = new Stack<T>();
            }

            public int Size()
            {
                return stackNewest.Count + stackOldest.Count;
            }

            public void Add(T value)
            {
                // Push onto stack1
                stackNewest.Push(value);
            }

            /* Move elements from stackNewest into stackOldest. This is usually done so that we can
            * do operations on stackOldest.
            */
            private void ShiftStacks()
            {
                if (stackOldest.Count == 0)
                {
                    while (stackNewest.Count != 0)
                    {
                        stackOldest.Push(stackNewest.Pop());
                    }
                }
            }

            public T Peek()
            {
                ShiftStacks();
                return stackOldest.Peek();   // retrieve the oldest item.
            }

            public T Remove()
            {
                ShiftStacks();
                return stackOldest.Pop();   // pop the oldest item.
            }

        }
        public static void Q03_04_Run()
        {
            MyQueue<int> myQueue = new MyQueue<int>();	

            // Let's test our code against a "real" queue
            Queue<int> testQueue = new Queue<int>();

            for (int i = 0; i < 100; i++)
            {
                int choice = AssortedMethods.RandomIntInRange(0, 10);
                if (choice <= 5)
                { // enqueue
                    int element = AssortedMethods.RandomIntInRange(1, 10);
                    testQueue.Enqueue(element);
                    myQueue.Add(element);
                    Console.WriteLine("Enqueued " + element);
                }
                else if (testQueue.Count > 0)
                {
                    int top1 = testQueue.Dequeue();
                    int top2 = myQueue.Remove();
                    // Check for error
                    if (top1 != top2) Console.WriteLine("******* FAILURE - DIFFERENT TOPS: " + top1 + ", " + top2);
                    Console.WriteLine("Dequeued " + top1);
                }

                if (testQueue.Count == myQueue.Size())
                {
                    if (testQueue.Count > 0 && testQueue.Peek() != myQueue.Peek())
                        Console.WriteLine("******* FAILURE - DIFFERENT TOPS: " + testQueue.Peek() + ", " + myQueue.Peek() + " ******");
                }
                else Console.WriteLine("******* FAILURE - DIFFERENT SIZES ******");
            }
        }
    }
}