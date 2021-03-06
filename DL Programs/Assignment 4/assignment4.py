import os
import sys
import cv2
import numpy as np
from sklearn.utils import shuffle

train = np.empty((1000,28,28),dtype='float64')
trainY = np.zeros((1000,10,1))
test = np.empty((10000,28,28),dtype='float64')
testY = np.zeros((10000,10,1))
# Load in the images
i = 0
for filename in os.listdir('D:/Data/Training1000/'):
    y = int(filename[0])
    trainY[i,y] = 1.0
    train[i] = cv2.imread('D:/Data/Training1000/{0}'.format(filename),0)/255.0 # for color, use 1
    i = i + 1

i = 0 # read test data
for filename in os.listdir('D:/Data/Test10000'):
    y = int(filename[0])
    testY[i,y] = 1.0
    test[i] = cv2.imread('D:/Data/Test10000/{0}'.format(filename),0)/255.0
    i = i + 1

trainX = train.reshape(train.shape[0],train.shape[1]*train.shape[2],1)
testX = test.reshape(test.shape[0],test.shape[1]*test.shape[2],1)

numNeuronsLayer1 = 100
numNeuronsLayer2 = 10
numEpochs = 100
#---------------------NN------------------------
w1 = np.random.uniform(low=-0.1,high=0.1,size=(numNeuronsLayer1,784))
b1 = np.random.uniform(low=-1,high=1,size=(numNeuronsLayer1,1))
w2 = np.random.uniform(low=-0.1,high=0.1,size=(numNeuronsLayer2,numNeuronsLayer1))
b2 = np.random.uniform(low=-0.1,high=0.1,size=(numNeuronsLayer2,1))    

learningRate = 0.1
for n in range(0,numEpochs):
    loss = 0
    trainX,trainY = shuffle(trainX, trainY) # shuffle data for stochastic behavior
    for i in range(trainX.shape[0]):
        # do forward pass
        # your equations for the forward pass

        # do backprop and compute the gradients * also works instead
        # np.multiply
        loss += (0.5 * ((a2-trainY[i])*(a2-trainY[i]))).sum()
        # loss += (0.5 * np.multiply((a2-trainY[i]),(a2-trainY[i]))).sum()

        # your equations for computing the deltas and the gradients

        # adjust the weights
        w2 = w2 - learningRate * gradw2
        b2 = b2 - learningRate * gradb2
        w1 = w1 - learningRate * gradw1
        b1 = b1 - learningRate * gradb1


    print("epoch = " + str(n) + " loss = " + (str(loss)))

print("done training , starting testing..")

accuracyCount = 0
for i in range(testY.shape[0]):
    # do forward pass
    s1 = np.dot(w1,testX[i]) + b1
    a1 = 1/(1+np.exp(-1*s1)) # np.exp operates on the array
    s2 = np.dot(w2,a1) + b2
    a2 = 1/(1+np.exp(-1*s2))
    # determine index of maximum output value
    a2index = a2.argmax(axis = 0)
    if (testY[i,a2index] == 1):
        accuracyCount = accuracyCount + 1
        print("Accuracy count = " + str(accuracyCount/10000.0))
