import json
from tkinter import *
# from tkmacosx import *
from tkinter import ttk


class Course:

    def __init__(self,name,id,credits,semester,year,registered):
        self.name = name
        self.ID = id
        self.credits = credits
        self.semester = semester
        self.year = year
        self.registered = registered

    def __str__(self):
        return f"""
        Course Name:   {self.name}
        Course Number: {self.ID}
        Credits:       {self.credits}
        Semester:      {self.semester}
        Year:          {self.year}
        Registered:    {self.registered}
        """

class Student:

    def __init__(self,name,id,courses):
        self.name = name
        self.ID = id
        self.courses = [Course(name=data["name"],id=data["ID"],credits=data["credits"],semester=data["semester"],year=data["year"],registered=data["registered"]) for data in courses]

    def adddCourse(self,course):
        self.courses.append(course)

    def getCourses(self,semester,year):
        return (course for course in self.courses if (course.semester == semester and course.year == year))

    def totalCreds(self):
        return sum([course.credits for course in self.courses])

    def __str__(self):
        
        student_str = f"""
        Student Name:   {self.name}
        Student ID:     {self.ID}
        Courses:
        ---------------------------
        """
        for course in self.courses:
            student_str += f'{course}\n'

        return student_str


def load(file_path):

    with open(file_path) as file:
        students = json.load(file)["Students"]
    
    return students

def write(student_list, file_path):
    students = []
    for student in student_list:
        courses = []
        for course in student.courses:
            courses.append({
                "name":course.name,
                "ID":course.ID,
                "semester":course.semester,
                "year":course.year,
                "credits":course.credits,
                "registered":course.registered
            })

        students.append({
            "name":student.name,
            "ID":student.ID,
            "courses":courses
        })

    with open(file_path,'w') as file:
        json.dump({"Students":students},file,indent=2)
               
def setHome(root,student_list,frame=None):
    if(frame):
        frame.destroy()
    frame = Frame(root)
    Label(frame,text="Students\n").grid(column=0,row=0)
    for i, student in enumerate(student_list):
        Button(frame,text=student.name,command=lambda r=root,s=student,f=frame,sl=student_list: profile(root=r,student=s,frame=f,student_list=sl)).grid(column=0,row=(i+1))
    frame.pack()
    
def profile(root,student,student_list,frame=None):
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


    Button(frame,text="Home",command=lambda r=root,f=frame,s=student_list: setHome(root=r,student_list=s,frame=f)).grid(column=0,row=3)
    frame.pack()

def createFrame(student_list):
    root = Tk()
    root.geometry("600x250")
    setHome(root,student_list)
    root.mainloop()

