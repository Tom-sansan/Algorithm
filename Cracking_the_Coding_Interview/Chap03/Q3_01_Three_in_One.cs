using System;
using Ctci.Library;

namespace ExChapter03
{
    public class Q3_01_Three_in_One
    {

        #region FixedMultiStacka

        private class FixedMultiStack
        {
            private int numberOfStack = 3;
            private int stackCapacity;
            private int[] values;
            private int[] sizes;

            public FixedMultiStack(int stackSize)
            {
                this.stackCapacity = stackSize;
                this.values = new int[stackSize * numberOfStack];
                this.sizes = new int[numberOfStack];
            }

            // Push value onto satck.
            public void Push(int stackNum, int value)
            {
                // Check that we have space for the next element
                if (IsFull(stackNum)) throw new Q3_01_Exception(EnumException.FullStackException);

                // Increment stack pointer and then update top value.
                sizes[stackNum]++;
                values[IndexOfTop(stackNum)] = value;
            }

            // Pop item from top stack.
            public int Pop(int stackNum)
            {
                if (IsEmpty(stackNum)) throw new Q3_01_Exception(EnumException.EmptyStackException);

                int topIndex = IndexOfTop(stackNum);
                int value = values[topIndex];   // Get top
                values[topIndex] = 0;           // Clear
                sizes[stackNum]--;              // Shrink
                return value;
            }

            // Return top element.
            public int Peek(int stackNum)
            {
                if (IsEmpty(stackNum)) throw new Q3_01_Exception(EnumException.EmptyStackException);
                return values[IndexOfTop(stackNum)];
            }

            // Return if stack is empty.
            public bool IsEmpty(int stackNum)
            {
                return sizes[stackNum] == 0;
            }

            // Return if stack is full.
            public bool IsFull(int stackNum)
            {
                return sizes[stackNum] == stackCapacity;
            }

            private int IndexOfTop(int stackNum)
            {
                int offset = stackNum * stackCapacity;
                int size = sizes[stackNum];
                return offset + size - 1;
            }

            public int[] GetValues()
            {
                return values;
            }

            public int[] GetStackValues(int stackNum)
            {
                int[] items = new int[sizes[stackNum]];
                for (int i = 0; i < items.Length; i++)
                {
                    items[i] = values[stackNum * stackCapacity + i];
                }
                
                return items;
            }

            public string StackToString(int stackNum)
            {
                int[] items = GetStackValues(stackNum);
                return stackNum + ": " + AssortedMethods.ArrayToString(items);
            }
        }

        private static void PrintFixedMultiStacks(FixedMultiStack stacks)
        {
            Console.WriteLine(AssortedMethods.ArrayToString(stacks.GetValues()));
        }

        private static void PrintMultiStacks(MultiStack stacks)
        {
            Console.WriteLine(AssortedMethods.ArrayToString(stacks.GetValues()));
        }

        #endregion FixedMultiStack

        #region MultiStack

        public class MultiStack
        {
            /* StackInfo is a simple class that holds a set of data about 
             * each stack. It does not hold the actual items in the stack. 
             * We could have done this with just a bunch of individual 
             * variables, but that’s messy and doesn’t gain us much. */
            private class StackInfo
            {
                public int start, size, capacity;
                public StackInfo(int start, int capacity)
                {
                    this.start = start;
                    this.capacity = capacity;
                }

                /* Check if an index on the full array is within the stack
                 * boundaries. The stack can wrap around to the start of 
                 * the array. */
                public bool IsWithinStackCapacity(int index)
                {
                    /* If outside of bounds of array, return false. */
                    if (index < 0 || index >= Values.Length) return false;

                    /* If index wraps around, adjust it. */
                    int contiguousIndex = index < start ? index + Values.Length : index;
                    int end = start + capacity;
                    return start <= contiguousIndex && contiguousIndex < end;
                }

