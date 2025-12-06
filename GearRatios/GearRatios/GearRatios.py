with open("input.txt") as file:
    lines = file.read().strip().split("\n")

total = 0    

row = len(lines[0])
column = len(lines)

def issymbol(r, c):
    if not (0<=r<row and 0<=c<column):
        return False
    
    return lines[r][c] != "." and not lines[r][c].isdigit()

for r, line in enumerate(lines): #goes through text file as a multidimensional list by rows
    start = 0
    c = 0
    
    while c < column: #goes through text file by columns
        start = c
        num = ""
        
        while c < column and line[c].isdigit(): #checks for numbers
            num += line[c]
            c+=1
            
        if num == "":
            c+=1
            continue
            
        num = int(num)

        #if no more numbers, then check for any adjacent symbols
        if issymbol(r,start-1) or issymbol(r,c): #checks to the left and right of the number for any adjacent symbols
            total += num 
            continue
        
        for a in range(start-1, c+1): #checks to the top and bottom of the number to find adjacent symbols
            if issymbol(r-1,a) or issymbol(r+1,a):
                total += num 
                break
            
print(total)