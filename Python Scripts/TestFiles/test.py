import numpy as np


v1 = [[1],[2]]
v2 = [[2,3]]
v3 = [2,3]


array1 = np.array(v1)
array2 = np.array(v2)
# array3 = np.array(v3)
# np.reshape(v3,(1,2))

print(f'\nArray 1: Size {np.shape(array1)}\n\n{array1}')
print(f'\nArray 2: Size {np.shape(array2)}\n\n{array2}')
# print(f'\nArray 3: Size {np.shape(array3)}\n\n{array3}')
print(f'\nDot Product: Size {np.shape(array1.dot(array2))}\n\n{array1.dot(array2)}')
# print(f'\nDot Product: Size {np.shape(array1.dot(array3))}\n\n{array1.dot(array3)}')