from account import *
from virtualKey import *
import json

def loadData(path):
    with open(path) as file:
            accounts = json.load(file)    
    return accounts

def save(accounts, user):
    accounts[user.username] = {
        "password":user.password,
        "id":user.id,
        "keys":[
            {
                "temporary": key.temporary,
                "endDate": key.end_date,
                "id": key.id,
                "hasAccess": key.has_access
            } for key in user.keys
        ]
    }

def write(accounts, path):
        with open(path,'w') as file:
            json.dump(accounts,file,indent=2)

def encrypt(password):
    
    
    return password

def main():
    path = 'ORE Locks\\accounts.json'
    accounts = loadData(path)
    user = None
    run = True
    login = True
    
    while login:
        action = int(input('\n1. Login\n2. Register\n3. Exit\n>> '))

        if action == 1:
        
            username = input("Enter your username: ")
            password = input("Enter your password: ")
            try:
                temp = accounts[username]
                user = Account(
                    username,
                    temp["password"],
                    temp["id"],
                    [VirtualKey(
                        key["temporary"], 
                        key["endDate"], 
                        key["id"], 
                        key["hasAccess"]
                        ) for key in temp["keys"]])
                
                if user.password == encrypt(password):
                    print("Login Success")
                    login = False
                else:
                    user = None
                    print("Incorrect Username or Password")    
            except IndexError:    
                print("Incorrect Username or Password")

        elif action == 2:
            username = input("Enter your username: ")
            password = input("Enter your password: ")

            if username in accounts:
                print("An account with this username already exists")
            else:
                user = Account(username, encrypt(password),f'{len(accounts)}')
                save(accounts,user)
                write(accounts,path)
                print("Account Created")
                login = False    
            

        elif action == 3:
            login = False
            run = False
            print("Goodbye...")

    while run:
        run = False


if __name__ == '__main__':
    main()