total = 0

for cards in open("input.txt"):
    nums = cards.split(": ")[1]
    win, player = nums.split(" | ")
    wlist = list(map(int, win.split()))
    plist = list(map(int, player.split()))
    
    points = 0
    for n in plist:
        if n in wlist:
            points += 1
            
    if points > 0:
            total += 2**(points - 1)
        
print(total)