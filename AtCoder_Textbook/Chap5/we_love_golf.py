# A - We Love Golf
# https://atcoder.jp/contests/abc165/tasks/abc165_a

#################################
# Anser 1
#################################
# K
K = int(input())

# A 以上 B 以下
A, B = map(int, input().split())
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

#################################
# Anser 2
#################################
K = int(input())
A, B = map(int, input().split())
# K の倍数が A 以上 B 以下の範囲の中にあるかどうかを記録する変数
ok = False

# A から B まで順番に調べる。調べている数を x とする
for x in range(A, B + 1):
    # 調べている数 x が K で割り切れるかどうか
    if x % K == 0:
        ok = True
        break

if ok:
    print("OK")
else:
    print("NG")

#################################
# Anser 3
#################################
K = int(input())
A, B = map(int, input().split())
# K の倍数が A 以上 B 以下の範囲の中にあるかどうかを記録する変数
ok = False

x = A // K
u = B // K
# x < u ならば K の倍数が A 以上 B 以下の範囲の中にある
if x < u:
    ok = True

if A % K == 0:
    ok = True

if ok:
    print("OK")
else:
    print("NG")
#################################
