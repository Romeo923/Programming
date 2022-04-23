#VAESimple.py
import sys 
from Utils import Utils 
from VAEModel import VAEModel 
import torch 
import torchvision 
import torch.optim as optim 
import torch.nn.functional as F 
import matplotlib.pyplot as plt 
import numpy as np 
 
def main(): 
    ngpu = 1 
    device = torch.device("cuda:0" if (torch.cuda.is_available() and ngpu > 0) else "cpu") 
    utils = Utils() 
    train_loader, test_loader = utils.get_loaders() 
 
 
    vaemodel = VAEModel(x_dim=784, h_dim1= 512, h_dim2=256, z_dim=2).to(device) 
    epochs = 10 
    optimizer = optim.Adam(vaemodel.parameters()) 
    train(epochs, vaemodel, train_loader, test_loader, optimizer) 
    PATH = "./vaemodel.pt" 
    # save model 
    torch.save(vaemodel, PATH) 
 
    #-------to view randomly generated images by vae 
    vaemodel = torch.load(PATH) # load trained model 
    vaemodel.eval() 
    with torch.no_grad(): 
        z = torch.randn(64, 2).to(device) # random sample 
        gen_sample = vaemodel.decoder(z).to(device) 
     
    #--------to view training images reconstructed by vae 
    #--------uncomment following 5 lines 
    #train_loader, test_loader = utils.get_loaders(64) 
    #real_batch = next(iter(test_loader)) 
    #print(real_batch[0].shape) 
    #gen_images = vaemodel(real_batch[0].to(device)) 
    #gen_sample = gen_images[0].detach() 
 
 
    # uncomment following 2 lines to view original images 

 
    #gen_sample = real_batch[0].cuda()  
    #gen_images = gen_sample.view(64,1,28,28).cpu()  
 
    # convert 64x784 to 64,1,28,28 for display 
    gen_images = gen_sample.view(64,1,28,28).cpu() 
    plt.figure(figsize=(8,8)) 
    plt.axis("off") 
    plt.title("Reconstructed Random Images by VAE") 
    grid_img = torchvision.utils.make_grid(gen_images, nrow=8) 
    plt.imshow(grid_img.permute(1, 2, 0)) 
    plt.show() 
 
def train(epochs, vaemodel, train_loader, test_loader, optimizer): 
    vaemodel.train()  # set it in train mode 
    train_loss = 0 
    for i in range(epochs): 
        for batch_idx, (data, _) in enumerate(train_loader): 
            data = data.cuda() 
            optimizer.zero_grad() # clear gradients 
         
            recon_batch, mu, log_var = vaemodel(data) 
            loss = loss_function(recon_batch, data, mu, log_var) 
         
            loss.backward() 
            train_loss += loss.item() 
            optimizer.step() 
         
            if batch_idx % 1000 == 0: 
                print('Train Epoch: {} [{}/{} ({:.0f}%)]\tLoss: {:.6f}'.format( 
                    epochs, batch_idx * len(data), len(train_loader.dataset), 
                    100. * batch_idx / len(train_loader), loss.item() / len(data))) 
        print('====> Epoch: {} Average loss: {:.4f}'.format(i, train_loss / len(train_loader.dataset))) 
 
 
def loss_function(recon_x, x, mu, log_var): 
    BCE = F.binary_cross_entropy(recon_x, x.view(-1, 784), reduction='sum') 
    KLD = -0.5 * torch.sum(1 + log_var - mu.pow(2) - log_var.exp()) 
    return BCE + KLD 
 
if __name__ == "__main__": 
    sys.exit(int(main() or 0)) 