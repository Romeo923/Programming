import json
from tkinter import *
# from tkmacosx import *
from tkinter import ttk

class Course:

    def __init__(self,id,credits,requirements,semester,year):
        self.ID = id
        self.credits = credits
        self.requirements = requirements
        self.semester = semester
        self.year = year

    def __str__(self):
        return f"""
        Course Number: {self.ID}
        Credits:       {self.credits}
        Requirements:  {self.requirements}
        Semester:      {self.semester}
        Year:          {self.year}
        """

class Student:

    def __init__(self,name,id,courses):
        self.name = name
        self.ID = id
        self.courses = [Course(id=data["ID"],credits=data["credits"],requirements=data["requirements"],semester=data["semester"],year=data["year"]) for data in courses]

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

class State:

    def __init__(self,file_path,root,frame,student_list):
        self.file_path = file_path
        self.root = root
        self.frame = frame
        self.student_list = student_list

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
                "ID":course.ID,
                "semester":course.semester,
                "year":course.year,
                "credits":course.credits,
                "requirements":course.requirements
            })

        students.append({
            "name":student.name,
            "ID":student.ID,
            "courses":courses
        })

    with open(file_path,'w') as file:
        json.dump({"Students":students},file,indent=2)

def save(student,state,name,id):

    student.name = name
    student.ID = id

    if student.ID == 0:
        return

    add = False
    for i, s in enumerate(state.student_list):
        if student.ID == s.ID:
            state.student_list[i] = student
            add = True
    if add is False:
        state.student_list.append(student)

    write(student_list=state.student_list,file_path=state.file_path)
    profile(student=student,state=state)

def home(state):
    
    updateStudentDir(state)
    state.frame.destroy()
    state.frame = Frame(state.root)
    Label(state.frame,text="Students\n").grid(column=0,row=0)
    for i, student in enumerate(state.student_list):
        Button(state.frame,text=student.name,command=lambda s=student,st = state: profile(student=s,state=st)).grid(column=0,row=(i+1))
    Button(state.frame,text="Add Student",command=lambda st = state: profile(student=Student("",0,courses=[]),state=st)).grid(column=0)
    state.frame.pack()
    
def profile(student,state):
    
    state.frame.destroy()
    state.frame = Frame(state.root)

    Label(state.frame,text="Student Name: ").grid(column=1,row=0)
    name = Entry(state.frame)
    name.insert(0,student.name)
    name.grid(column=2,row=0)

    Label(state.frame,text="Student ID: ").grid(column=1,row=1)
    id = Entry(state.frame)
    id.insert(0,student.ID)
    id.grid(column=2,row=1)

    tree = generateTree(student=student,state=state)

    Label(state.frame,text="Course").grid(column=1,row=3)
    cid = Entry(state.frame)
    cid.grid(column=1,row=4)
    Label(state.frame,text="Requirements").grid(column=2,row=3)
    req = Entry(state.frame)
    req.grid(column=2,row=4)
    Label(state.frame,text="Credits").grid(column=3,row=3)
    credits = Entry(state.frame)
    credits.grid(column=3,row=4)
    
    Button(state.frame,text="Add Course",command=lambda : addCourse(student=student,state=state,course=Course(id=cid.get(),semester='Fall',credits=int(credits.get()),requirements=req.get().split(','),year=1),tree=tree)).grid(column=0,row=5)
    Button(state.frame,text="Save",command=lambda s=student,st = state : save(student=s,state=st,name=name.get(),id=int(id.get()))).grid(column=1,row=5)
    Button(state.frame,text="Delete Student",command=lambda s=student, st = state: deleteStudent(student=s, state=st)).grid(column=2,row=5)
    Button(state.frame,text="Home",command=lambda st = state: home(state=st)).grid(column=3,row=5)
    state.frame.pack()

def generateTree(student,state):
    tree = ttk.Treeview(state.frame)
    tree['columns'] = ('Course','Requirements','Credits')
    tree.column('#0',width=0,stretch=NO)
    tree.column('Course',width=120,anchor=CENTER)
    tree.column('Requirements',width=120,anchor=CENTER)
    tree.column('Credits',width=120,anchor=CENTER)
    tree.heading('Requirements',text="Requirements")
    tree.heading('Course',text="Course")
    tree.heading('Credits',text="Credits")

    for i, course in enumerate(student.courses):
        tree.insert(parent='',index='end',iid=i,values=(course.ID,course.requirements,course.credits))

    tree.insert(parent='',index='end',iid=999,tags=('total',),values=('','Total Credits:',student.totalCreds()))
    tree.tag_configure('total',foreground='white',background='black')
    tree.grid(columnspan=4,row=2)

    return tree

def addCourse(student,state,course,tree):
        student.courses.append(course)
        profile(student=student,state=state)

def createFrame(file_path):

    root = Tk()
    root.geometry("800x750")
    frame = Frame(root)

    state = State(file_path=file_path,root=root,student_list=None,frame=frame)
    
    home(state)
    root.mainloop()

def deleteStudent(student,state):
    for i, s in enumerate(state.student_list):
        if s.ID == student.ID:
            del state.student_list[i]
    write(student_list=state.student_list,file_path=state.file_path)
    home(state=state)

def updateStudentDir(state):
    students = load(state.file_path)
    state.student_list = [Student(name=data["name"],id=data["ID"],courses=data["courses"]) for data in students]