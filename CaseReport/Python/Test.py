import sys

script, searchFor, poolOne, poolTwo, poolThree = sys.argv

searchcomplete = ""

if searchFor in poolOne:
    print(searchFor + " is in step one.")
else:
    sprint(searchFor + " is not in step one.")

if searchFor in poolTwo:
    print(searchFor + " is in step two.")
else:
    print(searchFor + " is not in step two.")

if searchFor in poolThree:
    print(searchFor + " is in step three.")
else:
    print(searchFor + " is not in step three.")
