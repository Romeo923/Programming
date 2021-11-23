import random
from matplotlib import pyplot as plt

dataSize = 50 # number of elements that will be sorted
numRange = 1000 # range of the randomly generated numbers
numIter = 10000 # number of sorting iterations, the amount of lists it will sort

def bubbleSort(list):
    passnum = 1
    swap = True
    n = len(list)
    while swap and (passnum <= n-1):
        swap = False
        for i in range(n-passnum):
            if list[i] > list[i+1]:
                temp = list[i]
                list[i] = list[i+1]
                list[i+1] = temp
                swap = True
        passnum+=1
    return passnum


# generates graph
passes = [0 for i in range(dataSize)] #tracks frequency for each number of passes
for i in (bubbleSort([random.randint(0,numRange) for i in range(dataSize)]) for i in range(numIter)):
    passes[i-1] += 1

plt.plot(passes)
plt.xlabel('Number of Passes')
plt.ylabel('Frequency')
plt.show()