                public int LastCapacityIndex()
                {
                    return AdjustIndex(start + capacity - 1);
                }

                public int LastElementIndex()
                {
                    return AdjustIndex(start + size - 1);
                }

                public bool IsFull()
                {
                    return size == capacity;
                }

                public bool IsEmpty()
                {
                    return size == 0;
                }
            }

            private StackInfo[] Info;
            private static int[] Values;

            public MultiStack(int numberOfStacks, int defaultSize)
            {
                /* Create metadata for all the stacks. */
                Info = new StackInfo[numberOfStacks];
                for (int i = 0; i < numberOfStacks; i++)
                {
                    Info[i] = new StackInfo(defaultSize * i, defaultSize);
                }
                Values = new int[numberOfStacks * defaultSize];
            }

            /* Returns the number of items actually present in stack. */
            public int NumberOfElements()
            {
                int size = 0;
                foreach (StackInfo sd in Info) size += sd.size;
                return size;
            }

            /* Returns true is all the stacks are full. */
            public bool AllStacksAreFull()
            {
                return NumberOfElements() == Values.Length;
            }

            /* Adjust index to be within the range of 0 -> length - 1. */
            private static int AdjustIndex(int index)
            {
                /* Java's mod operator can return neg values. For example,
                 * (-11 % 5) will return -1, not 4. We actually want the 
                 * value to be 4 (since we're wrapping around the index). 
                */
                int max = Values.Length;
                return ((index % max) + max) % max;
            }

            /* Get index after this index, adjusted for wrap around. */
            private int NextIndex(int index)
            {
                return AdjustIndex(index + 1);
            }

            /* Get index before this index, adjusted for wrap around. */
            private int PreviousIndex(int index)
            {
                return AdjustIndex(index - 1);
            }

            /* Shift items in stack over by one element. If we have 
             * available capacity, then we'll end up shrinking the stack 
             * by one element. If we don't have available capacity, then
             * we'll need to shift the next stack over too. */
            private void Shift(int stackNum)
            {
                Console.WriteLine("/// Shifting " + stackNum);
                StackInfo stack = Info[stackNum];

                /* If this stack is at its full capacity, then you need
                 * to move the next stack over by one element. This stack
                 * can now claim the freed index. */
                if (stack.size >= stack.capacity)
                {
                    int nextStack = (stackNum + 1) % Info.Length;
                    Shift(nextStack);
                    stack.capacity++;  // claim index that next stack lost
                }

                /* Shift all elements in stack over by one. */
                int index = stack.LastCapacityIndex();
                while (stack.IsWithinStackCapacity(index))
                {
                    Values[index] = Values[PreviousIndex(index)];
                    index = PreviousIndex(index);
                }

                /* Adjust stack data. */
                Values[stack.start] = 0;   // Clear item
                stack.start = NextIndex(stack.start);  // move start
                stack.capacity--;  // Shrink capacity
            }

            /* Expand stack by shifting over other stacks */
            private void Expand(int stackNum)
            {
                Console.WriteLine("/// Expanding stack " + stackNum);

                Shift((stackNum + 1) % Info.Length);
                Info[stackNum].capacity++;
            }

            /* Push value onto stack num, shifting/expanding stacks as 
             * necessary. Throws exception if all stacks are full. */
            public void Push(int stackNum, int value)
            {
                Console.WriteLine("/// Pushing stack " + stackNum + ": " + value);
                 
                if (AllStacksAreFull()) throw new Q3_01_Exception(EnumException.FullStackException);

                /* If this stack is full, expand it. */
                StackInfo stack = Info[stackNum];
                if (stack.IsFull()) Expand(stackNum);

                /* Find the index of the top element in the array + 1, 
                 * and increment the stack pointer */
                stack.size++;
                Values[stack.LastElementIndex()] = value;
            }

