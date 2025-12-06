with open("input.txt") as file:
    lines = file.read().strip().split("\n")
    
a = len(lines)
dupes = [[] for _ in range(a)]

for x, line in enumerate(lines):
    nums = line.split(": ")[1]
    win, player = nums.split(" | ")
    wlist = list(map(int, win.split()))
    plist = list(map(int, player.split()))
    
    points = 0
    for n in plist:
        if n in wlist:
            points += 1
    
    for y in range(x+1,x+points+1): #for loop and adds the next line of cards depending on how many winning numbers
        dupes[x].append(y) #adds the extra cards into a separate list
        
points = [1 for _ in range(a)]

for x in range(a-1, -1, -1): #goes through the dupes list backwards and computes the score
    for y in dupes[x]:
        points[x] += points[y]
        
print(sum(points))