# https://atcoder.jp/contests/abc157/tasks/abc157_b

#Bingoの配列を取得
bingo = [list(map(int, input().split())), list(map(int, input().split())), list(map(int, input().split()))]
# 入力する個数
n = int(input())
# 任意の数字を入力
x = list()
while n > 0:
    x.append(int(input()))
    n -= 1

# Bingoの配列と入力値を比較
result = [[False, False, False], [False, False, False], [False, False, False]]
for i in range(3):
    for j in range(3):
        for a in x:
            if a == bingo[i][j]:
                result[i][j] = True

# Bingo判定
msg = ''
if (result[0][0] and result[0][1] and result[0][2]):    # 1行目
    msg = 'Yes'
if (result[1][0] and result[1][1] and result[1][2]):    # 2行目
    msg = 'Yes'
elif (result[2][0] and result[2][1] and result[2][2]):  # 3行目
    msg = 'Yes'
elif (result[0][0] and result[1][0] and result[2][0]):  # 1列目
    msg = 'Yes'
elif (result[0][1] and result[1][1] and result[2][1]):  # 2列目
    msg = 'Yes'
elif (result[0][2] and result[1][2] and result[2][2]):  # 3列目
    msg = 'Yes'
elif (result[0][0] and result[1][1] and result[2][2]):  # \
    msg = 'Yes'
elif (result[0][2] and result[1][1] and result[2][0]):  # /
    msg = 'Yes'
else:
    msg = 'No'

# 結果を表示
print(msg)

'''
a = [list(map(int, input().split())) for _ in range(3)]
for i in range(int(input())):
    b = int(input())
    for j in range(3):
        for k in range(3):
            if a[j][k] == b:
                a[j][k] = 0
ans = "No"
for i in range(3):
    if a[i][0] == a[i][1] == a[i][2] == 0:
        ans = "Yes"
    if a[0][i] == a[1][i] == a[2][i] == 0:
        ans = "Yes"
    if a[0][0] == a[1][1] == a[2][2] == 0:
        ans = "Yes"
    if a[2][0] == a[1][1] == a[0][2] == 0:
        ans = "Yes"

print(ans)
'''