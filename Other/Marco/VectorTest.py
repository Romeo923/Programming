from Vector import *

v1 = Vector(3,4)
v2 = Vector(3,-1)
vAdd = v1 + v2
vMul = v1 * v2
v1Scalar = 4 * v1

print(v1, f'magnitude: {v1.magnitude}')
print(v2, f'magnitude: {v2.magnitude}')
print(f'+ : {v1} + {v2} = {vAdd}')
print(f'* : {v1} · {v2} = {vMul}')
print(f'* : 4 * {v1} = {v1Scalar}')

