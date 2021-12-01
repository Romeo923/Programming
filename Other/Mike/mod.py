from matplotlib import pyplot as plt

T = 5 # period

t = [round(i*0.01,2) for i in range(2*T*100)] # time t = 0:0.01:T

y = [2 if x%T <= T/2 else 4 for x in t] # y = 2 if t mod T <= T/2, 4 otherwise

plt.plot(t,y)
plt.show()

