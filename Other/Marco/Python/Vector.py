class Vector:

    def __init__(self,x: float,y: float):
        self.x = x
        self.y = y
        self.magnitude = (x**2 + y**2)**(0.5)

    # adds 2 vectors: v1 + v2
    def __add__(self, v2: 'Vector') -> 'Vector':
        return Vector(self.x + v2.x, self.y + v2.y)

    # multiplies a vector by a scalar from left: v1 * 4 
    def __mul__(self, n: int) -> 'Vector':
        return Vector( self.x*n, self.y*n)

    # dot product of 2 vectors: v1 · v2
    def __mul__(self, v2: 'Vector') -> float:
        return self.x*v2.x + self.y+v2.y
    
    # multiplies a vector by a scalar from right: 4 * v1  
    def __rmul__(self, n: int) -> 'Vector':
        return Vector( self.x*n, self.y*n)

    # string representation of vector
    def __str__(self) -> str:
        return f"<{self.x}, {self.y}>"