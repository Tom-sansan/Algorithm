# A - We Love Golf
# https://atcoder.jp/contests/abc165/tasks/abc165_a

# K
K = int(input())

# A 以上 B 以下
A, B = list(map(int, input().split()))
# K の 倍数
X = 0
# 結果表示変数
result = 'NG'
while X <= B:
    X += K
    if (A <= X <= B):
        result = 'OK'
        break

# 結果を表示
print(result)
