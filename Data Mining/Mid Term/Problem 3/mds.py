import sys
from sklearn.datasets import fetch_openml
import numpy as np
import matplotlib.pyplot as plt
from sklearn.manifold import MDS
from sklearn.preprocessing import StandardScaler

import pandas as pd
import Utils

def main():
    # Load the MNIST data
    #X, y = fetch_openml('mnist_784', version=1, return_X_y=True, as_frame=False)
    X, y = Utils.read_data() # cancer data
    # randomly select 800 samples from dataset
    np.random.seed(100)
    subsample_idc = np.random.choice(X.shape[0], 800, replace=False)
    X = X[subsample_idc,:]
    y = y[subsample_idc]
    y = np.array([int(lbl) for lbl in y])
    n_components = 2
    #X = StandardScaler().fit_transform(X) # subtract mean, divide by var
    mds = MDS(n_components)
    mds_result = mds.fit_transform(X)
    print(mds_result.shape) # 2d for visualization
    plt.scatter(mds_result[:,0], mds_result[:,1], s= 5, c=y, cmap='Spectral')
    plt.colorbar(boundaries=np.arange(11) - 0.5).set_ticks(np.arange(len(np.unique(y))))
    plt.show()

if __name__ == "__main__":
    sys.exit(int(main() or 0))