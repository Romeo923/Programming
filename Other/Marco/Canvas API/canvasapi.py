import pandas as pd
import requests

token = '19~oYg0RXgAQTv8YVsrSdUZfb0kmFVNsdu8z4CSoDLDvcsLhUoRnidKjR8SXDmDtIDu'
headers = {"Authorization": f"Bearer {token}"}

ub_url = f'https://bridgeport.instructure.com/api/v1/'

grades = pd.read_csv('Other\Marco\Canvas API\\testing.csv')

student, ID, SIS_Login, section, assignment = grades
points_possible = grades[assignment][0]

#Not Finished
def getCourseID(course_name):
    response = requests.get(url=f'{ub_url}courses/',headers=headers)
    courses = response.json()
    for course in courses:
        print(course['course_code'])
        if course['course_code'] == course_name:
            return course['id']

def createAssignment(course_id, data):
    full_path = f'{ub_url}courses/{course_id}/assignments/'
    return requests.post(url=full_path,headers=headers,params=data)

def getAssignmentID(course_id):
    full_path = f'{ub_url}courses/{course_id}/assignments/'
    response = requests.get(url=full_path,headers=headers)
    assignments = response.json()
    for a in assignments:
        if a['name'] == assignment:
            return a['id']
    return -1

def gradeAssignment(course_id, assignment_id, user_id, data):
    full_path = f'{ub_url}courses/{course_id}/assignments/{assignment_id}/submissions/{user_id}'
    requests.put(url=full_path,headers=headers,params=data)

def getAssignmentGroup(course_id, name):
    full_path = f'{ub_url}courses/{course_id}/assignment_groups/'
    response = requests.get(url=full_path,headers=headers)
    groups = response.json()

    for group in groups:
        if name in group['name']:
            print(group['name'])
            print(group['id'])
            return group
    
    return None

def main():

    #get course id
    # course_id = getCourseID(grades[section][1])
    course_id = '1865191'

    #check if assignment exists, if not, create it
    assignment_id = getAssignmentID(course_id)

    if assignment_id == -1:

        data = {
        'assignment[name]': assignment,
        'assignment[points_possible]' : points_possible,
        'assignment[published]' : True
        }

        possible_groups = ['Homework', 'Quiz']

        name = 'Has No Group'
        for g in possible_groups:
            name = g if g in assignment else name

        group = getAssignmentGroup(course_id, name)

        str= f'Created Assignment: {assignment}'

        if group is not None:
            data['assignment[assignment_group_id]'] = group['id']
            str+= f' in group: {group["name"]}'

        assignment_id = createAssignment(course_id,data).json()['id']
        
        print(str)

    print(assignment_id)


    for i in range(1,len(grades)):
        student_name = grades[student][i]
        student_id = grades[ID][i]
        student_sis = grades[SIS_Login][i]
        course_section = grades[section][i]
        assignment_grade = grades[assignment][i]

        data = {
            'submission[posted_grade]' : assignment_grade
        }

        response = gradeAssignment(course_id, assignment_id, student_id, data)
        print(response)


if __name__ == '__main__':
    main()






