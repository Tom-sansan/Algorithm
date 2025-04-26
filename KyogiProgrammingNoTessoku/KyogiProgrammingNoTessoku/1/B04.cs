using System.Text;

namespace KyogiProgrammingNoTessoku._1
{
    /*
        https://atcoder.jp/contests/tessoku-book/tasks/tessoku_book_cc

        問題文
            2 進法表記で表された整数 N が与えられます。
            N を 10 進法に変換した値を出力するプログラムを作成してください。

        制約
            N の長さは 1 文字以上 8 文字以下
            N は 0 と 1 からなる
            N の先頭の桁は 1 である

        入力
            入力は以下の形式で標準入力から与えられます。
            N

        出力
            答えを整数で出力してください。
    */
    internal class B04
    {
        public static void BinaryRepresentation2()
        {
            string N = Console.ReadLine();
            int result = 0;
            int count = N.Count();
            foreach (char x in N)
            {
                count--;
                // x - '0': x を整数へ変換
                // 1 << count : 2 の count 乗を計算
                result += (x - '0') * (1 << count);
            }
            Console.WriteLine(result);
            /*　別解1
                // 入力
                string N = Console.ReadLine();

                int result = 0;
                foreach (char c in N)
                {
                    // 現在の結果を2倍して（左シフトして）、新しい桁の値を加える
                    result = (result << 1) + (c - '0');
                    // もしくは result = result * 2 + (c - '0'); でも同じ
                }

                // 出力
                Console.WriteLine(result);
            */
        }
    }
}
