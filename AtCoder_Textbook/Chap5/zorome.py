# A - ゾロ目数
# https://atcoder.jp/contests/arc046/tasks/arc046_a

# 入力値
N = int(input())
# 結果を示す変数
result = 0
# インクリメント値
increment = 1
# 処理
for i in range(1, N + 1):
    if i != 1  and (i - 1) % 9 == 0:
        increment = increment * 10 + 1
        result = increment
    else:
        result = result + increment
# 結果表示
print(result)

'''
index	result	increment
1	1	
2	2	    1
3	3	    1
4	4	    1
5	5	    1
6	6	    1
7	7	    1
8	8	    1
9	9	    1
10	11	    2
11	22	    11
12	33	    11
13	44	    11
14	55	    11
15	66	    11
16	77	    11
17	88	    11
18	99	    11
19	111	    12
20	222	    111
21	333	    111
22	444	    111
23	555	    111
24	666	    111
25	777	    111
26	888	    111
27	999	    111
28	1111	112
29	2222	1111
30	3333	1111
31	4444	1111
32	5555	1111
33	6666	1111
34	7777	1111
35	8888	1111
36	9999	1111
37	11111	1112
'''

#################################
# Anser of Text
#################################
import math

n = int(input())

# N番目のゾロ目の桁数
x = math.ceil(N / 9)

# N番目のゾロ目の数字
y = n % 9
if y == 0:
    y = 9

# 出力用変数
ans1 = ''

# 出力はyがx桁並んだ数値
for _ in range(x):
    ans1 += str(y)

print(ans1)
#################################
# Anser of Text - Brute Force
#################################
n = int(input())

# 今までに出てきたゾロ目数の数
z = 0

# 出力用変数
ans2 = 0
# 1 から 555555 までの整数をすべて調べる。調べている数を i とする
for i in range(1, 555555 + 1):
    # i がソロ目かどうか調べるために、i を文字列にした si を作る
    si = str(i)

    # i がゾロ目数だったかどうかを保存する変数
    ok = True

    # si の全ての文字が si の 0 文字目と同じかどうか
    # si の 0 文字目と同じ文字が含まれていたら、i はゾロ目ではない
    for s in si:
        if s != si[0]:
            ok = False
    
    # i がゾロ目数のとき、出てきたゾロ目数の数を 1 増やす
    if ok:
        z += 1

    # i がゾロ目数で、n 番目に出てきたゾロ目数ならば、答えとして保存する
    if ok and z == n:
        ans2 = i

print(ans2)
#################################