            /* Remove value from stack. */
            public int Pop(int stackNum)
            {
                Console.WriteLine("/// Popping stack " + stackNum);

                StackInfo stack = Info[stackNum];
                if (stack.IsEmpty()) throw new Q3_01_Exception(EnumException.EmptyStackException);

                /* Remove last element. */
                int value = Values[stack.LastElementIndex()];
                Values[stack.LastElementIndex()] = 0;  // Clear item
                stack.size--;  // Shrink size
                return value;
            }

            /* Get top element of stack.*/
            public int Peek(int stackNum)
            {
                StackInfo stack = Info[stackNum];
                return Values[stack.LastElementIndex()];
            }

            public int[] GetValues()
            {
                return Values;
            }

            public int[] GetStackValues(int stackNum)
            {
                StackInfo stack = Info[stackNum];
                int[] items = new int[stack.size];
                for (int i = 0; i < items.Length; i++)
                {
                    items[i] = Values[AdjustIndex(stack.start + i)];
                }
                return items;
            }
        }

        #endregion MultiStack

        private static void QuestionA()
        {
            FixedMultiStack stacks1 = new FixedMultiStack(4);
            PrintFixedMultiStacks(stacks1);
            stacks1.Push(0, 10);
            PrintFixedMultiStacks(stacks1);
            stacks1.Push(1, 20);
            PrintFixedMultiStacks(stacks1);
            stacks1.Push(2, 30);
            PrintFixedMultiStacks(stacks1);
            
            stacks1.Push(1, 21);
            PrintFixedMultiStacks(stacks1);
            stacks1.Push(0, 11);
            PrintFixedMultiStacks(stacks1);
            stacks1.Push(0, 12);
            PrintFixedMultiStacks(stacks1);
            
            stacks1.Pop(0);
            PrintFixedMultiStacks(stacks1);
            
            stacks1.Push(2, 31);
            PrintFixedMultiStacks(stacks1);
            
            stacks1.Push(0, 13);
            PrintFixedMultiStacks(stacks1);
            stacks1.Push(1, 22);
            PrintFixedMultiStacks(stacks1);
            
            stacks1.Push(2, 31);
            PrintFixedMultiStacks(stacks1);
            stacks1.Push(2, 32);
            PrintFixedMultiStacks(stacks1);
        }

        private static void QuestionB()
        {
            MultiStack stacks2 = new MultiStack(3, 4);
            PrintMultiStacks(stacks2);
            stacks2.Push(0, 10);
            PrintMultiStacks(stacks2);
            stacks2.Push(1, 20);
            PrintMultiStacks(stacks2);
            stacks2.Push(2, 30);
            PrintMultiStacks(stacks2);
            
            stacks2.Push(1, 21);
            PrintMultiStacks(stacks2);
            stacks2.Push(0, 11);
            PrintMultiStacks(stacks2);
            stacks2.Push(0, 12);
            PrintMultiStacks(stacks2);
            
            stacks2.Pop(0);
            PrintMultiStacks(stacks2);
            
            stacks2.Push(2, 31);
            PrintMultiStacks(stacks2);
            
            stacks2.Push(0, 13);
            PrintMultiStacks(stacks2);
            stacks2.Push(1, 22);
            PrintMultiStacks(stacks2);
            
            stacks2.Push(2, 31);
            PrintMultiStacks(stacks2);
            stacks2.Push(2, 32);
            PrintMultiStacks(stacks2);
            stacks2.Push(2, 33);
            PrintMultiStacks(stacks2);
            stacks2.Push(2, 34);
            PrintMultiStacks(stacks2);
            
            stacks2.Pop(1);
            PrintMultiStacks(stacks2);
            stacks2.Push(2, 35);
            PrintMultiStacks(stacks2);
            
            Console.WriteLine("Final Stack: " + AssortedMethods.ArrayToString(stacks2.GetValues()));
        }

        public static void Q3_01_Run()
        {
            // QuestionA();
            QuestionB();
        }
    }
}