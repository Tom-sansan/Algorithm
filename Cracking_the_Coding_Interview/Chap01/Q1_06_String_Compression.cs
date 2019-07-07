//using ctci.Contracts;
using System;
using System.Text;

namespace ExChapter01
{
    public class Q1_06_String_Compression
    {
        private static int CountCompression(string str)
        {
            if (String.IsNullOrEmpty(str)) return 0;

            var last = str[0];
            int size = 0, count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == last)
                    count++;
                else
                {
                    last = str[i];
                    size += 1 + String.Format("{0}", count).Length;
                    count = 1;
                }
            }
            size += 1 + String.Format("{0}", count).Length;
            return size;
        }

        private static string CompressBad(string str)
        {
            var compressString = string.Empty;
            var countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;
                if (i + 1 >= str.Length || str[i] != str[i+1])
                {
                    compressString += string.Empty + str[i] + countConsecutive;
                    countConsecutive = 0;
                }
            }
            return compressString.Length < str.Length ? compressString : str;
        }

        private static string CompressBetter(string str)
        {
            StringBuilder sb = new StringBuilder();
            var countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;
                if (i + 1 >= str.Length || str[i] != str[i+1])
                {
                    sb.Append(str[i]).Append(countConsecutive);
                    countConsecutive = 0;
                }
            }
            return sb.Length < str.Length ? sb.ToString() : str;
        }
        private static string CompressBest(string str)
        {
            var size = CountCompression(str);
            if (size >= str.Length) return str;

            var sb = new StringBuilder();
            char last = str[0];
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == last) count++;
                else
                {
                    sb.Append(last).Append(count);
                    last = str[i];
                    count = 1;
                }
            }
            return sb.Append(last).Append(count).ToString();
        }
        public static void Q1_06_Run()
        {
            string[] strList = {
                "abbccccccde"
                ,"abbbbbbbbbbde"
            };
            foreach (var item in strList)
            {
                Console.WriteLine("Original:  {0}", item);
                Console.WriteLine("CompressBad:  {0}", CompressBad(item));
                Console.WriteLine("CompressBetter:  {0}", CompressBetter(item));
                Console.WriteLine("CompressBest:  {0}", CompressBest(item));

            }
        }
    }
}