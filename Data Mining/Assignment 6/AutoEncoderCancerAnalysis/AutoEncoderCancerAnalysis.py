#AutoEncoderCancerAnalysis.py
import sys 
import Utils 
from AENetwork import AENetwork 
import torch 
import torch.nn as nn 
 
def main(): 
    # train and save just the auto encoder model 
    device = 'cuda' if torch.cuda.is_available() else 'cpu' 
 
    hidden_size = 60 
    num_classes = 5 
    num_epochs = 50 
    batch_size = 10 
    hidden_dim = 60 
    latent_dim = 30 
    input_dim = 20531 
    learning_rate = 0.001  
 
    train_loader, test_loader = Utils.get_train_test_loaders(batch_size) 
  
    model = AENetwork(input_dim, hidden_size, latent_dim).to(device) 
 
    criterion = nn.MSELoss() # for AE, MSE loss works better 

 
    optimizer = torch.optim.Adam(model.parameters(), lr=learning_rate)  
 
    num_total_steps = len(train_loader) 
    for epoch in range(num_epochs): 
        for i, (x, _) in enumerate(train_loader):  
            x = x.to(device) # convert to CPU or GPU tensor 
            labels = x # for AE, output is same as input 
              
            _, pred_outputs = model(x) # calls forward function 
             
            loss = criterion(pred_outputs, labels) 
            optimizer.zero_grad() # clear gradients 
            loss.backward()  # compute gradients 
            optimizer.step() # update weights and biases 
            if (i+1) % 10 == 0: 
                print(f'Epoch [{epoch+1}/{num_epochs}], Step[{i+1}/{num_total_steps}], Loss: {loss.item():.4f}')  
     
    # save trained AE model 
    torch.save(model.state_dict(), 'Data Mining\Assignment 6\AutoEncoderCancerAnalysis\Models') 
if __name__ == "__main__": 
    sys.exit(int(main() or 0)) 
