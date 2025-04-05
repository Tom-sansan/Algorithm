# C - Takahashi's Information
# https://atcoder.jp/contests/abc088/tasks/abc088_c

# 3x3の2次元配列
C = []

for _ in range(3):
    # Cの1行分の1次元配列
    row = list(map(int, input().split()))
    C.append(row)

# 結果
result = True

# Cの0列目と1列目の差を調べ、全て同じか確認
if C[0][0] - C[0][1] != C[1][0] - C[1][1] or C[1][0] - C[1][1] != C[2][0] - C[2][1]:
    result = False
# Cの1列目と2列目の差を調べ、全て同じか確認
if C[0][1] - C[0][2] != C[1][1] - C[1][2] or C[1][1] - C[1][2] != C[2][1] - C[2][2]:
    result = False
# Cの0行目と1行目の差を調べ、全て同じか確認
if C[0][0] - C[1][0] != C[0][1] - C[1][1] or C[0][1] - C[1][1] != C[0][2] - C[1][2]:
    result = False
# Cの1行目と2行目の差を調べ、全て同じか確認
if C[1][0] - C[2][0] != C[1][1] - C[2][1] or C[1][1] - C[2][1] != C[1][2] - C[2][2]:
    result = False

if result:
    print('Yes')
else:
    print('No')
