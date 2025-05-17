using System.Text;

namespace KyogiProgrammingNoTessoku._2
{
    /*
        https://atcoder.jp/contests/tessoku-book/tasks/tessoku_book_ce

        問題文
            太郎君はくじを N 回引き，i 回目の結果は A i​  でした．A i​ =1 のときアタリ，A i​ =0 のときハズレを意味します．
            「L 回目から R 回目までの中では，アタリとハズレどちらが多いか？」という形式の質問が Q 個与えられるので，
            それぞれの質問に答えるプログラムを作成してください．

        制約
            1≤N,Q≤10 5
            0≤A i​ ≤1
            1≤L i​ ≤R i​ ≤N
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
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int N = input[0];
            int Q = input[1];


            /*
            //　別解1 上記の改善
            */
        }
    }
}
