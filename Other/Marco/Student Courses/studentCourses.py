import json
from Utils.Student import *

path = 'Other\\Marco\\Student Courses\\Utils\\student_data.json'

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
                "ID":course.id,
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

students = load(path)

slist = [Student(name=data["name"],id=data["ID"],courses=data["courses"]) for data in students]

s1 = Student("Marco",10000,[{
        "name":"Test",
        "ID":"Test-500",
        "semester":"Spring",
        "credits":3,
        "registered":True        
    }])

# slist.append(s1)



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