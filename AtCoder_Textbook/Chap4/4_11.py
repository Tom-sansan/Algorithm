S = input()
if not (1 <= len(S) <= 1000):
    print('Please enter the number less than 1001')
else:
    countA = S.count('a')
    countB = S.count('b')
    countC = S.count('c')

    if countA > countB and countA > countC:
        print('a')
    elif countB > countC:
        print('b')
    else:
        print('c')

