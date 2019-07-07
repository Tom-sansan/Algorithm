//using ctci.Contracts;
using System;
using System.Collections.Generic;

namespace ExChapter01
{
    public class Q1_05_One_Away_A
    {
        public static bool OneEditReplace(String s1, String s2)
        {
            bool foundDifference = false;
            for (int i = 0; i < s1.Length; i++)
            {
                if(s1[i] != s2[i])
                {
                    if (foundDifference) return false;
                    foundDifference = true;
                }
            }
            return true;
        }

        // Check if you can insert a character into s1 to make s2.
        public static bool OneEditInsert(String s1, String s2)
        {
            int index1 = 0, index2 = 0;
            while (index2 < s2.Length && index1 < s1.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    if (index1 != index2) return false;
                    index2++;
                }
                else
                {
                    index1++;
                    index2++;
                }
            }
            return true;
        }

        public static bool OneEditAway1(String first, String second)
        {
            if(first.Length == second.Length)
            {
                return OneEditReplace(first, second);
            }
            else if (first.Length + 1 == second.Length)
            {
                return OneEditInsert(first, second);
            }
            else if (first.Length - 1 == second.Length)
            {
                return OneEditInsert(second, first);
            }
            return false;
        }

        public static bool OneEditAway2(String first, String second)
        {
            // Length check.
            if (Math.Abs(first.Length - second.Length) > 1) return false;

            // Get shorter and longer string.
            String s1 = first.Length < second.Length ? first : second;  // shorter string
            String s2 = first.Length < second.Length ? second : first;  // longer string

            int index1 = 0, index2 = 0;
            bool foundDifference = false;
            while (index2 < s2.Length && index1 < s1.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    // Ensure that this is the first difference found.
                    if (foundDifference) return false;
                    foundDifference = true;
                    if (s1.Length == s2.Length) index1++;   // on replace, move shoter pointer
                }
                else
                {
                    index1++;   // if matching, move shorter pointer
                }
                index2++;   // Always move pointer for longer string
            }
            return true;
        }
        public static void Q1_05_Run()
        {
            String[,] str = {
                {"pse", "pale"},
                {"pales", "pale"},
                {"pale", "bale"},
                {"pale", "bake"}};
            for (int i = 0; i < str.Length - 4; i++)
            {
                bool isOneEdit = OneEditAway1(str[i, 0], str[i, 1]);
                Console.WriteLine("{0}, {1}: {2}", str[i, 0], str[i, 1], isOneEdit);

                bool isOneEdit2 = OneEditAway2(str[i, 0], str[i, 1]);
                Console.WriteLine("{0}, {1}: {2}", str[i, 0], str[i, 1], isOneEdit2);
            }
        }
    }
}