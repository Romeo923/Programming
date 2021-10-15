import numpy as np
from matplotlib import pyplot as plt

la = np.linalg

# given data
Xpoints = [1, 2, 3, 4, 5, 6]
Ypoints = [-0.6, 8.3, 26, 57, 108, 173]
order = 3

M = np.arange(0.0, 16.0).reshape(4, 4)  # 4x4 Matrix
A = np.arange(0.0, 4.0).reshape(4, 1)  # 4x1 Matrix

# preforms the given function on each elements in a given data set
# then returns the sum of the results


def f(data1, function, data2=[1, 1, 1, 1, 1, 1]):
    sum = 0
    for i in range(0, len(data1)):
        val = function(data1[i])
        val *= data2[i]
        sum += val
    return sum


def fx(x, coefs, order):
    o = order
    y = 0
    for c in coefs:
        c0 = c[0]
        y += c0*(x**o)
        o -= 1
    return y


# fills matrices M and A with values based off equations below
for i in range(0, 4):
    A[i][0] = f(Xpoints, lambda x: 2*x**(order-i), Ypoints)

    for j in range(0, 4):
        M[i][j] = f(Xpoints, lambda x: 2*x**(6-j-i))

M = np.around(M, 1)  # rounds each element in matrix to 1 decimal point
A = np.around(A, 1)  # rounds each element in matrix to 1 decimal point

inverse = la.inv(M)  # inverse of matrix M
# preforms matrix multiplication M^(-1) * A, resulting matrics contains values for a, b, c, and d
abcd = inverse.dot(A)

# rounds each element in matrix to 1 decimal point
inverse = np.around(inverse, 1)
abcd = np.around(abcd, 1)  # rounds each element in matrix to 1 decimal point

print('''\n
| a |     | 2x^6  2x^5  2x^4  2x^3  |^(-1)  | 2yix^3 |
| b |  =  | 2x^5  2x^4  2x^3  2x^2  |       | 2yix^2 |
| c |  =  | 2x^4  2x^3  2x^2   2x   |       |  2yix  |
| d |     | 2x^3  2x^2   2x    2    |       |   2yi  |
''')

print(f'''
| a |     {abcd[0]}      {inverse[0]} {A[0]}
| b |  =  {abcd[1]}   =  {inverse[1]} {A[1]}
| c |  =  {abcd[2]}  =  {inverse[2]} {A[2]}
| d |     {abcd[3]}      {inverse[3]} {A[3]}
''')

print(
    f'\ny = {abcd[0][0]}x^3 + {abcd[1][0]}x^2 + {abcd[2][0]}x + {abcd[3][0]}\n')

max = Xpoints[-1]
xlist = np.linspace(0, max+1)
ylist = fx(xlist, abcd, order)
plt.plot(xlist, ylist, 'r')
plt.scatter(Xpoints, Ypoints)
plt.show()


# L = (ax^3 + bx^2 + cx + d - yi)^2
# dL/da = 0, dL/db = 0, dL/dc = 0, dL/dd = 0
#
# dL/da -> 2x^3(ax^3 + bx^2 + cx + d - yi) = 0
#       -> 2ax^6 + 2bx^5 + 2cx^4 + 2dx^3 - 2yix^3 = 0
#       -> 2ax^6 + 2bx^5 + 2cx^4 + 2dx^3 = 2yix^3
#
# dL/db -> 2x^2(ax^3 + bx^2 + cx + d - yi) = 0
#       -> 2ax^5 + 2bx^4 + 2cx^3 + 2dx^2 - 2yix^2 = 0
#       -> 2ax^5 + 2bx^4 + 2cx^3 + 2dx^2 = 2yix^2
#
# dL/dc -> 2x(ax^3 + bx^2 + cx + d - yi) = 0
#       -> 2ax^4 + 2bx^3 + 2cx^2 + 2dx - 2yix = 0
#       -> 2ax^4 + 2bx^3 + 2cx^2 + 2dx = 2yix
#
# dL/dd -> 2(ax^3 + bx^2 + cx + d - yi) = 0
#       -> 2ax^3 + 2bx^2 + 2cx + 2d - 2yi = 0
#       -> 2ax^3 + 2bx^2 + 2cx + 2d = 2yi
#
# | 2x^6  2x^5  2x^4  2x^3  | | a |     | 2yix^3 |
# | 2x^5  2x^4  2x^3  2x^2  | | b |  =  | 2yix^2 |
# | 2x^4  2x^3  2x^2   2x   | | c |  =  |  2yix  |
# | 2x^3  2x^2   2x    2    | | d |     |   2yi  |
#              M              abcd           A
#
# | a |     | 2x^6  2x^5  2x^4  2x^3  |^(-1)  | 2yix^3 |
# | b |  =  | 2x^5  2x^4  2x^3  2x^2  |       | 2yix^2 |
# | c |  =  | 2x^4  2x^3  2x^2   2x   |       |  2yix  |
# | d |     | 2x^3  2x^2   2x    2    |       |   2yi  |
# abcd                 M^(-1)                      A
