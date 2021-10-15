# read images
# convert images to 10,000 x 1
# shift everything by the mean
# calculate covariance matrix
# compute eigen values/vectors/face

import numpy as np
import cv2

trainingPath = "../Test Images/ATTFaceDataSet/Training/"
testingPath = "../Test Images/ATTFaceDataSet/Testing/"
imageMatrix


def loadTrainingImages():
    imgResize = []
    for i in range(1, 2):
        for j in range(1, 2):
            img = cv2.imread(trainingPath + f'S{i}_{j}.jpg')
            for row in img:
                for pixel in row:
                    imgResize.append(pixel[0])
            imageMatrix = np.asarray_chkfinite(imgResize)


def adjustImages(images, mean):
    for i in images:
        i -= mean


def covariance(A):
    t = np.transpose(A)
    return np.matmul(t, A)


def computeEigenVectors(A):
    eval, ev = np.linalg.eig(A)
    return ev[:30]


def computeEigenFace():
    pass


loadTrainingImages()
