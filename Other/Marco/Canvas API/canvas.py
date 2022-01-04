import pandas as pd
import requests
import sys

token = '19~oYg0RXgAQTv8YVsrSdUZfb0kmFVNsdu8z4CSoDLDvcsLhUoRnidKjR8SXDmDtIDu'

headers = {"Authorization": f"Bearer {token}"}

ub_url = f'https://bridgeport.instructure.com/api/v1/'

def createAssignment(course_id, data):
    full_path = f'{ub_url}courses/{course_id}/assignments/'
    return requests.post(url=full_path,headers=headers,params=data)

def uploadFile(course_id, name, path, data):
    full_path = f'{ub_url}courses/{course_id}/files'
    
    response = requests.post(url=full_path,headers=headers,params=data)
    output = response.json()
    
    upload_url = output['upload_url']
    upload_params = output['upload_params']
    
    file = {'file': open(path,'rb')}
    
    response = requests.post(url=upload_url, params=upload_params, files=file)
    
    if response.status_code >= 300 and response.status_code <= 399: 
        location = response.json()['Location']
        response = requests.post(url=location,headers=headers)
    
    # file_id = response.json()['id']

    # params = {
    #     'name':f'{name}.pdf'
    # }
    # print(file_id)
    # print(params)

    # response = requests.put(f'{full_path}/{file_id}',headers=headers,params=params)
    # print(response.reason)

    return response

def getAssignmentID(course_id, assignment):
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

def checkAssignment(course_id, assignment, points_possible, group_name):
    assignment_id = getAssignmentID(course_id, assignment)

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
        
    return assignment_id

def gradeAssignment(path):

    parts = path.split('.')

    course_id = parts[0]
    group_name = 'Default' if len(parts) < 3 else parts[1]

    grades = pd.read_csv(path)

    student, ID, SIS_Login, section, assignment = grades
    points_possible = grades[assignment][0]

    assignment_id = checkAssignment(course_id=course_id, assignment=assignment, points_possible=points_possible, group_name=group_name)

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

    print('Grading Done')

def uploadAssignmentPDF(path):
    course_id, assignment, ext = path.split('.')
    assignment_name = assignment.replace('_',' ')
    points_possible = 3
    group_name = 'Homework'

    assignment_id = checkAssignment(course_id=course_id, assignment=assignment_name, points_possible=points_possible, group_name=group_name)

    data = {
        'name':f'{assignment}.pdf',
        # 'size':'',
        'parent_folder_path':group_name
    }

    response = uploadFile(course_id, assignment_name, path, data)
    print(f'\nUpladed file: {assignment}.pdf into folder: {group_name}\n')
    
    file_id = response.json()['id']
    full_path = f'{ub_url}courses/{course_id}/assignments/{assignment_id}'

    file_preview = f'<p><a class="instructure_file_link instructure_scribd_file auto_open" title="{assignment}.pdf" href="https://bridgeport.instructure.com/courses/{course_id}/files/{file_id}?wrap=1" target="_blank" rel="noopener" data-api-endpoint="https://bridgeport.instructure.com/api/v1/courses/{course_id}/files/{file_id}" data-api-returntype="File">{assignment}.pdf</a></p>'

    response = requests.put(url=full_path,headers=headers,params={'assignment[description]':file_preview})
    print(f'Attached file to Assignment: {assignment_name}\n')
    

def main():

    path = '1865191.Homework_5.pdf' # manual path entry for testing

    # try:
    #     path = sys.argv[1]
    # except IndexError:
    #     print('\nEnter canvasapi.py course_id.group_name.csv\n')
    #     sys.exit(0)
    
    if 'csv' in path:
        gradeAssignment(path)
    elif 'pdf' in path:
        uploadAssignmentPDF(path)
    else:
        print('\nIncorrect File Format\nEnter a .csv or .pdf file\n')
    


if __name__ == '__main__':
    main()

