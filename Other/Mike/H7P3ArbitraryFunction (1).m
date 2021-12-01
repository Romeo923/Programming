function y=H7P3ArbitraryFunction(t,T);
    y=zeros(size(t));
        for i=1:size(t,2)
            ti=mod(t(i),T);
            if ti <=1.64
               y(i)=1.5*(ti-1.64)^3;
            else 
               y(i)=2.4594*(ti-1.64)^2;
            end
         end
end

t = 0:0.01:15;

plot(t,y)