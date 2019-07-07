//using ctci.Contracts;
using System;
using System.Collections.Generic;

namespace ExChapter01
{
    public class Q1_04_Palindrome_Permutation
    {
        private static int GetCharNumber(char c)
        {
            var val = char.ToLower(c) - 'a';
            if (0 <= val && val <= 25)
                return val;
            return -1;
        }

        private static int[] BuildCharFrequencyTable(String phrase)
        {
            int[] table = new int[26];
            foreach (char c in phrase)
            {
                int x = GetCharNumber(c);
                if (x != -1)
                    table[x]++;
            }
            return table;
        }

#region Solution 1
        private static bool CheckMaxOneOdd(int[] table)
        {
            bool foundOdd = false;
            foreach (var count in table)
            {
                if (count % 2 == 1)
                {
                    if(foundOdd)
                        return false;
                    foundOdd = true;
                }
            }
            return true;
        }

        private static bool IsPermutationOfPalindrome1(String phrase)
        {
            int[] table = BuildCharFrequencyTable(phrase);
            return CheckMaxOneOdd(table);
        }

#endregion

#region Solution 2
        
        private static bool IsPermutationOfPalindrome2(String phrase)
        {
            int countOdd = 0;
            int[] table = new int[26];
            foreach (char c in phrase.ToCharArray())
            {
                int x = GetCharNumber(c);
                if (x != -1)
                {
                    table[x]++;
                    if (table[x] % 2 == 1)
                        countOdd++;
                    else
                        countOdd--;
                }
            }
            return countOdd <= 1;
        }

#endregion

#region Solution 3

        // Toggle the inth bit in the integer.
        private static int Toggle(int bitVecor, int index)
        {
            if (index <= 0) return bitVecor;

            int mask = 1 << index;
            if ((bitVecor & mask) == 0)
                bitVecor |= mask;
            else
                bitVecor &= ~mask;
            return bitVecor;

        }

        // Create bit vector for string. For each letter with value i, toggle the ith bit.
        public static int MarkBitForOddCharacterCount(String phrase)
        {
            int bitVector = 0;
            foreach (var c in phrase.ToCharArray())
            {
                int x = GetCharNumber(c);
                bitVector = Toggle(bitVector, x);
            }
            return bitVector;
        }

        // Check that ecactly one bit is set by subtracting one from the integer and ANDing it with the original integer.
        // Example;
        // 00010000 - 1 = 00001111 (16 - 1 = 15 = 00001111)
        // 00010000 & 00001111 = 0
        public static bool CheckExactlyOneBitSet(int bitVecor)
        {
            return (bitVecor & (bitVecor - 1)) == 0;
        }
        
        public static bool IsPermutationOfPalindrome3(String phrase)
        {
            int bitVector = MarkBitForOddCharacterCount(phrase);
            return bitVector == 0 || CheckExactlyOneBitSet(bitVector);
        }

#endregion

        public static void Q1_04_Run()
        {
            String[] strings = {
                //"Rats live on no evil star",
                //"A man, a plan, a canal, panama",
                "Lleve",
                //"Tacotac",
                "asda"};

            foreach (String s in strings)
            { 
                bool a = IsPermutationOfPalindrome1(s);
                bool b = IsPermutationOfPalindrome2(s);
                bool c = IsPermutationOfPalindrome3(s);
                Console.WriteLine(s);
                if (a == b && b == c)
                {
                    Console.WriteLine("Agree: " + a);
                }
                else {
                    Console.WriteLine("Disagree: " + a + ", " + b + ", " + c);
                }
                Console.WriteLine();
            }
        }
    }
}