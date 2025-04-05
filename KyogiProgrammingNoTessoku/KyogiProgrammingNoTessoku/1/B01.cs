namespace KyogiProgrammingNoTessoku._1
{
    internal class B01
    {
        public static int Solve()
        {
            /*
            string[] input = Console.ReadLine().Split(' ');
            return Convert.ToInt32(input[0]) + Convert.ToInt32(input[1]);
            */
            return Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Sum();
        }
    }
}
