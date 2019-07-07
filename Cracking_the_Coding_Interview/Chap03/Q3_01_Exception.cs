using System;

namespace ExChapter03
{
    public enum EnumException
    {
        FullStackException = 0,
        EmptyStackException = 1
    }
    public class Q3_01_Exception : Exception
    {
        public Q3_01_Exception() : base() { }

        public Q3_01_Exception(EnumException exception) : base()
        {
            Console.WriteLine(nameof(exception));
        }
    }
}