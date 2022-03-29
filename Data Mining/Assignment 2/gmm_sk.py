#------------------GMM_SKL.py-----------------------
import sklearn
from sklearn.mixture import GaussianMixture
import numpy as np
from scipy import stats
import sys
import pandas as pd
from scipy.stats import mode

def main():
    #---------------Iris Dataset-------------
    df = pd.read_csv("Data Mining\Data Sets\iris.csv")
    #---randomize data
    dfrandom = df #df.sample(frac=1, random_state=1119).reset_index(drop=True)
    # data read from a file is read as a string, so convert the first 4 cols to float
    df1 = dfrandom.iloc[:,0:4].astype(float)
    #---separate out the last column
    df2 = dfrandom.iloc[:,4]
    #---combine the 4 numerical columns and the last column that has the flower category
    dfrandom = pd.concat([df1,df2],axis=1)
    print(dfrandom)
    #--------------GMM-----------------
    xdata = df1.values[:,0:4]
    print(xdata.shape)
    N = xdata.shape[0]
    gm = GaussianMixture(n_components=3, max_iter=20)
    gm.fit(xdata)
    print(gm.means_)
    print(gm.weights_)
    print(gm.covariances_)
    z = gm.score(xdata)
    print(z)

    #-----compute accuracy--------
    preds = gm.predict(xdata)
    print(preds)
    cluster_assigned = []
    # since GMM is unsupervised, class assignments to clusters may vary on each run
    cluster_assigned = [mode(preds[0:50])[0], mode(preds[50:100])[0], mode(preds[100:150])[0]]
    acc = 0
    for i in range(0,N):
        if preds[i] == cluster_assigned[0] and i < 50: # first 50 members belong to class 0
            acc = acc + 1
        if preds[i] == cluster_assigned[1] and i >=50 and i < 100: # next 50 are class 1
            acc = acc + 1
        if preds[i] == cluster_assigned[2] and i >= 100 and i < 150: # last 50, class 2
            acc = acc + 1
    print('accuracy =',acc/N*100)

if __name__ == "__main__":
    sys.exit(int(main() or 0))
