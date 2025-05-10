using System.Text;

namespace KyogiProgrammingNoTessoku._1
{
    /*
        問題文
            N 枚のカードがあり、1 から N までの番号が付けられています。カード i には整数 Ai が書かれています。
            カードの中からいくつかを選び、書かれた整数の合計が S となるようにする方法は存在しますか。

        制約
            1 <= i <= 22
        入力
            入力は以下の形式で標準入力から与えられます。
            N S
            A1, A2, A3,.., Ai

        出力
            存在する場合は Yes、しない場合は No を出力しなさい。
    */
    internal class Column2
    {
        // ビット全検索
        public static void Column()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int N = input[0];
            int S = input[1];
            int[] A = Console.ReadLine().Split().Select(int.Parse).ToArray();
            // 全探索 (sumは書かれた整数の合計 / answerは現時点での答え)
            bool answer = false;
            // 0 から 2^N - 1 までの整数を試す (部分集合の全パターン)
            for (int i = 0; i < (1 << N); i++)
            {
                int sum = 0;
                // 各ビット j が立っているかチェック
                for (int j = 0; j < N; j++)
                {
                    // i の j 番目のビットが1かどうか (j番目のカードを選ぶかどうか)
                    if (((i >> j) & 1) == 1)
                        // j番目のカードの数を合計に加える
                        sum += A[j];
                }
                // 合計が S と一致するか
                if (sum == S)
                {
                    answer = true;
                    // 合計がKになる組み合わせが見つかったら探索を終了
                    break;
                }
            }
            // 出力
            Console.WriteLine(answer ? "Yes" : "No");
        }

        // 動的計画法 (DP) 
        /*　別解1
            DPを用いたC#コード (メモリ: O(N×K))

            // 入力
            string[] inputNK = Console.ReadLine().Split();
            int N = int.Parse(inputNK[0]);
            int K = int.Parse(inputNK[1]);

            int[] A = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // DPテーブルの初期化 (サイズ N+1 x K+1)
            bool[,] dp = new bool[N + 1, K + 1];

            // 初期条件: 0枚のカードで合計0は可能
            dp[0, 0] = true;

            // DP計算
            for (int i = 1; i <= N; i++)
            {
                int currentCardValue = A[i - 1]; // i番目のカードの値 (Aは0ベースなのでi-1)
                for (int j = 0; j <= K; j++)
                {
                    // i番目のカードを使わない場合 (前の状態を引き継ぐ)
                    if (dp[i - 1, j])
                    {
                        dp[i, j] = true;
                        continue; // このjについてはtrueが確定
                    }

                    // i番目のカードを使う場合
                    if (j >= currentCardValue && dp[i - 1, j - currentCardValue])
                    {
                        dp[i, j] = true;
                    }
                }
            }

            // 出力
            Console.WriteLine(dp[N, K] ? "Yes" : "No");
        */

        /*　別解2
            DPを用いたC#コード (メモリ削減版: O(K))
            
            // 入力
            string[] inputNK = Console.ReadLine().Split();
            int N = int.Parse(inputNK[0]);
            int K = int.Parse(inputNK[1]);

            int[] A = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // DPテーブルの初期化 (サイズ K+1)
            bool[] dp = new bool[K + 1];

            // 初期条件: 合計0は可能
            dp[0] = true;

            // DP計算
            for (int i = 0; i < N; i++) // 各カードについて
            {
                int currentCardValue = A[i];
                // jを降順にループさせるのが重要！
                // 昇順だと、同じカードを複数回使ってしまう計算になる
                for (int j = K; j >= currentCardValue; j--)
                {
                    // カードA[i]を使って合計jを作れるのは、
                    // カードA[i]を使わずに合計j-A[i]が作れていた場合
                    if (dp[j - currentCardValue])
                    {
                        dp[j] = true;
                    }
                }
            }

            // 出力
            Console.WriteLine(dp[K] ? "Yes" : "No");
        */
    }
}