import numpy as np
import cv2
import glob
import re
import pandas as pd

#train = []
train = []
for i in range(40):
    train.append([])
#train_labels = []
files = glob.glob('/Users/hannesnilsson/Desktop/Computer Vision/ATTFaceDataSet/Training/*.jpg')
for myFile in files:
    image = cv2.imread(myFile, 0) #reading in grayscale
#    train.append(image)
    person = re.split('[S _]', str(myFile))[3] #extract person number found in file name
 #   train_labels.append(person)
    train[int(person)-1].append(image)
train = np.array(train, dtype = 'float32')
#train_labels = np.array(train_labels)
print(train.shape)

train = np.reshape(train, [train.shape[0], train.shape[1], train.shape[2]*train.shape[3]])
print(train.shape)

#calculate the in-class means
muPerClass = []
for clss in train:
    mu = clss[0]
    for i in range(1,len(clss)):
        mu = np.add(mu, clss[i])
    mu /= len(clss)
    muPerClass.append(mu)
muPerClass = np.array(muPerClass, dtype = 'float32')
print(muPerClass.shape)

dfEigenVals = pd.read_csv('eigenvalues.csv', header=None)
dfEigenVects = pd.read_csv('eigenvectors.csv', header=None)

eigenVal = dfEigenVals.to_numpy()
eigenVect = dfEigenVects.to_numpy()

eigenVal = np.complex_(eigenVal)
eigenVect = np.complex_(eigenVect)

eigenVal = np.real(eigenVal)
eigenVect = np.real(eigenVect)

print('EigenVect shape: ', eigenVect.shape)
print('muPerClass shape: ', muPerClass.shape)

muProjections = np.matmul(muPerClass, eigenVect)
print('muProjections shape: ', muProjections.shape)

test = []
for i in range(40):
    test.append([])
files = glob.glob('/Users/hannesnilsson/Desktop/Computer Vision/ATTFaceDataSet/Testing/*.jpg')
for myFile in files:
    image = cv2.imread(myFile, 0) #reading in grayscale
    person = re.split('[S _]', str(myFile))[3] #extract person number found in file name
    test[int(person)-1].append(image)
test = np.array(test, dtype = 'float32')
print(test.shape)

test = np.reshape(test, [test.shape[0], test.shape[1], test.shape[2]*test.shape[3]])
print(test.shape)

projectionsTest = []
for clss in test:
    projections = np.matmul(clss, eigenVect)
    projectionsTest.append(projections)

projectionsTest = np.array(projectionsTest, dtype = 'float32')
print('projectionsTest shape: ', projectionsTest.shape)

#array for class and error in classification for each image
classError = np.zeros([projectionsTest.shape[0], projectionsTest.shape[1], 2])
print(classError.shape)
classCorr = 0 #correct classifications
classIncorr = 0 #incorrect classifications
for i in range(projectionsTest.shape[0]):
    euclidean = 0
    for j in range(projectionsTest.shape[1]):
        for k in range(muProjections.shape[0]):
            euclidean = np.subtract(projectionsTest[i,j], muProjections[k])
            err = np.sum(np.abs(euclidean))
            if (classError[i,j,1] == 0 or err < classError[i,j,1]):
                classError[i,j,1] = err  #update error value
                classError[i,j,0] = k    #update classification
        if (classError[i,j,0]==i):
            classCorr += 1
        else:
            classIncorr += 1

print(projectionsTest.shape)
print(classCorr, classIncorr)
print(classError[3,3])
print(classError)
