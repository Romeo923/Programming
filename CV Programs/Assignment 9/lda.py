import numpy as np
from PIL import Image

# path where images are stored
trainingPath = "Test Images/ATTFaceDataSet/Training/"
testingPath = "Test Images/ATTFaceDataSet/Testing/"

image_width = 92
image_height = 112
number_of_classes = 5
images_per_class = 2
num_eig_vectors = number_of_classes - 1

size = image_height * image_width
number_of_images = number_of_classes * images_per_class

def getImage(image_class, index) -> np.ndarray:
    image = Image.open(f'{trainingPath}S{image_class}_{index}.jpg')
    image = np.asarray(image,dtype="int32")
    output = np.array([image[row,col,0] for row in range(image_height) for col in range(image_width)])
    return output.transpose()

def getClassImages(image_class) -> list:
    return [getImage(image_class=image_class,index=i+1) for i in range(images_per_class)]

def getClassMean(image_class) -> np.ndarray:
    images = getClassImages(image_class=image_class+1)
    mean = np.zeros((size,1))
    for image in images:
        mean = mean + image
    return mean/images_per_class

def getGlobalMean() -> np.ndarray:
    mean = np.zeros((size,1))

    for c in range(number_of_classes):
        images = getClassImages(image_class=c+1)
        for image in images:
            mean = mean + image

    return mean/number_of_images

def generateSw() -> np.ndarray:
    print("Generating Sw...")
    Sw = np.zeros((size,size))

    for c in range(number_of_classes):
        images = getClassImages(c+1)
        mean = getClassMean(c+1)
        Si = np.zeros((size,size))
        for image in images:
            img = image - mean
            Si = Si + (img.dot(img.transpose()))
        print(f"Calculated Si for class {c+1}")
        Sw = Sw + Si
    print("Sw complete")
    return Sw

def generateSb() -> np.ndarray:
    print("Generating Sb...")
    Sb = np.zeros((size,size))
    global_mean = getGlobalMean()
    class_means = [getClassMean(c+1) for c in range(number_of_classes)]
    for i, mean in enumerate(class_means):
        diff = mean - global_mean
        Si = diff.dot(diff.transpose())
        Si = Si * images_per_class
        Sb = Sb + Si
        print(f"Calculated diff mean for class {i+1}")
    return Sb

def learn():
    Sw = generateSw()
    Sb = generateSb()
    Swi = np.linalg.inv(Sw)
    J = Swi.dot(Sb)

    _, eig_vectors = np.linalg.eigh(J)

    print(eig_vectors)

learn()