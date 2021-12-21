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
        return [course for course in self.courses if (course.semester == semester and course.year == year)]

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

class StatBar(Frame):

    def __init__(self,parent,course_list):
        Frame.__init__(self,parent)

        self.reqs = ["SS","HU"]

        for i, req in enumerate(self.reqs):
            Label(self,text=f'{req} Credits').grid(column=i,row=0)
            creds = sum([course.credits for course in course_list if req in course.requirements])
            Label(self,text=f'{creds}').grid(column=i,row=1)
        Label(self,text='Total Credits').grid(column=len(self.reqs),row=0)
        creds = sum([course.credits for course in course_list])
        Label(self,text=f'{creds}').grid(column=len(self.reqs),row=1)

class Table(Frame):

    def __init__(self, parent, course_list, semester, year):
        Frame.__init__(self,parent)

        self.course_list = course_list
        self.semester = semester
        self.year = year
        self.course_data = []

        Label(self,text='Course').grid(column=0,row=0)
        Label(self,text='Reqs').grid(column=1,row=0)
        Label(self,text='Credits').grid(column=2,row=0)

        for i, course in enumerate(self.course_list):
            
            name = Entry(self)
            name.insert(0,course.ID)
            name.grid(column=0,row=i+1)

            reqs = Entry(self)
            reqs.insert(0,course.requirements)
            reqs.grid(column=1,row=i+1)

            creds = Entry(self)
            creds.insert(0,course.credits)
            creds.grid(column=2,row=i+1)

            self.course_data.append((name,reqs,creds))

        for i in range(len(course_list),8):
            name = Entry(self)
            name.grid(column=0,row=i+1)

            reqs = Entry(self)
            reqs.grid(column=1,row=i+1)

            creds = Entry(self)
            creds.grid(column=2,row=i+1)

            self.course_data.append((name,reqs,creds))

        StatBar(self,course_list).grid(columnspan=3,row=9)

    def updateCourses(self):
        
        return [Course(id=name.get(),credits=int(creds.get()),requirements=reqs.get().replace(',',' ').split(),semester=self.semester,year=self.year) for name, reqs, creds in self.course_data if not (name.get() == '' or creds.get() == '')]

class Form:

    def __init__(self,file_path):
        self.root = Tk()
        self.root.geometry("800x750")
        self.frame = Frame(self.root)

        self.file_path = file_path

        self.student_list = None
    
        self.home()
        self.root.mainloop()

    def load(self):

        with open(self.file_path) as file:
            students = json.load(file)["Students"]
        
        return students

    def write(self):
        students = []
        for student in self.student_list:
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

        with open(self.file_path,'w') as file:
            json.dump({"Students":students},file,indent=2)

    def save(self, student, name, id, course_tables):

        student.name = name
        student.ID = id
        courses = []
        for table in course_tables:
            courses += table.updateCourses()
        student.courses = courses

        if student.ID == 0:
            return

        add = False
        for i, s in enumerate(self.student_list):
            if student.ID == s.ID:
                self.student_list[i] = student
                add = True
        if add is False:
            self.student_list.append(student)

        self.write()
        self.profile(student=student)

    def home(self):
        
        self.updateStudentDir()
        self.frame.destroy()
        self.frame = Frame(self.root)
        Label(self.frame,text="Students\n").grid(column=0,row=0)
        for i, student in enumerate(self.student_list):
            Button(self.frame,text=student.name,command=lambda s=student: self.profile(student=s)).grid(column=0,row=(i+1))
        Button(self.frame,text="Add Student",command=lambda : self.profile(student=Student("",0,courses=[]))).grid(column=0)
        self.frame.pack()
        
    def profile(self, student):
        
        self.frame.destroy()
        self.frame = Frame(self.root)

        Label(self.frame,text="Student Name: ").grid(column=1,row=0)
        name = Entry(self.frame)
        name.insert(0,student.name)
        name.grid(column=2,row=0)

        Label(self.frame,text="Student ID: ").grid(column=1,row=1)
        id = Entry(self.frame)
        id.insert(0,student.ID)
        id.grid(column=2,row=1)

        # tree = self.generateTree(student=student)
        tree = Table(parent=self.frame,course_list=student.courses,semester='Fall',year=1)
        tree.grid(columnspan=3,row=2)
        
        Button(self.frame,text="Save",command=lambda s=student: self.save(student=s,name=name.get(),id=int(id.get()),course_tables=[tree])).grid(column=0,row=5)
        Button(self.frame,text="Delete Student",command=lambda s=student: self.deleteStudent(student=s)).grid(column=1,row=5)
        Button(self.frame,text="Home",command=self.home).grid(column=2,row=5)
        self.frame.pack()

    def deleteStudent(self, student):
        for i, s in enumerate(self.student_list):
            if s.ID == student.ID:
                del self.student_list[i]
        self.write()
        self.home()

    def updateStudentDir(self):
        students = self.load()
        self.student_list = [Student(name=data["name"],id=data["ID"],courses=data["courses"]) for data in students]