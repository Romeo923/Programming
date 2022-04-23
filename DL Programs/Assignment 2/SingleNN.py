import sys

def main():
    # y = 2x + 0.3
    # x0 corresponds to x coordinate, x1 corresponds to y coordinate of a point
    # If the given point is below the y = 2x + 0.3 line, the Neural Network is
    # to output a 0, if the point is above the line, it's output is to be 1.
    #------create some training data---------
    x0 = [1,2,3,4,5,6,7,8,9,10]
    x1 = [2.2,4.5,5.6,8.6,10.15,12.44,14.23,16.2,18.4,20.4]
    y = [0,1,0,1,0,1,0,0,1,1] # expected outputs of the network (do not confuse it
    # with y coordinate of a point)
    #-------initialize weights and biases
    w0 = 0.1
    w1 = -0.23
    b = 0.22
    #-------- train the single neuron network
    # need 10000 epochs, with 0.001 learning rate
    for i in range(0,10000):
        loss = 0
        for j in range(0,len(y)):
            a = w0*x0[j] + w1 * x1[j] + b
            loss += 0.5 * (y[j] - a)**2
            dw0 = -(y[j]-a)*x0[j]
            dw1 = -(y[j]-a)*x1[j]
            db = -(y[j]-a)
            w0 = w0 - 0.001 * dw0
            w1 = w1 - 0.001 * dw1
            b = b - 0.001 * db
        print('loss =',loss)
    # -----test for unknown data, on the trained network----------
    x0 = 2.7 # x coord. of point
    x1 = 6.0 # y coord. of point
    output = x0*w0 + x1*w1 + b
    print('output for (',x0,',',x1,')= ',output)
    x0 = 5.3 # x coord. of point
    x1 = 10.4 # y coord. of point
    output = x0*w0 + x1*w1 + b
    print('output for (',x0,',',x1,')= ',output)

if __name__ == "__main__":
    sys.exit(int(main() or 0))