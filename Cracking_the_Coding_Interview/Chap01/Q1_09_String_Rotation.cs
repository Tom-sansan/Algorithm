using System;

namespace ExChapter01
{
    public class Q1_09_String_Rotation
    {
        public static bool IsSbustring(String big, String small)
        {
            return big.IndexOf(small) >= 0;
        }

        public static bool IsRotation(String s1, String s2)
        {
            var len = s1.Length;
            // Check that s1 and s2 are equal length and not empty.
            if (len == s2.Length && len > 0)
            {
                // concatenate s1 and s1 within new buffer
                var s1S1 = s1 + s1;
                return IsSbustring(s1S1, s2);
            }
            return false;
        }
        public static void Q1_09_Run()
        {
            string[][] pairs =
            {
                new string[]{"apple", "pleap"},
                new string[]{"waterbottle", "erbottlewat"},
                new string[]{"camera", "macera"}
            };

            foreach (var pair in pairs)
            {
                var word1 = pair[0];
                var word2 = pair[1];
                var isRotation = IsRotation(word1, word2);
                Console.WriteLine("{0}, {1}: {2}", word1, word2, isRotation);
            }
        }
    }
}