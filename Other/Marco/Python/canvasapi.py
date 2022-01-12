import pandas as pd
import requests

token = '19~oYg0RXgAQTv8YVsrSdUZfb0kmFVNsdu8z4CSoDLDvcsLhUoRnidKjR8SXDmDtIDu'

# grades = pd.read_csv('Other\Marco\Python\grades.csv')

# student, ID, SIS_Login, section, name = grades
# points_possible = grades[name][0]

# for i in range(1,len(grades)):
#     student_name = grades[student][i]
#     student_id = grades[ID][i]
#     student_sis = grades[SIS_Login][i]
#     course_section = grades[section][i]
#     assignment_name = grades[name][i]


course_id = '1865191'
# assignment_id = ''
# user_id = ''
url = f'https://bridgeport.instructure.com/api/v1/courses/{course_id}/assignments/'

# data = {}
headers = {"Authorization": f"Bearer {token}"}

result = requests.get(url=url,headers=headers)
# result = requests.post(url=url,headers=headers,)
print(result.json())

# result = requests.post(url=url,headers=headers,data=data)

def createAssignment():
    