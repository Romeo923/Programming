#AEClassifierNetwork
import torch 
from AENetwork import AENetwork 
 
class AEClassifierNetwork(torch.nn.Module): 
 def __init__(self, input_dim, hidden_dim, latent_dim,num_classes): 
  super().__init__() 
  # load pretrained model for the AE 
  path = './Models/save_ae_cancer.pth' 
  self.AENet = AENetwork(input_dim,hidden_dim,latent_dim) 
  self.AENet.load_state_dict(torch.load(path)) 
  self.AENet.train() # set the paramaters to train 
  # for fine tuning the entire model 
 
  # attach classifier to AE 
  self.fc1 = torch.nn.Linear(latent_dim, 10)  
  self.fc2 = torch.nn.Linear(10, num_classes) 
  self.smax = torch.nn.Softmax(dim=1) 
 
 def forward(self, x): 
  latent,_ = self.AENet(x) 
  h1 = self.fc1(latent) 
  out = self.fc2(h1) 
  return out  