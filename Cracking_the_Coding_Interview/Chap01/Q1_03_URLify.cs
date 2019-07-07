//using ctci.Contracts;
using System;
using System.Collections.Generic;

namespace ExChapter01
{
    public class Q1_03_URLify
    {
        private static void ReplaceSpaces1(char[] str, int trueLength)
        {
            int spaceCount = 0, index, i = 0;
            for (i = 0; i < trueLength; i++)
            {
                if (str[i] == ' ') spaceCount++;
            }

            index = trueLength + spaceCount * 2;
            if (trueLength < str.Length) str[trueLength] = '\0';    // The end of array
            for (i = trueLength - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[index - 1] = '0';
                    str[index - 2] = '2';
                    str[index - 3] = '%';
                    index = index - 3;
                } else {
                    str[index - 1] = str[i];
                    index--;
                }
            }
        }

        static int Count_the_number_of_space(char[] input)
        {
            var spaceCount = 0;
            foreach (var character in input)
            {
                if (character == ' ') spaceCount++;
            }
            return spaceCount;
        }

        private static void ReplaceSpaces2(char[] input, int length)
        {
            var space = new[] {'0', '2', '%'};
            var spaceCount = Count_the_number_of_space(input);
            // calculate new string size
            var index = length + spaceCount * 2;
            
            void SetCharsAndMoveIndex(params char[] chars)
            {
                foreach (var c in chars)
                    input[index--] = c;
            }
            // Copying the characters backwards and inserting %20
            for (var indexSource = length - 1; indexSource >= 0; indexSource--)
                if (input[indexSource] == ' ')
                    SetCharsAndMoveIndex(space);
                else SetCharsAndMoveIndex(input[indexSource]);
        }

        public static void Q1_03_Run()
        {
            const string input = "abc d e f"; // input.Length == 9;
            var characterArray = new char[input.Length + 3 * 2 + 1];

            for (int i = 0; i < input.Length; i++)
            {
                characterArray[i] = input[i];
            }

            //ReplaceSpaces1(characterArray, input.Length);
            ReplaceSpaces2(characterArray, input.Length);
            Console.WriteLine("{0} -> {1}", input, new string(characterArray));
        }
    }
}