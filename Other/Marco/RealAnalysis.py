class TheNaturals:
    def __init__(self):
        self.empty = 'Ø'
        self.naturals = {0:self.empty}
        self.max = 0
    
    def __getitem__(self,n):
        return self.successor(n-1) if n > self.max else self.naturals[n]
    
    def successor(self,n):
        
        if n+1 > self.max:    
            N = self.successor(n-1)
            # self.naturals[n+1] = 
            self.max = n+1
            
        return self.naturals[n+1]
    
    
THE_NATURALS = TheNaturals()
print(THE_NATURALS[0])
print(THE_NATURALS[1])
print(THE_NATURALS[2])
print(THE_NATURALS[3])
print(THE_NATURALS.naturals)