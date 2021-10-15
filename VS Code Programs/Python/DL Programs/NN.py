from typing import List
import random

class Neuron:

    def __init__(self, activationFunction: callable, numInputs: int, numNeurons: int = 1):
        self.aFunction = activationFunction
        #self.weights = [random.normalvariate(0,1/numNeurons) for i in range(numInputs)]
        #self.b = random.normalvariate(0,1/numNeurons)
        self.weights = [random.random() for i in range(numInputs)]
        self.b = random.random()

    def activate(self, inputs: List[float]) -> float:
        sum = self.b
        for i in range(len(inputs)):
            sum += inputs[i] * self.weights[i]
        return self.aFunction(sum)

    def train(self, trainingData: List[List[float]], lr: float, epochs: int):
        
        for i in range(epochs):
            for data in trainingData:
                inputs = data[:-1]
                expectedOutput = data[-1] 

                out = self.activate(inputs)
                e = (expectedOutput - out)
                grad = e*(out**2)
                grad *= (1/out - 1)
                self.b -= lr*grad
                for i in range(len(self.weights)):
                    grad = inputs[i]*e
                    grad *= out**2
                    grad *= (1/out - 1)
                    self.weights[i] -= lr*grad

    
class Layer:

    def __init__(self, numNeurons: int, activationFunction: callable, numInputs: int):
        self.neurons = [Neuron(activationFunction, numInputs, numNeurons) for i in range(numNeurons)]

    def activate(self, inputs: List[float]) -> List[float]:
        return [self.neurons[i].activate(inputs) for i in range(len(self.neurons))]

    def train(self, trainingData: List[List[float]], lr: float, epochs: int):
        
        for i in range(epochs):

            for data in trainingData:

                inputs = data[:-1]
                expectedOutput = data[-1] 
                out = self.activate(inputs)
                e = [expectedOutput - output for output in out]

                for neuron in self.neurons:
                    # adjust weights and bias for each neuron in layer
                    pass

class NeuralNetwork:

    def __init__(self, activationFunction: callable, numInputs:int, layerInfo: List[int]):
        self.layers = []
        n = numInputs
        for i in range(len(layerInfo)):
            self.layers.append(Layer(layerInfo[i],activationFunction,n))
            n = layerInfo[i]
    
    def activate(self, inputs: List[float]) -> List[float]:
        tempIn = inputs
        for layer in self.layers:
            tempIn = layer.activate(tempIn)
        return tempIn

    def train(self, trainingData: List[List[float]], lr: float, epochs: int):
        pass



# Single Neuron, 2 inputs, Sigmoid
#
# E = (1/2)(y-a)^2
# E = (1/2)(y - f(w1x1 + w2x2 + b))^2
# E = (1/2)(y - 1/(1 + e^-(w1x1 + w2x2 + b)))^2
#
# dE/dw1 -> -x1(y - 1/(1 + e^-(w1x1 + w2x2 + b)))
#        -> x1(y - a)(1 + e^-(w1x1 + w2x2 + b))^(-2)
#
# dE/dw2 -> -x2(y - 1/(1 + e^-(w1x1 + w2x2 + b)))
#        -> x2(y - a)(1 + e^-(w1x1 + w2x2 + b))^(-2)
#
# dE/db -> -(y - 1/(1 + e^-(w1x1 + w2x2 + b)))
#       -> (y - a)(1 + e^-(w1x1 + w2x2 + b))^(-2)
#
# Single Neuron, n inputs
#
# E = (y-a)^2
# E = (y - (w1x1 + w2x2 + w3x3 + ... + wnxn + b))^2
#
