# E - Sprinkler
# https://atcoder.jp/contests/past202005-open/tasks/past202005_e

########################################
# 隣接行列
########################################
N, M, Q = map(int, input().split())
# False N x N の2次元配列
graph = []
for i in range(0, N):
    # 長さ N の False の1次元配列を作る
    row = []
    for j in range(0, N):
        row.append(False)
    # 長さ N の False の1次元配列を graph に追加する
    graph.append(row)

# M 本の辺を受け取る
for i in range(0, M):
    u, v = map(int, input().split())
    # 頂点番号は全て -1
    u -= 1
    v -= 1
    # u と v の間には辺があるため True にする
    graph[u][v] = True
    graph[v][u] = True

# 頂点の色のリスト
C = list(map(int, input().split()))

# Q 個のクエリを受取る
for i in range(0, Q):
    query = list(map(int, input().split()))
    
    # スプリンクラーを起動するクエリの場合
    if query[0] == 1:
        x = query[1]

        # 頂点番号は全て-1
        x -= 1

        # 頂点 x の色を出力
        print(C[x])

        # 全ての頂点を順番に見る
        for i in range(0, N):

            # 頂点i が頂点 x に隣接している場合、
            # すなわは頂点 x と頂点 i の間に辺がある場合
            if graph[x][i]:

                # 頂点 i の色を C[x] に書き換える
                C[i] = C[x]
    
    # スプリンクラーを起動しないクエリ
    if query[0] == 2:
        x = query[1]
        y = query[2]

        # 頂点番号は全て -1
        x -= 1

        # 頂点 x の色を出力する
        print(C[x])

        # 頂点 x の色を y に書き換える
        C[x] = y
