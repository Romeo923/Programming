import json
from tkinter import *
from tkmacosx import *
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

    def __init__(self,parent,course_list,borderwidth=0,relief="solid"):
        Frame.__init__(self,parent,borderwidth=borderwidth,relief=relief)

        self.reqs = ["SS","HU"]

        for i, req in enumerate(self.reqs):
            Label(self,text=f'{req} Credits').grid(column=i,row=0)
            creds = sum([course.credits for course in course_list if req in course.requirements])
            Label(self,text=f'{creds}').grid(column=i,row=1)
        Label(self,text='Total Credits').grid(column=len(self.reqs),row=0)
        creds = sum([course.credits for course in course_list])
        Label(self,text=f'{creds}').grid(column=len(self.reqs),row=1)

class Table(Frame):

    def __init__(self, parent, course_list, semester, year,borderwidth,relief):
        Frame.__init__(self,parent,borderwidth=borderwidth,relief=relief)

        self.course_list = course_list
        self.semester = semester
        self.year = year
        self.course_data = []

        Label(self,text='Course').grid(column=0,row=0)
        Label(self,text='Reqs').grid(column=1,row=0)
        Label(self,text='Credits').grid(column=2,row=0)

        for i, course in enumerate(self.course_list):
            
            name = Entry(self,width=40)
            name.insert(0,course.ID)
            name.grid(column=0,row=i+1)

            reqs = Entry(self,width=10)
            reqs.insert(0,course.requirements)
            reqs.grid(column=1,row=i+1)

            creds = Entry(self,width=6)
            creds.insert(0,course.credits)
            creds.grid(column=2,row=i+1)

            self.course_data.append((name,reqs,creds))

        for i in range(len(course_list),6):
            name = Entry(self,width=40)
            name.grid(column=0,row=i+1)

            reqs = Entry(self,width=10)
            reqs.grid(column=1,row=i+1)

            creds = Entry(self,width=6)
            creds.grid(column=2,row=i+1)

            self.course_data.append((name,reqs,creds))

        StatBar(self,course_list).grid(columnspan=3,row=9)

    def updateCourses(self):
        
        return [Course(id=name.get(),credits=int(creds.get()),requirements=reqs.get().replace(',',' ').split(),semester=self.semester,year=self.year) for name, reqs, creds in self.course_data if not (name.get() == '' or creds.get() == '')]

class Form:

    def __init__(self,file_path):
        self.root = Tk()
        self.root.geometry("1200x1200")
        self.root.title('Student Course Data')
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
        
        data_frame = Frame(self.frame,borderwidth=1,relief='solid')

        Label(data_frame,text="Student Name: ").grid(column=1,row=0)
        name = Entry(data_frame)
        name.insert(0,student.name)
        name.grid(column=2,row=0)

        Label(data_frame,text="Student ID: ").grid(column=1,row=1)
        id = Entry(data_frame)
        id.insert(0,student.ID)
        id.grid(column=2,row=1)

        course_tables, course_frame = self.generateAllCourseTables(student=student)

        button_frame = Frame(self.frame)
        
        Button(button_frame,text="Home",command=self.home).grid(column=0,row=0)
        Button(button_frame,text="Save",command=lambda s=student: self.save(student=s,name=name.get(),id=int(id.get()),course_tables=course_tables)).grid(column=1,row=0)
        Button(button_frame,text="Delete Student",command=lambda s=student: self.deleteStudent(student=s)).grid(column=2,row=0)

        data_frame.grid(columnspan=4,row=0,pady=(20,0),padx=(10,5))
        course_frame.grid(columnspan=4,row=1,pady=(20,20),padx=(10,5))
        StatBar(self.frame,student.courses,borderwidth=1,relief="solid").grid(columnspan=4,row=2,pady=(5,5),padx=(10,5))
        button_frame.grid(columnspan=4,row=3,pady=(5,5),padx=(10,5))

        self.frame.pack()

    def generateAllCourseTables(self,student):
        semesters = ["Fall","Spring"]
        years = 2
        course_tables =[]
        course_frame = Frame(self.frame)

        for sem_index,semester in enumerate(semesters):
            Label(course_frame,text=semester,font=("Ariel",15)).grid(column=sem_index,row=0)
            for year in range(1,years+1):
                table = Table(parent=course_frame,course_list=student.getCourses(semester,year),semester=semester,year=year,borderwidth=1,relief='solid')
                course_tables.append(table)
                table.grid(column=sem_index,row = year,padx=(0,25),pady=(5,5))

        return course_tables, course_frame

    def deleteStudent(self, student):
        for i, s in enumerate(self.student_list):
            if s.ID == student.ID:
                del self.student_list[i]
        self.write()
        self.home()

    def updateStudentDir(self):
        students = self.load()
        self.student_list = [Student(name=data["name"],id=data["ID"],courses=data["courses"]) for data in students]