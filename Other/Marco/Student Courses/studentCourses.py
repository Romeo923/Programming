from Utils import *

def main():
    
    path = 'student_data.json'
    students = load(path)
    slist = [Student(name=data["name"],id=data["ID"],courses=data["courses"]) for data in students]

    # s1 = Student("Marco",10000,[{
    #     "name":"Test",
    #     "ID":"Test-500",
    #     "semester":"Spring",
    #     "year": 2,
    #     "credits":3,
    #     "registered":True        
    # }])

    createFrame(slist)


if __name__ == '__main__':
    main()
