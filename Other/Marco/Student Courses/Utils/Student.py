class Course:

    def __init__(self,name,id,credits,semester,registered):
        self.name = name
        self.id = id
        self.credits = credits
        self.semester = semester
        self.registered = registered

    def __str__(self):
        return f"""
        Course Name:   {self.name}
        Course Number: {self.id}
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