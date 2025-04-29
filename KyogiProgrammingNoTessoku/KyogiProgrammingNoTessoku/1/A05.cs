using System.Text;

namespace KyogiProgrammingNoTessoku._1
{
    /*
        https://atcoder.jp/contests/tessoku-book/tasks/tessoku_book_e

        問題文
            赤・青・白の 3 枚のカードがあります。
            太郎君は、それぞれのカードに 1 以上 N 以下の整数を書かなければなりません。
            3 枚のカードの合計を K にするような書き方は何通りありますか。

        制約
            N は 1 以上 3000 以下の整数
            K は 3 以上 9000 以下の整数

        入力
            入力は以下の形式で標準入力から与えられます。
            N K

        出力
            答えを整数で出力してください。
    */
    internal class A05
    {
        public static void ThreeCards()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int N = input[0];
            int K = input[1];
            int count = 0;
            int z = 0;
            // x + y + z = K -> z = K - x - y
            for (int x = 1; x <= N; x++)
                for (int y = 1; y <= N; y++)
                {
                    z = K - x - y;
                    if (z >= 1 && z <= N) count++;
                }
            Console.WriteLine(count);

            /*　別解1
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int N = input[0];
            int K = input[1];
            int count = 0;
            for (int x = 1; x <= N; x++)
            {
                // y の条件: 1 <= y <= N
                // z の条件: 1 <= K - x - y <= N
                //           K - x - N <= y <= K - x - 1
                // y の満たすべき範囲の下限を計算
                int lowerBoundY = Math.Max(1, K - x - N);
                // y の満たすべき範囲の上限を計算
                int upperBoundY = Math.Min(N, K - x - 1);

                // 範囲が存在する場合 (下限 <= 上限) のみカウント
                if (lowerBoundY <= upperBoundY)
                {
                    // 範囲内の整数の個数を加算
                    count += upperBoundY - lowerBoundY + 1;
                }
            }
            Console.WriteLine(count);
            */
        }
    }
}
