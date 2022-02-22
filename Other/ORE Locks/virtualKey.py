from tempfile import TemporaryDirectory

from sympy import Id


class VirtualKey:
    
    def __init__(self,temporary, end_date, ID, has_access = list()) -> None:
        self.temporary = temporary
        self.end_date = end_date
        self.id = ID
        self.has_access = has_access