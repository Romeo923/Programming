
class Account:

    def __init__(self,username,password,ID, keys = list()) -> None:
        self.username = username
        self.password = password
        self.id = ID
        self.keys = keys

    def addKey(self,key):
        self.keys.append(key)

