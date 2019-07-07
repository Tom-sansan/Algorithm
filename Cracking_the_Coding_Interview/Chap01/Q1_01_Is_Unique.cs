using System;
using System.Collections.Generic;

namespace ExChapter01
{
    class Q1_01_Is_Unique
    {
        private static bool IsUniqueChars1(String str)
        {
            if (str.Length > 128) return false; // ASCII from 0 to 127, Extended ASCII codes from 128 to 255, so Length > 256
            bool[] char_set = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];               // 文字の10進数を返す Javaの場合は, str.charAt(i)
                if(char_set[val]) return false; // この文字は既に文字列中に現れている
                char_set[val] = true;
            }
            return true;
        }

        private static bool IsUniqueChars2(String str)
        {
            var hashset = new HashSet<char>();
            foreach (var c in str)
            {
                if(hashset.Contains(c)) return false;
                hashset.Add(c);
            }
            return true;
        }
        
        private static bool IsUniqueChars3(String str)
        {
            if(str.Length > 256) return false;
            var checker = 0;
            for (int i = 0; i < str.Length; i++)
            {
                var val = str[i] - 'a';
                if ((checker & (1 << val)) > 0) return false;
                checker |= (1 << val);
            }
            return true;
        }

        public static void Q1_01_Run()
        {
            string[] words = { "abcde", "hello", "apple", "kite", "padle" };
            foreach (var word in words)
            {
                Console.WriteLine(word + ": " + IsUniqueChars1(word) + " " + IsUniqueChars2(word)+ " " + IsUniqueChars3(word));
            }
        }
    }
}