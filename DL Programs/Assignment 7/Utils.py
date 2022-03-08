import torch
import torchvision
import torchvision.transforms as transforms
import numpy as np
import matplotlib.pyplot as plt

#fix certificate verify error
import ssl
ssl._create_default_https_context = ssl._create_unverified_context

def prepare_data(path_data, batch_size):
    cifar_transform = transforms.Compose([
    transforms.ToTensor(), 
    transforms.Normalize((0.5,0.5,0.5), (0.5,0.5,0.5))
    ]) # rescales image to from -1 to 1
    trainds = torchvision.datasets.CIFAR10(root=path_data, transform=cifar_transform, train=True, download=True)
    testds = torchvision.datasets.CIFAR10(root=path_data, train=False, transform=cifar_transform, download=True)

    trainloader = torch.utils.data.DataLoader(trainds, batch_size=batch_size,shuffle=True, num_workers=0)
    testloader = torch.utils.data.DataLoader(trainds, batch_size=batch_size, shuffle=False, num_workers=0)
    return trainds, trainloader, testds, testloader

def plot_images(images, labels):
    # normalise=True below shifts [-1,1] to [0,1]
    img_grid = torchvision.utils.make_grid(images, nrow=4, normalize=True)
    np_img = img_grid.numpy().transpose(1,2,0) # pytorch has the order, c,w,h
    # to be able to view an image, we need to change the order and
    # put it in width, height, color order
    plt.imshow(np_img)

def get_loaders():
    transform_train = transforms.Compose([
    transforms.RandomHorizontalFlip(),
    transforms.RandomCrop(32, padding=4),
    transforms.ToTensor(),
    transforms.Normalize((0.5, 0.5, 0.5), (0.5, 0.5, 0.5)),
    ])
    transform_test = transforms.Compose([
    transforms.ToTensor(),
    transforms.Normalize((0.5, 0.5, 0.5), (0.5, 0.5, 0.5)),
    ])
    trainds = torchvision.datasets.CIFAR10(root='./data', train=True, download=True, transform=transform_train)
    trainloader = torch.utils.data.DataLoader(trainds, batch_size=128, shuffle=True, num_workers=2)
    testds = torchvision.datasets.CIFAR10(root='./data', train=False, download=True, transform=transform_test)
    testloader = torch.utils.data.DataLoader(testds, batch_size=128,shuffle=False, num_workers=2)
    return trainds, trainloader, testds, testloader
