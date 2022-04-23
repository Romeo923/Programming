#VAEModel.py
import torch 
import torch.nn as nn 
import torch.nn.functional as F 
 
class VAEModel(nn.Module): 
    def __init__(self, x_dim, h_dim1, h_dim2, z_dim): 
        super(VAEModel, self).__init__() 
        # ----encoder components 
        self.fce1 = nn.Linear(x_dim, h_dim1) 
        self.fce2 = nn.Linear(h_dim1, h_dim2) 
        self.fcMu = nn.Linear(h_dim2, z_dim) 
        self.fcSigma = nn.Linear(h_dim2, z_dim) 
        # ----decoder components 
        self.fcd1 = nn.Linear(z_dim, h_dim2) 
        self.fcd2 = nn.Linear(h_dim2, h_dim1) 
        self.fcdout = nn.Linear(h_dim1, x_dim) 
         
    def encoder(self, x): 
        h = F.relu(self.fce1(x)) 
        h = F.relu(self.fce2(h)) 
        return self.fcMu(h), self.fcSigma(h) # mu, log_var 
     
    def reparameter_sampling(self, mu, log_var): 
        std = torch.exp(0.5*log_var) 
        eps = torch.randn_like(std) 
        return eps.mul(std).add_(mu) # return z sample 
         
    def decoder(self, z): 

 
        h = F.relu(self.fcd1(z)) 
        h = F.relu(self.fcd2(h)) 
        return F.sigmoid(self.fcdout(h))  
     
    def forward(self, x): 
        mu, log_var = self.encoder(x.view(-1, 784)) 
        z = self.reparameter_sampling(mu, log_var) 
        #print(z) 
        out = self.decoder(z) 
        return out, mu, log_var 