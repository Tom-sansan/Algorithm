using System;
using System.Collections.Generic;
namespace ExChapter01
{
    public class Q1_02_Check_Permutation
    {
        private static String SortedString(String s)
        {
            var charAsArray = s.ToCharArray();
            Array.Sort(charAsArray);
            return new string(charAsArray);
        }

        private static bool IsPermutation1(String original, String valueToTest)
        {
            if(original.Length != valueToTest.Length) return false;
            /*
            original = SortedString(original);
            valueToTest = SortedString(valueToTest);
            return original.Equals(valueToTest);
            */
            return SortedString(original).Equals(SortedString(valueToTest));
        }

        private static bool IsPermutation2(String original, String valueToTest)
        {
            if (original.Length != valueToTest.Length) return false;
            int[] letters = new int[128];   // Asumption for ASCII
            for (int i = 0; i < original.Length; i++)
            {
                letters[original[i]]++;
            }
            for (int i = 0; i < valueToTest.Length; i++)
            {
                letters[valueToTest[i]]--;
                if(letters[valueToTest[i]] < 0) return false;
            }
            return true;    // there is no negative value, which means there is no positive value as well.
        }

        private static bool IsPermutation3(String original, String valueToTest)
        {
            if (original.Length != valueToTest.Length) return false;

            var letterCount = new Dictionary<char, int>();
            foreach (var character in original)
            {
                if (letterCount.ContainsKey(character))
                    letterCount[character]++;
                else
                    letterCount[character] = 1;
            }
            foreach (var character in valueToTest)
            {
                if (letterCount.ContainsKey(character))
                {
                    letterCount[character]--;
                    if (letterCount[character] < 0) return false;
                }
                else
                    return false;
            }
            return true;
        }
        public static void Q1_02_Run()
        {
            string[][] pairs =
            {
                new string[]{"apple", "papel"},
                new string[]{"carrot", "tarroc"},
                new string[]{"hello", "llloh"}
            };

            foreach (var pair in pairs)
            {
                var word1 = pair[0];
                var word2 = pair[1];
                //var result = IsPermutation1(word1, word2);
                //var result = IsPermutation2(word1, word2);
                var result = IsPermutation3(word1, word2);
                Console.WriteLine("{0}, {1}: {2}", word1, word2, result);
            }
        }
    }
}