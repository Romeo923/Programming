#Network.py
import torch 
import sys 
import torch.nn as nn  
import torchvision 
 
# CNN network followed by a with one hidden layer classifier 
class Network(nn.Module): 
     def __init__(self, input_dim, hidden_size1,  num_classes): 
        super(Network, self).__init__() 
        self.relu = nn.ReLU() 
        self.fc1 = nn.Linear(input_dim, hidden_size1)  
        self.fc2 = nn.Linear(hidden_size1, num_classes) 
        self.smax = nn.Softmax(dim=1) 
          
     def forward(self, x): 
         out = self.fc1(x) 
         out = self.relu(out) 
         out = self.fc2(out) 
         out = self.smax(out) 
         return out 