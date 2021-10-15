# take 3 images with 1000 pixels
# randomly assaign pixels between images
# ensure each image has 1/3 of the pixels of each image
# do svd then look at eigen values

import numpy as np
from matplotlib import pyplot as plt
from PIL import Image
import random

path = "../Test Images/ATTFaceDataSet/Testing/"  # path where images are stored
newPath = "../Test Images/"  # path where images are saved

# list of all images
#Image.open( imagePath )

images = [
    Image.open(path + "S1_8.jpg"),
    Image.open(path + "S2_10.jpg"),
    Image.open(path + "S3_9.jpg"),
    #    Image.open(path + "S4_7.jpg"),
    #    Image.open(path + "S5_10.jpg"),
    #    Image.open(path + "S6_6.jpg"),
    #    Image.open(path + "S7_8.jpg"),
    #    Image.open(path + "S8_6.jpg"),
    #    Image.open(path + "S9_8.jpg"),
    #    Image.open(path + "S10_8.jpg"),
    #    Image.open(path + "S11_6.jpg"),
    #    Image.open(path + "S12_6.jpg"),
    #    Image.open(path + "S13_10.jpg"),
    #    Image.open(path + "S14_10.jpg"),
    #    Image.open(path + "S15_10.jpg")
]

imageCombo = [np.vstack(images)]  # combines original image arrays vertically

svd = []
for img in images:
    # Computes svd
    U, S, VT = np.linalg.svd(img)
    svd.append([np.around(U[:30], 1), np.around(
        S[:30], 1), np.around(VT[:30], 1)])


def randomizeImages(imageList):

    w, h = imageList[0].size

    for i in range(w):
        for j in range(h):
            position = (i, j)
            Ilist = [(imageList[x], x) for x in range(len(imageList))]
            pixels = [(imageList[x].getpixel(position), x)
                      for x in range(len(imageList))]

            for k in range(len(imageList)):
                p = random.choice(pixels)
                img = random.choice(Ilist)
                pixels.remove(p)
                Ilist.remove(img)
                img[0].putpixel(position, p[0])


randomizeImages(images)

# for i in range(len(images)):
#     images[i].save(newPath + f"RandomizedImage{i}.jpg")

# combines  randomized image arrays vertically
imageCombo.append(np.vstack(images))
# combines original and randomized image arrays horrizontally
allImages = np.hstack(imageCombo)
img = Image.fromarray(allImages)
img.show()
