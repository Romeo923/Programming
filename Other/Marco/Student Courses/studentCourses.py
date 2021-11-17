from Utils import *
from tkinter import *
from tkinter import ttk

path = 'student_data.json'
students = load(path)
slist = [Student(name=data["name"],id=data["ID"],courses=data["courses"]) for data in students]

def profile(root,student,frame=None):
    if(frame):
        frame.destroy()
    frame = Frame(root)
    Label(frame,text="Student Name: ").grid(column=0,row=0)
    name = Entry(frame)
    name.insert(0,student.name)
    name.grid(column=1,row=0)

    Label(frame,text="Student ID: ").grid(column=0,row=1)
    id = Entry(frame)
    id.insert(0,student.ID)
    id.grid(column=1,row=1)

    tree = ttk.Treeview(frame)
    tree['columns'] = ('Registered','Course Name', 'Course No.','Credits')
    tree.column('#0',width=0,stretch=NO)
    tree.column('Registered',width=120,anchor=CENTER)
    tree.column('Course Name',width=120,anchor=CENTER)
    tree.column('Course No.',width=120,anchor=CENTER)
    tree.column('Credits',width=120,anchor=CENTER)
    tree.heading('Registered',text="Registered")
    tree.heading('Course Name',text="Course Name")
    tree.heading('Course No.',text="Course No.")
    tree.heading('Credits',text="Credits")

    for i, course in enumerate(student.courses):
        tree.insert(parent='',index='end',iid=i,values=(course.registered,course.name,course.ID,course.credits))
    tree.insert(parent='',index='end',iid=999,values=('','','Total Credits:',student.totalCreds()))
    
    tree.grid(column=1,row=3)


    Button(frame,text="Home",command=lambda r=root,f=frame: setHome(r,slist,f)).grid(column=0,row=3)
    frame.pack()
        
def setHome(root,student_list,frame=None):
    if(frame):
        frame.destroy()
    frame = Frame(root)
    Label(frame,text="Students\n").grid(column=0,row=0)
    for i, student in enumerate(student_list):
        Button(frame,text=student.name,command=lambda r=root,s=student,f=frame: profile(r,s,f)).grid(column=0,row=(i+1))
    frame.pack()

def main():
    
    root = Tk()
    root.geometry("600x250")

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