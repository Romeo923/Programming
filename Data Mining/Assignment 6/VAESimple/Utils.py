#Utils.py
import torch 
from torchvision import datasets, transforms 
from torch.autograd import Variable 
from torchvision.utils import save_image 
 
class Utils(object): 
    def get_loaders(self, batch_size=100): 
        train_dataset = datasets.MNIST(root='./mnist_data/', train=True, transform=transforms.ToTensor(), 
download=True) 
        test_dataset = datasets.MNIST(root='./mnist_data/', train=False, transform=transforms.ToTensor(), 
download=True) 
 
        # data Loaders  
        train_loader = torch.utils.data.DataLoader(dataset=train_dataset, batch_size=batch_size, 
shuffle=True) 
        test_loader = torch.utils.data.DataLoader(dataset=test_dataset, batch_size=batch_size, 
shuffle=False) 
        return train_loader, test_loader 