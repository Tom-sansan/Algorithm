# 10進数を2進数に変換するプログラム

N = int(input())
answer = ""

while N >= 1:
    if N % 2 == 0:
        answer = "0" + answer
    if N % 2 == 1:
        answer = "1" + answer
    N = N // 2

print(answer)