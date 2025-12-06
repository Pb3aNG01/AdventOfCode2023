with open("input.txt") as file:
    lines = file.read().strip().split("\n")
    
total = 0

row = len(lines[0])
column = len(lines)

adj = [[[] for _ in range(row)] for _ in range(column)] #holds the numbers that are adjacent to the * gear

def isgear(r,c, n): 
    if not (0<=r<row and 0<=c<column):
        return False
    if lines[r][c] == "*": #if the current string in the list is *, then the number n is added into the adj list
        adj[r][c].append(n)

    return lines[r][c] != "." and not lines[r][c].isdigit()

for r, line in enumerate(lines):
    start = 0
    c = 0
    
    while c < column:
        start = c
        num = ""

        while c < column and line[c].isdigit():
            num += line[c]
            c+=1
            
        if num == "":
            c+=1
            continue
            
        num = int(num)
        
        #checks around the gear for adjacent numbers
        isgear(r, start-1, num) or isgear(r, c, num) #checks to the left and right of the current position
        for a in range(start-1, c+1): #checks to the top and bottom of the current position
            isgear(r-1,a,num) or isgear(r+1,a,num)
            
for r in range(row):
    for c in range(column):
        nums = adj[r][c]
        if lines[r][c] == "*" and len(nums) == 2: #checks if the current position is a * and has exactly two numbers adjacent to it
            total += nums[0] * nums[1]
            
print(total)
