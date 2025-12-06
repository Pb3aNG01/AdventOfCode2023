import re

sum = 0
nums = "one two three four five six seven eight nine".split() #setup list of digits written out in string
pattern = "(?=(" + "|".join(nums) + "|\\d))" #used to find and return word digits in a line of strings ?= is a positive lookahead 

def funct(x): #maps string to its numerical form
    if x in nums: #checks if a string value matches a string in the nums list
        return str(nums.index(x) + 1) #if it does get a match it will change to and return its numerical form
    return x #otherwise numerical form is returned

for x in open("test1.txt"):
    digits = [*map(funct, re.findall(pattern,x))] #map calls the funct function and uses it to find all the numbers in the textfile, numerical or word form 
    sum += int(digits[0] + digits[-1]) #adds the leftmost digit string and the rightmost digit string together and turns it into an integer and then adds it to the sum

print(sum)

