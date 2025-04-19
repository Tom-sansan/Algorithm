using System.Text;

namespace KyogiProgrammingNoTessoku._1
{
    /*
        https://atcoder.jp/contests/tessoku-book/tasks/tessoku_book_d

        問題文
            整数 N が 10 進法表記で与えられます。
            N を 2 進法に変換した値を出力するプログラムを作成してください。

        制約
            N は 1 以上 1000 以下の整数

        入力
            入力は以下の形式で標準入力から与えられます。
            N

        出力
            N を 2 進法に変換した値を、10 桁で出力してください。
            桁数が足りない場合は、左側を 0 で埋めてください。
    */
    internal class A04
    {
        public static void BinaryRepresentation1()
        {
            int N = int.Parse(Console.ReadLine());
            var result = new StringBuilder();
            int count = 10;
            while (N > 0)
            {
                result.Insert(0, N % 2 > 0 ? 1 : 0);
                N = N / 2;
                count--;
            }
            for (; count > 0; count--) result.Insert(0, 0);
            Console.WriteLine(result);
            /*　別解1
                Convert.ToString(N, 2) で N を 2 進数の文字列に変換し、PadLeft(10, '0') で文字列の左側を '0' で埋めて 10 桁にしています。
                
                int N = int.Parse(Console.ReadLine());
                string binaryString = Convert.ToString(N, 2).PadLeft(10, '0');
                Console.WriteLine(binaryString);

                別解2
                この方法では、あらかじめ 10 個の char 型配列を用意し、下位ビットから順に '0' か '1' を格納しています。
                N & 1 で最下位ビットが 1 かどうかを判定し、N >>= 1 で N を 1 ビット右にシフトしています。
                最後に char 配列から文字列を生成して出力しています。

                int N = int.Parse(Console.ReadLine());
                char[] binaryChars = new char[10];
                for (int i = 9; i >= 0; i--)
                {
                    if ((N & 1) == 1)
                    {
                        binaryChars[i] = '1';
                    }
                    else
                    {
                        binaryChars[i] = '0';
                    }
                    N >>= 1; // N を 1 ビット右シフト
                }
                Console.WriteLine(new string(binaryChars));

                別解3
                / 上の桁から順番に「2 進法に変換した値」を求める
                for (int x = 9; x >= 0; x--) {
                    int wari = (1 << x);            // 2 の x 乗
                    Console.Write((N / wari) % 2);  // 割り算の結果に応じて 0 または 1 の出力
                }
                Console.WriteLine(); // 最後に改行する
            */
        }
    }
}
