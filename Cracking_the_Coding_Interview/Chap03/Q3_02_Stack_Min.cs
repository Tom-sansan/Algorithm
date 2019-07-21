using System;
using System.Collections;
using Ctci.Library;

namespace ExChapter03
{
    public class Q3_02_Stack_Min
    {
        #region NodeWithMin

        public class NodeWithMin
        {
            public int Value;
            public int Min;

            public NodeWithMin(int value, int min)
            {
                this.Value = value;
                this.Min = min;
            }
        }

        #endregion NodeWithMin

        #region StackWithMin1

        public class StackWithMin1 : Stack
        {
            public void Push(int value)
            {
                int newMin = Math.Min(value, Min());
                base.Push(new NodeWithMin(value, newMin));
            }

            public int Min()
            {
                if (this.Count == 0) return int.MaxValue;
                else return ((NodeWithMin)this.Peek()).Min;
            }

            public int Pop1()
            {
                if (this.Count == 0) return int.MaxValue;
                else return ((NodeWithMin)(this.Pop())).Value;
            }
        }

        #endregion StackWithMin1

        #region StackWithMin2

        private class StackWithMin2 : Stack
        {
            Stack s2;

            public StackWithMin2()
            {
                s2 = new Stack();
            }

            public void Push(int value)
            {
                if (value <= this.Min()) s2.Push(value);
                base.Push(value);
            }

            public int Pop2()
            {
                int value = Convert.ToInt32(base.Pop());
                if (value == this.Min()) s2.Pop();
                return value;
            }

            public int Min()
            {
                if (s2 == null || s2.Count == 0) return int.MaxValue;
                else return Convert.ToInt32(s2.Peek());
            }
        }

        #endregion StackWithMin2

        public static void Q3_02_Run()
        {
            StackWithMin1 stack1 = new StackWithMin1();
            StackWithMin2 stack2 = new StackWithMin2();
            int[] array = {2, 1, 3, 1};
            foreach (int value in array)
            {
                stack1.Push(value);
                stack2.Push(value);
                Console.WriteLine(value + ", ");
            }
            Console.WriteLine('\n');
            
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Popped " + stack1.Pop1() + ", " + stack2.Pop2());
                Console.WriteLine("New min is " + stack1.Min() + ", " + stack2.Min());
            }
        }
    }
}