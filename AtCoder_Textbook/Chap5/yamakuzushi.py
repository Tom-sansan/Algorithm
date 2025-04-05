# C - 山崩し
# https://atcoder.jp/contests/past202004-open/tasks/past202004_c

# 縦 N を指定
N = int(input())

# マスの2次元配列
M = []

# 入力値
for _ in range(0, N):
    row = list(input())
    M.append(row)

# 縦の開始位置
n = N - 1
# 横マス
W = 2 * N - 1
# 判定処理
for i in reversed(range(0, n)):
    for j in range(1, W):
        if M[i][j] == "#" and M[i][j] != "X":
            if M[i + 1][j - 1] == "X" or M[i + 1][j] == "X" or M[i + 1][j + 1] == "X":
                M[i][j] = "X"

# 結果表示
for i in range(N):
    print(''.join(M[i]))
