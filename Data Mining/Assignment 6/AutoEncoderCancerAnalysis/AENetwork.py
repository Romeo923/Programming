#AENetwork.py
import torch 
 
class AENetwork(torch.nn.Module): 
 def __init__(self, input_dim, hidden_dim, latent_dim): 
  super().__init__() 
  self.encoder = torch.nn.Sequential( 
   torch.nn.Linear(input_dim, hidden_dim), 
   torch.nn.ReLU(), 
   torch.nn.Linear(hidden_dim, latent_dim),  
   torch.nn.ReLU() 
  ) 
 
  self.decoder = torch.nn.Sequential( 
   torch.nn.Linear(latent_dim, hidden_dim), 
   torch.nn.ReLU(), 
   torch.nn.Linear(hidden_dim, input_dim), 
   torch.nn.ReLU() 
  ) 
 
 def forward(self, x): 
  latent = self.encoder(x) 
  decoded = self.decoder(latent) 
  return latent, decoded  
  # after training, latent will be used in classification 