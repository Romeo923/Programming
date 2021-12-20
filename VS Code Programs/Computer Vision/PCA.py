import numpy as np
from matplotlib import pyplot as plt
import cv2

def to1DMatrix(matrix):
    return np.array([[x] for row in matrix for x in row],dtype='int32')

def to2DMatrix(matrix,width,height):
    matrix = matrix.T
    image = np.array(matrix).reshape((height,width))

    return image

def train():
    path = 'Test Images\ATTFaceDataSet\Training'
    
    image_width = 92
    image_height = 112
    image_size = image_width * image_height
    
    number_of_classes = 2
    images_per_class = 1
    number_of_images = number_of_classes*images_per_class

    num_eigen_values = 30

    mean_face = np.zeros((image_size,1),dtype='int32')

    I = []
    for i in range(number_of_classes):
        for j in range(images_per_class):
            img = cv2.imread(f'{path}\S{i+1}_{j+1}.jpg',0)
            img = to1DMatrix(img)     
            mean_face += img
            I.append(img)

    mean_face //= (number_of_classes*images_per_class)

    for image in I:
        image -= mean_face

    I = np.array(I,dtype='int32')[:,:,0]
    I = I.T


    cov = I.dot(I.T) if number_of_images > image_size else I.T.dot(I)

    evalues, eigen_vectors = np.linalg.eigh(cov)

    eigen_vectors = np.array(eigen_vectors[:num_eigen_values])
    eigen_vectors = eigen_vectors.T

    eigen_face = I.dot(eigen_vectors)

    return np.array([np.array(image.dot(eigen_face)) for image in I.T],dtype='int32'), eigen_face

def error(matrix, Ix):
    s = matrix - Ix
    return np.sum([x**2 for x in s])

def find(matrix,Ix):
    match, e = 999, 9999999999999999999999
    for i in range(len(matrix)):
        tempError = error(matrix,Ix[i])
        (match, e) = (i, tempError) if tempError < e else (match, e)
    return match
    
def main():
    Ix, eface = train()

    image_width = 92
    image_height = 112
    number_of_classes = 2
    images_per_class = 1
    
    # path = input('Enter Image Path: ')
    path = 'Test Images\ATTFaceDataSet\Testing\S2_8.jpg'
    img = cv2.imread(path,0)
    img = to1DMatrix(img)
    print(img.shape)
    vals = img.T.dot(eface)
    print(vals.shape)
    face = find(vals,Ix)
    print(face)
    imgclass = face//images_per_class + 1
    imgNum = face%images_per_class + 1
    im = np.array(cv2.imread(f'Test Images\ATTFaceDataSet\Training\S{imgclass}_{imgNum}.jpg',0),dtype='int32')
    print(f'Class: {imgclass}\nImage: {imgNum}')
    plt.imshow(im)
    plt.show()

if __name__ == '__main__':
    main()