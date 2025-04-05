namespace KyogiProgrammingNoTessoku._1
{
    // A 以上 B 以下の整数のうち、100 の約数であるものは存在しますか。
    internal class B02
    {
        public static void DivisorCheck()
        {
            string[] input = Console.ReadLine().Split(' ');
            int A = int.Parse(input[0]);
            int B = int.Parse(input[1]);
            for (int i = A; i <= B; i++)
            {
                if (100 % i == 0)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }
            Console.WriteLine("No");
        }
    }
}
