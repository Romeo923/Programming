import json

class Course:

    def __init__(self,name,id,credits,semester,registered):
        self.name = name
        self.ID = id
        self.credits = credits
        self.semester = semester
        self.registered = registered

    def __str__(self):
        return f"""
        Course Name:   {self.name}
        Course Number: {self.ID}
        Credits:       {self.credits}
        Semester:      {self.semester}
        Registered:    {self.registered}
        """

class Student:

    def __init__(self,name,id,courses):
        self.name = name
        self.ID = id
        self.courses = [Course(name=data["name"],id=data["ID"],credits=data["credits"],semester=data["semester"],registered=data["registered"]) for data in courses]

    def adddCourse(self,course):
        self.courses.append(course)

    def fallCourses(self):
        return (course for course in self.courses if course.semester == 'Fall')
    
    def springCourses(self):
        return (course for course in self.courses if course.semester == 'Spring')

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

def save(student_list, file_path):
    students = []
    for student in student_list:
        courses = []
        for course in student.courses:
            courses.append({
                "name":course.name,
                "ID":course.ID,
                "semester":course.semester,
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