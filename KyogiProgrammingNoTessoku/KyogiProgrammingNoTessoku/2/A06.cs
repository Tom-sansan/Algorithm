using System.Text;

namespace KyogiProgrammingNoTessoku._2
{
    /*
        https://atcoder.jp/contests/tessoku-book/tasks/math_and_algorithm_ai

        問題文
            遊園地「ALGO-RESORT」では N 日間にわたるイベントが開催され、i 日目 (1 ≤ i ≤ N) には Ai​ 人が来場しました。
            以下の合計 Q 個の質問に答えるプログラムを作成してください。

            1 個目の質問：L1​ 日目から R1​ 日目までの合計来場者数は？
            2 個目の質問：L2​ 日目から R2​ 日目までの合計来場者数は？
            :
            Q 個目の質問：LQ​ 日目から RQ​ 日目までの合計来場者数は？

        制約
            1 ≤ N,Q ≤ 10^5
            1 ≤ Ai ​≤ 10000
            1 ≤ Li ​≤ Ri ​≤ N
            入力はすべて整数

        入力
            入力は以下の形式で標準入力から与えられます。

            N Q
            A1 A2​ ⋯ AN
            ​L1​ R1
            ​L2​ R2
            :
            LQ RQ

        出力
            全体で Q 行出力してください。
            i 行目 (1≤i≤Q) には、i 個目の質問への答えを整数で出力してください。
    */
    internal class A06
    {
        public static void HowManyGuests()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int N = input[0];
            int Q = input[1];
            // 2行目の入力値を取得
            int[] A = Console.ReadLine().Split().Select(int.Parse).ToArray();
            // 初日からの累積和を求める
            int[] sum = new int[N];
            int total = 0;
            for (int i = 0; i < N; i++)
            {
                total += A[i];
                sum[i] = total;
            }
            // Q行の入力値を取得し、解答を格納
            int[] Answer = new int[Q];
            for (int i = 0; i < Q; i++)
            {
                input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                // RQ日の累積和 - (LQ - 1)日の累積和
                // 配列での考え方：(RQ -1) - (LQ -2)
                // LQの考察：LQが1日目の場合     -> LQ日のは減算しない
                //          LQが2日目の場合     -> LQは1日目を減算する
                //          LQが3日目以降の場合 -> LQは前日までの累積和を減算する
                if (input[0] == 1)
                    Answer[i] = sum[input[1] - 1];
                else if (input[0] == 2)
                    Answer[i] = sum[input[1] - 1] - sum[0];
                else
                    Answer[i] = sum[input[1] - 1] - sum[input[0] - 2];
            }
            // Q行出力する
            for (int i = 0; i < Q; i++) Console.WriteLine(Answer[i]);

            /*
            //　別解1 上記の改善
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int N = input[0];
            int Q = input[1];
            // 2行目の入力値を取得 (A[j] が j+1 日目の来場者数)
            int[] A = Console.ReadLine().Split().Select(int.Parse).ToArray();
            // 累積和配列 S を作成 (サイズ N+1)
            // Aiの最大値が10000, Nが10^5なので、合計は10^9程度。intでOK。
            int[] S = new int[N + 1];
            S[0] = 0;
            // S[k] = k 日目までの合計 (A_1 + ... + A_k)
            for (int k = 0; k < N; k++)
            {
                // A[k] は (k+1)日目の来場者数
                S[k + 1] = S[k] + A[k];
            }
            // Q行の入力値を取得し、解答を格納
            int[] Answer = new int[Q];
            for (int i = 0; i < Q; i++)
            {
                input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                // RQ日の累積和 - (LQ - 1)日の累積和
                // L日目からR日目までの合計は S[R] - S[L-1]
                Answer[i] = S[input[1]] - S[input[0] - 1];
            }
            // Q行出力する
            for (int i = 0; i < Q; i++) Console.WriteLine(Answer[i]);
            */
        }
    }
}
