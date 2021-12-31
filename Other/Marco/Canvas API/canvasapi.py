import pandas as pd
import requests
import sys

token = '19~oYg0RXgAQTv8YVsrSdUZfb0kmFVNsdu8z4CSoDLDvcsLhUoRnidKjR8SXDmDtIDu'

headers = {"Authorization": f"Bearer {token}"}

ub_url = f'https://bridgeport.instructure.com/api/v1/'

# path = '1865191.Homework.csv' # manual path entry for testing

try:
    path = sys.argv[1]
except IndexError:
    print('\nEnter canvasapi.py course_id.group_name.csv\n')
    sys.exit(0)

parts = path.split('.')

course_id = parts[0]
group_name = 'Default' if len(parts) < 3 else parts[1]

grades = pd.read_csv(path)

student, ID, SIS_Login, section, assignment = grades
points_possible = grades[assignment][0]

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
    return requests.put(url=full_path,headers=headers,params=data)

def getAssignmentGroup(course_id, group_name):
    full_path = f'{ub_url}courses/{course_id}/assignment_groups/'
    response = requests.get(url=full_path,headers=headers)
    groups = response.json()

    for group in groups:
        if group_name in group['name']:
            return group
    
    if group_name != 'Default':
        print(f'\nCreated group: {group_name}')
        return requests.post(url=full_path,headers=headers,params={'name':group_name}).json()
    return None

def main():

    assignment_id = getAssignmentID(course_id)

    if assignment_id == -1:

        data = {
        'assignment[name]': assignment,
        'assignment[points_possible]' : points_possible,
        'assignment[published]' : True
        }

        group = getAssignmentGroup(course_id, group_name)

        update_str= f'\nCreated Assignment: {assignment}'

        if group is not None:
            data['assignment[assignment_group_id]'] = group['id']
            update_str+= f' in group: {group["name"]}'
        update_str += '\n'
        
        assignment_id = createAssignment(course_id,data).json()['id']
        
        print(update_str)

    for i in range(1,len(grades)):
        # student_name = grades[student][i] # useless
        student_id = int(grades[ID][i])
        # student_sis = grades[SIS_Login][i] # useless
        # course_section = grades[section][i] # useless
        assignment_grade = grades[assignment][i]

        data = {
            'submission[posted_grade]' : assignment_grade
        }

        response = gradeAssignment(course_id, assignment_id, student_id, data)
        print(response)


if __name__ == '__main__':
    main()

