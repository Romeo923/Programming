import numpy as np
from matplotlib import pyplot as plt

deltat=0.01
m=145.94
k=24594
c=200
x0=0.01
v0=0.1
t= (i*0.01 for i in range(600))
omegan = np.sqrt(k/m)
ccr=2*np.sqrt(m*k)
zeta=c/ccr
omegad=omegan*np.sqrt(1-zeta^2)
fo=150
omegaf=5
Tfinal=6
Fo=fo/m

B=np.atan2(2*zeta*omegaf*omegan,omegan^2-omegaf^2)
X=Fo/(np.sqrt((omegan^2-omegaf^2)^2+(2*zeta*omegan*omegaf)^2))
A2=x0-X*np.cos(B)
A1=(v0+zeta*omegan*A2-X*omegaf*np.sin(B))/omegad
# x_t=np.exp(-zeta*omegan*t).*(A1.*np.sin(omegad*t))+np.exp(-zeta*omegan*t).*(A2.*np.cos(omegad*t))+X*np.cos(omegaf*t-B)
x = (np.exp(-zeta*omegan*i)*(A1*np.sin(omegad*i)) + np.exp(-zeta*omegan*i)*(A2*np.cos(omegad*i)) + X*np.cos(omegaf*i-B) for i in t)
plt.plot(x)
plt.show