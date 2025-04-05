namespace KyogiProgrammingNoTessoku._1
{
    /*
        https://atcoder.jp/contests/tessoku-book/tasks/tessoku_book_c

        問題文
        赤いカードが N 枚あり、それぞれ整数 P1​ ,P2​ ,⋯,P N​  が書かれています。
        また、青いカードが N 枚あり、それぞれ整数 Q1​ ,Q2​ ,⋯,QN​  が書かれています。
        太郎君は、赤いカードの中から 1 枚、青いカードの中から 1 枚、合計 2 枚のカードを選びます。
        選んだ 2 枚のカードに書かれた整数の合計が K となるようにする方法は存在しますか。

        制約
        N は 1 以上 100 以下の整数
        K は 1 以上 100 以下の整数
        P1​ ,P2​ ,⋯,PN​  は 1 以上 100 以下の整数
        Q1​ ,Q2​ ,⋯,QN​  は 1 以上 100 以下の整数
    */
    internal class A03
    {
        public static void TwoCards()
        {
            string[] input = Console.ReadLine().Split(' ');
            int N = int.Parse(input[0]);
            int K = int.Parse(input[1]);
            var pList = new List<int>();
            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < N; i++) pList.Add(int.Parse(input[i]));
            var qList = new List<int>();
            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < N; i++) qList.Add(int.Parse(input[i]));
            foreach (var p in pList)
                foreach (var q in qList)
                    if (p + q == K)
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
            Console.WriteLine("No");

            /*
            string[] input = Console.ReadLine().Split(' ');
            int N = int.Parse(input[0]);
            int K = int.Parse(input[1]);
            var pList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var qList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            // 青いカードの値を HashSet に格納
            var qSet = new HashSet<int>(qList);

            // K = P + q -> p = K - q
            // 赤いカードの各値 p に対して、K - p が青いカードの HashSet に存在するか確認
            foreach (var p in pList)
                if (qSet.Contains(K - p))
                {
                    Console.WriteLine("Yes");
                    return;
                }
            Console.WriteLine("No");
            */
        }
    }
}
