using System.Text;

namespace KyogiProgrammingNoTessoku._2
{
    /*
        https://atcoder.jp/contests/tessoku-book/tasks/tessoku_book_ce

        問題文
            太郎君はくじを N 回引き，i 回目の結果は Ai​ でした．Ai​ =1 のときアタリ，Ai​ =0 のときハズレを意味します．
            「L 回目から R 回目までの中では，アタリとハズレどちらが多いか？」という形式の質問が Q 個与えられるので，
            それぞれの質問に答えるプログラムを作成してください．

        制約
            1 ≤ N,Q≤ 10 5
            0 ≤ Ai ​≤ 1
            1 ≤ Li​ ≤ Ri​≤ N
            入力はすべて整数

        入力
            入力は以下の形式で標準入力から与えられます．

            N
            A1​ A2​ ⋯ AN
            ​Q
            L1​ R1
            ⋮
            LQ​ RQ
​
        出力
            i=1,2,3,…,Q それぞれについて，アタリの方が多い場合 win を，ハズレの方が多い場合 lose を，
            アタリとハズレが同じ場合 draw を，一行ずつ，総計 Q 行に出力してください．
    */
    internal class B06
    {
        public static void Lottery()
        {
            int N = int.Parse(Console.ReadLine());
            int[] AN = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] sumList = new int[N + 1];
            int sum = 0;
            // 累積和を求める
            for (int i = 0; i < N; i++)
            {
                sum += AN[i];
                sumList[i + 1] = sum;
            }
            // 質問に答える
            int Q = int.Parse(Console.ReadLine());
            int[] LR = new int[2];
            string[] answers = new string[Q];
            for (int i = 0; i < Q; i++)
            {
                LR = Console.ReadLine().Split().Select(int.Parse).ToArray();
                // 質問の範囲内の合計を求める
                int total = sumList[LR[1]] - sumList[LR[0] - 1];
                // アタリが多いかハズレが多いか考察する
                // 1. L回目からR回目の範囲の長さを求める
                float range = LR[1] - LR[0] + 1;
                // 2. 1.の長さを2で割る（小数点以下切り捨て）
                float criteria = range / 2;
                // 解答を出力（初期値を draw とする）
                answers[i] = "draw";
                // 範囲の合計値が criteria よりも大きければ勝ち
                if (criteria < total) answers[i] = "win";
                else if (criteria > total) answers[i] = "lose";
            }
            // 解答を出力
            foreach (var answer in answers) Console.WriteLine(answer);

            /*
            //　別解1 上記の改善
            */

            // N とくじの結果 A を読み込む
            int n = int.Parse(Console.ReadLine());
            int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // アタリ(1)の数の累積和を計算する
            // prefixSum[i] は、1回目からi回目までのアタリの合計数を保持する
            int[] prefixSum = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + a[i];
            }

            // 質問の数 Q を読み込む
            int q = int.Parse(Console.ReadLine());

            // 出力結果を効率的に構築するための StringBuilder
            var answerBuilder = new StringBuilder();

            // Q個の質問に答える
            for (int i = 0; i < q; i++)
            {
                // 質問の範囲 L, R を読み込む
                int[] lr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int l = lr[0];
                int r = lr[1];

                // 1. 区間内のアタリの数を計算
                int winCount = prefixSum[r] - prefixSum[l - 1];

                // 2. 区間の長さを計算
                int rangeLength = r - l + 1;

                // 3. ハズレの数を計算
                int loseCount = rangeLength - winCount;

                // 4. 勝敗を判定し、結果をStringBuilderに追加
                if (winCount > loseCount)
                {
                    answerBuilder.AppendLine("win");
                }
                else if (winCount < loseCount)
                {
                    answerBuilder.AppendLine("lose");
                }
                else
                {
                    answerBuilder.AppendLine("draw");
                }
            }
            // 構築したすべての解答を一度に出力する
            Console.Write(answerBuilder.ToString());
        }
    }
}
