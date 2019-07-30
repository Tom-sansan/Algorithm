using System;
using System.Collections.Generic;
using Ctci.Library;

namespace ExChapter03
{
    public class Q3_03_Stack_of_Plates
    {
        public class Stack
        {
            private int Capacity;
            public Node Top;
            public Node Bottom;
            public int Size = 0;

            public Stack(int capacity)
            {
                this.Capacity = capacity;
            }

            public bool IsFull()
            {
                return this.Capacity == this.Size;
            }

            public void Join(Node above, Node below)
            {
                if (below != null) below.Above = above;
                if (above != null) above.Below = below;
            }

            public bool Push(int value)
            {
                if (Size >= Capacity) return false;
                Size++;
                Node n = new Node(value);
                if (Size == 1) Bottom = n;
                Join(n, Top);
                Top = n;
                return true;
            }

            public int Pop()
            {
                if (Top == null) throw new Q3_01_Exception(EnumException.EmptyStackException);
                Node top = Top;
                Top = Top.Below;
                Size--;
                return top.Value;
            }

            public bool IsEmpty()
            {
                return Size == 0;
            }

            public int RemoveBottom()
            {
                Node b = Bottom;
                Bottom = Bottom.Above;
                if (Bottom != null) Bottom.Below = null;
                Size--;
                return b.Value;
            }
        }
        
        public class Node
        {
            public Node Above;
            public Node Below;
            public int Value;
            public Node(int value)
            {
                this.Value = value;
            }
        }
        public class SetOfStacks
        {
            List<Stack> stacks = new List<Stack>();
            public int Capacity;

            public SetOfStacks(int capacity)
            {
                this.Capacity = capacity;
            }

            public Stack GetLastStack()
            {
                if (stacks.Count == 0) return null;
                return stacks[stacks.Count - 1];
            }

            public void Push(int value)
            {
                Stack last = GetLastStack();
                if (last != null && !last.IsFull()) last.Push(value);    // Add to last
                else
                {   // must create new stack
                    Stack stack = new Stack(Capacity);
                    stack.Push(value);
                    stacks.Add(stack);
                }
            }

            public int Pop()
            {
                Stack last = GetLastStack();
                if (last == null) throw new Q3_01_Exception(EnumException.EmptyStackException);

                object Value = last.Pop();
                if (last.Size == 0) stacks.RemoveAt(stacks.Count - 1);
                return Convert.ToInt32(Value);
            }

            public int PopAt(int index)
            {
                return LeftShift(index, true);
            }

            public int LeftShift(int index, bool removeTop)
            {
                Stack stack = stacks[index];
                int removedItem;
                if (removeTop) removedItem = Convert.ToInt32(stack.Pop());
                else removedItem = stack.RemoveBottom();
                
                if (stack.IsEmpty()) stacks.RemoveAt(index);
                else if (stacks.Count > index + 1)
                {
                    int value = LeftShift(index + 1, false);
                    stack.Push(value);
                }

                return removedItem;
            }

            public bool IsEmpty()
            {
                Stack last = GetLastStack();
                return last == null || last.IsEmpty();
            }
        }
        public static void Q03_03_Run()
        {
            int capacityPerSubstack = 5;
            SetOfStacks set = new SetOfStacks(capacityPerSubstack);
            for (int i = 0; i < 34; i++)
            {
                set.Push(i);
            }
            Random rd = new Random();
            int rdNum;
            for (int i = 0; i < 35; i++)
            {
                //Console.WriteLine("Popped " + set.Pop());
                rdNum = rd.Next(capacityPerSubstack);
                Console.WriteLine("Popped " + set.PopAt(rdNum));
            }
        }
    }
}