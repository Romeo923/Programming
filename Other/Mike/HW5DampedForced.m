function dx=HW5DampedForced(t,x,m,c,k,Fo,omegaf)

%need to set the shape of dx 
dx=zeros(2,1);

dx(1)=x(2); %the usual, omega is the derivative of theta 
dx(2)=-k/m*x(1)-c/m*x(2)+Fo*cos(omegaf*t);

end
