from Utils import *

def main():
    
    path = 'student_data.json'
    students = load(path)
    slist = [Student(name=data["name"],id=data["ID"],courses=data["courses"]) for data in students]

    createFrame(slist,file_path=path)


if __name__ == '__main__':
    main()
