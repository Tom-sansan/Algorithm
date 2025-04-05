namespace KyogiProgrammingNoTessoku._1
{
    internal class A02
    {
        public static string Solve()
        {
            /*
            string[] x = Console.ReadLine().Split(' ');
            string[] y = Console.ReadLine().Split(' ');

            int N = Convert.ToInt32(x[0]);
            int X = Convert.ToInt32(x[1]);
            for (int i = 0; i < N; i++)
            {
                if (Convert.ToInt32(y[i]) == X) return "Yes";
            }
            return "No";
            */

            string[] input = Console.ReadLine().Split(' ');
            int N = int.Parse(input[0]);
            int X = int.Parse(input[1]);

            string[] array = Console.ReadLine().Split(' ');
            for (int i = 0; i < N; i++)
                if (int.Parse(array[i]) == X) return "Yes";
            return "No";
        }
    }
}
