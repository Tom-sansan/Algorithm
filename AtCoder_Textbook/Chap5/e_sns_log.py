# E - SNS Log
# https://atcoder.jp/contests/past201912-open/tasks/past201912_e
#################################
# Anser 1
#################################
'''
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
'''
#################################
# Anser 2
#################################
N, Q = map(int, input().split())

# False の N x N の 2次元配列を作る
graph = []
for i in range(0, N):
    # 長さ N の False の1次元配列を作る
    row = []
    for j in range(0, N):
        row.append(False)
    # 長さ N の False の1次元配列を graph に追加する
    graph.append(row)

# Q個の操作を受取る
for i in range(0, Q):
    query = list(map(int, input().split()))
    # 配列で考えるため頂点番号は-1
    a = query[1] - 1
    
    # [フォロー] の操作の場合
    if query[0] == 1:
        # 頂点番号は-1
        b = query[2] - 1
        # a から b へ辺を張る
        graph[a][b] = True
    
    # [フォロー全返し] の操作の場合
    if query[0] == 2:
        # 全ての頂点を順番に見る。見ている頂点を v とする
        for v in range(0, N):
            # 頂点 v から頂点 a へと辺があるとき
            if graph[v][a]:
                # 頂点 a から v へと辺を張る
                graph[a][v] = True

    # [フォローフォロー] の操作の場合
    if query[0] == 3:
        # 頂点 a から辺を張る予定の頂点リスト
        to_follow = []
        # 全ての頂点を順番に見る。見ている頂点を v とする
        for v in range(0, N):
            # 頂点 a から頂点 v へと辺があるとき
            if graph[a][v]:
                # 更に全ての頂点を順番に見る。見ている頂点を w とする
                for w in range(0, N):
                    # 頂点 v から頂点 w へと辺があり、かつ w が a でないとき
                    if graph[v][w] and w != a:
                        # あとで頂点 a から辺を張るために記録しておく
                        to_follow.append(w)
        # 頂点 a から辺を張る
        for w in to_follow:
            graph[a][w] = True

# 隣接行列を全て出力
for i in range(0, N):
    for j in range(0, N):
        # i から j へと辺がある場合は Y 、辺がない場合は N を出力。改行はなし。
        if graph[i][j]:
            print('Y', end = '')
        else:
            print('N', end = '')
    # N 文字出力するごとに改行
    print()
