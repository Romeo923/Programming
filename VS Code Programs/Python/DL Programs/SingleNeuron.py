import math
from NN import *

sigmoid = lambda x: 1/(1 + math.exp(-x))
bypass = lambda x: x

training = [[1, 2.2, 0], [1, 2.4, 1], [2, 2.5, 0], [2, 2.7, 1]]
testing = [[1.5, 2.4], [1.5, 2.5], [2.5, 2.7], [2.5, 2.8]]
expectedTestOutputs = [0, 1, 0, 1]

decisionBoundary = lambda x: 0.3*x + 2
learningRate = 0.01

n = Neuron(sigmoid, 2)
n.train(training, learningRate, 10000)

print(f'\nTrained Weights: {n.weights}\nTrained Bias: {n.b}\n')

for i in range(len(testing)):
    test = testing[i]
    out = n.activate(test)
    print(f'Inputs: {test}')
    print(f'Output: {out}')
    print(f'Expected Output: {expectedTestOutputs[i]}')
    print(f'Error: {expectedTestOutputs[i] - out}\n')
