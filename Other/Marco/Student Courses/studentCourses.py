from Utils import *
from tkinter import *
from tkmacosx import *
from tkinter import ttk

def main():
    
    root = Tk()
    root.geometry("600x250")
    
    path = 'student_data.json'
    students = load(path)
    slist = [Student(name=data["name"],id=data["ID"],courses=data["courses"]) for data in students]

    s1 = Student("Marco",10000,[{
        "name":"Test",
        "ID":"Test-500",
        "semester":"Spring",
        "credits":3,
        "registered":True        
    }])

    setHome(root,slist)
    root.mainloop()

if __name__ == '__main__':
    main()



# slist.append(s1)

# save(slist[:-1],path)

# for s in slist:
#     print(s)
#     print('-=-=-=-=-=-=-=-=-=-=-=-=-')
    # print("Fall\n")
    # for course in s.fallCourses():
    #     print(course)
    #     print("-----------------------")

    # print("Spring\n")       
    # for course in s.springCourses(): 
    #     print(course)
    #     print("-----------------------")
    # print('-=-=-=-=-=-=-=-=---=-=-=-=-=-=-=-=-')