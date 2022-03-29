# E - SNS Log
# https://atcoder.jp/contests/past201912-open/tasks/past201912_e
N, Q = map(int, input().split())

# N 人のそれぞれがフォローしている配列
P = []

for i in range(0, N):
    row = []
    P.append(row)

for i in range(0, Q):
    log = list(map(int, input().split()))
    
    # 以降で -1 しているのは配列で考えるため
    if log[0] == 1:
        a = log[1] - 1
        b = log[2] - 1
        P[a].append(b)
    elif log[0] == 2:
        a = log[1] - 1
        # 追加用の配列
        row = []
        for i in range(0, N):
            followers = P[i]
            for j in followers:
                if j == a:
                    row.append(i)
        for i in row:
            P[a].append(i)
    elif log[0] == 3:
        a = log[1] - 1
        # ユーザーaがフォローしている各ユーザーx
        x = P[a]
        # 追加用の配列
        row = []
        # i はユーザーx がフォローしているユーザー
        for i in x:
            y = P[i]
            # j は ユーザーyがフォローしていユーザー
            for j in y:
                # j は a ではない且つユーザーaが既に i を持っていない
                if j != a and j != i:
                    row.append(j)
        for i in row:
            P[a].append(i)
# 出力用変数
result = []
for i in range(0, N):
    row = []
    for j in range(0, N):
        row.append(False)
    result.append(row)

for i in range(0, N):
    row = P[i]
    for j in row:
        result[i][j] = True

msg = ''
for i in range(0, N):
    for j in range(0, N):
        if result[i][j]:
            msg += 'Y'
        else:
            msg += 'N'
    print(msg)
    msg = ''
