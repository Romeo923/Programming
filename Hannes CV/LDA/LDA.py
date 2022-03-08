import numpy as np
import cv2
import glob
import re
import pandas as pd
from scipy.linalg import eig, sqrtm

def main():

    #train = []
    train = []
    for i in range(40):
        train.append([])
        #train_labels = []
    files = glob.glob('Z:\Computer Vision\LDA\ATTFaceDataSet/Training/*.jpg')
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

    muOverall = np.zeros((muPerClass.shape[1]))
    for mu in muPerClass:
        muOverall = np.add(muOverall, mu)
        muOverall /= muPerClass.shape[0]

    #calculate within-class scatter matrix
    Sw = np.zeros((train.shape[2],))
    for i in range(len(train)):
        clss = np.subtract(train[i], muPerClass[i])
        Si = np.cov(clss, rowvar = False)
        Sw = np.add(Sw, Si)
    print('Sw:', Sw.shape, 'Symmetric?:', check_symmetric(Sw))

    #calculate between-class scatter matrix
    Sb = np.zeros((muOverall.shape[0],))
    print(Sb.shape)
    for clss in muPerClass:
        clss = np.subtract(clss, muOverall).reshape(clss.shape[0], 1)
        Si = 5*np.dot(clss, clss.T)  #5 pictures per person
        Sb = np.add(Sb, Si)
    print('Sb:', Sb.shape, 'Symmetric?:', check_symmetric(Sb))


    #invSw = inv(Sw)
    #print('invSw:', 'Symmetric?:', check_symmetric(invSw))

    '''
    invSwSb = np.dot(np.linalg.inv(Sw), Sb)
    print('invSwSb:', 'Symmetric?:', check_symmetric(invSwSb))
    #eigVal, eigVect = np.linalg.eig(invSwSb)
    '''

    '''
    sqSb = sqrtm(Sb)
    sqSbinvSwsqSb = np.matmul(sqSb, invSw)
    sqSbinvSwsqSb =	np.matmul(sqSbinvSwsqSb, sqSb)
    invsqSb = np.linalg.inv(sqSb)

    print('sqSb:', sqSb[0:3,0:3])
    print('sqSbinvSwsqSb:', sqSbinvSwsqSb[0:3,0:3])
    
    eigVal, eigVectV = np.linalg.eig(sqSbinvSwsqSb)
    '''


    
    '''
    eigVal = np.zeros(train.shape[2])
    eigVal[33] = 3
    eigVal[56] = 45
    eigVal[584] = 2
    eigVectV = np.zeros((train.shape[2],train.shape[2]))
    eigVectV[0,56] = 7
    eigVectV[1,33] = 5
    eigVectV[0,584] = 3
    '''

    eigVal, eigVect = eig(Sb, Sw)
    
    idx = eigVal.argsort()
    print(idx)
    idx = idx[::-1][:train.shape[0]-1]
    print(idx)

    eigVal = eigVal[idx]
    eigVect = eigVect[:,idx]
    print(eigVal)
    print(eigVect.shape)
    

    '''
    eigVect = []
    for i in range(eigVectV.shape[1]):
    #    print(eigVectV[:,i].shape)
        eigVect.append(np.matmul(invsqSb, eigVectV[:,i]))
    eigVect = np.array(eigVect)
    '''

    '''
    eigVal,eigVect = eigh(invSwSb,eigvals=((10304-40),(10304-1)))
    print(eigVal)
    '''

    '''
    with open('eigenvalues.txt', 'w') as f:
        for line in eigVal:
            np.savetxt(f, line)

    with open('eigenvectors.txt', 'w') as f:
        for line in eigVect:
            np.savetxt(f, line)
    '''


    np.savetxt('eigenvalues2.csv', eigVal, delimiter=',')
    np.savetxt('eigenvectors2.csv', eigVect, delimiter=',')

    df1 = pd.read_csv('eigenvalues2.csv', header=None)
    print(df1)
    df2 = pd.read_csv('eigenvectors2.csv', header=None)


def check_symmetric(a, rtol=1e-05, atol=1e-08):
    return np.allclose(a, a.T, rtol=rtol, atol=atol)

if __name__ == '__main__':
    main()
