%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%Michael DeDonato CC = 4594
%ENGR431 H5P4.m
%10/22/2021
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
clear; clc; clf; 

deltat=0.01;
m=145.94;
k=24594;
c=200;
x0=0.01;
v0=0.1;
t=0:0.01:6;
omegan= sqrt(k/m);
ccr=2*sqrt(m*k);
zeta=c/ccr;
omegad=omegan*sqrt(1-zeta^2);
fo=150;
omegaf=5;
Tfinal=6;
Fo=fo/m;


B=atan2(2*zeta*omegaf*omegan,omegan^2-omegaf^2);
X=Fo/(sqrt((omegan^2-omegaf^2)^2+(2*zeta*omegan*omegaf)^2));
A2=x0-X*cos(B);
A1=(v0+zeta*omegan*A2-X*omegaf*sin(B))/omegad;
x_t=exp(-zeta*omegan*t).*(A1.*sin(omegad*t))+exp(-zeta*omegan*t).*(A2.*cos(omegad*t))+X*cos(omegaf*t-B);

%Runge Kutta Approximation 

options=odeset('RelTol',1e-4,'AbsTol',[1e-4,1e-4]);
[T,X]=ode45(@(t,x)HW5DampedForced(t,x,m,c,k,Fo,omegaf),[0 Tfinal],[x0 v0], options);

plot(t, x_t,T, X(:,1));

legend("Theoretical","Runge Kutta")
ylabel('Position [m]')
xlabel('Time [s]')
title('Theoretical vs. Runge Kutta approximation for a Damped Forced System')
grid on 
saveas(gcf,'H5P4.jpg');

%solutions at t= 1.45s

clear X 
x_t(145);
%copied from workspace 
X=-0.00264881290719953;



P=abs(X/x_t(145));
disp('The percent difference between the RK and Teoretical at t=1.45s')
disp(P)







