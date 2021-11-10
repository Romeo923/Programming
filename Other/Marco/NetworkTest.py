from NN import *

identity = lambda x: x
sigmoid = lambda x: 1/(1+np.exp(x))

layer1 = Layer(1,identity,4)

print(layer1.activate([2,3,4,5]))

