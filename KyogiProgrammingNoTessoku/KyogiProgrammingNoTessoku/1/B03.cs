namespace KyogiProgrammingNoTessoku._1
{
    /*
        問題文
            N 個の商品があり、商品 i (i=1,2,⋯,N) の価格は Ai 円です。
            異なる 3 つの商品を選び、合計価格をピッタリ 1000 円にする方法は存在しますか。

        制約
            3 ≤N≤ 100
            1 ≤Ai≤ 1000
            入力はすべて整数

        入力
            入力は以下の形式で標準入力から与えられます。
            N
            A1 A2 ⋯ AN

        出力
            合計を 1000 円にする方法が存在する場合 Yes、そうでない場合 No と出力してください。
    */
    internal class B03
    {
        public static void Supermarket1()
        {
            int N = int.Parse(Console.ReadLine());
            var priceList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            for (int i = 0; i < N; i++)
                for (int j = i + 1; j < N; j++)
                    for (int k = j + 1; k < N; k++)
                        if (priceList[i] + priceList[j] + priceList[k] == 1000)
                        {
                            Console.WriteLine("Yes");
                            return;
                        }
            Console.WriteLine("No");

            /* 尺取り方（Two pointers）TODO
            priceList.Sort(); // ソート O(N log N)
            // O(N^2)
            for (int i = 0; i < N - 2; i++) // iは最後から3番目まで
            {
                int target = 1000 - priceList[i];
                int left = i + 1;
                int right = N - 1;

                while (left < right) // leftとrightが重なるまで
                {
                    int currentSum = priceList[left] + priceList[right];

                    if (currentSum == target)
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                    else if (currentSum < target)
                    {
                        // 合計を大きくしたいので、左を動かす
                        left++;
                    }
                    else // currentSum > target
                    {
                        // 合計を小さくしたいので、右を動かす
                        right--;
                    }
                }
            }
            */
        }
    }
}
