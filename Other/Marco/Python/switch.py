import numpy as np

sigmoid = lambda x: 1/(1+np.e**x)    # 1
sigmoidP = lambda x: x*(1-x)

identity = lambda x: x               # 2
identityP = lambda x: 1

# add whatever activation and derivative function you want


# changes switch value based on user input
# switch value will determine activation function and derivative

switch = int(input("""
\nSelect activation Function
\n--------------------------
\nSigmoid  : 1
\nIdentity : 2
\nInput: """))

# alternatively, you can manually change switch or get the value form another file


if switch == 1:
    aFunction = sigmoid
    aPrime = sigmoidP

elif switch == 2:
    aFunction = identity
    aPrime = identityP

# elif switch == 3:

# ...

# else:

# cases for each activation function


# asks user for a value to input into the activation function
x = int(input('\nWhat value would you like to input: '))
# again, this value can also be changed manually or taken from a file

# returns output for activation function and its derivative
def f(x):
    a = aFunction(x)
    a1 = aPrime(a)
    return a, a1

a , a1 = f(x)

print(a,a1,'\n')

