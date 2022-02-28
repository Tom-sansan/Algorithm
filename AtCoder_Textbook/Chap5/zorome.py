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