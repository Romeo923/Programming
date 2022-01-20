
class Set:
    def __init__(self,n=None):
        self.elements = [] if n is None else list(n.elements)
    
    def __str__(self):
        # if len(self.elements) == 0:
        #     return 'Ø'
        
        s = '{'

        for n in self.elements:
            s += f"{n},"

        if len(self.elements) > 0:
            s = s[:-1]
        s += '}'
        
        return s

    def __repr__(self):
        return self.__str__()
            
    
    def __or__(self,n):
        s = Set(self)
        s.elements.append(n)
        return s
        
    

class TheNaturals:
    def __init__(self):
        self.naturals = {0:Set()}
        self.max = 0
    
    def __getitem__(self,n):
        return self.successor(n-1) if n > self.max else self.naturals[n]
    
    def successor(self,n):
        
        if n+1 > self.max:    
            N = self.successor(n-1)
            self.naturals[n+1] = N | Set(N)
            self.max = n+1
            
        return self.naturals[n+1]
    

the_naturals = TheNaturals()

print(the_naturals[15])