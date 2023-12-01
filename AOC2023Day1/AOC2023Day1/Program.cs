using System;


namespace AOCFirstDay
{
    class Trebuchet
    {
        static void Main(string[] args)
        {
            var filter = StringSplitOptions.RemoveEmptyEntries;
            var grab = new StreamReader("C:\\Users\\PhKn1\\source\\repos\\AdventOfCode2023\\AOC2023Day1\\AOC2023Day1\\CalibrationDoc.txt");
            var read = grab.ReadToEnd().Split("\n", filter);
            var nums = new string[] {"zero","one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            

            //Part 1
            // Select separates each line into its own string
            // Where condition go through each line and check if char value is a digit
            // If char is a digit it will then concatenate the first and last digit into a number and then will be added to a total sum
            Console.WriteLine(read.Select(s => s.Where(c => char.IsDigit(c))).Aggregate(0, (sum, x) => sum + (x.First() - '0') * 10 + x.Last() - '0'));

            //Part 2
            int total = 0;
            foreach ( var line in read) 
            {
                var left = line.ToString();
                var right = line.ToString();

                // checks the left side of a line for a digit, stops when it finds the leftmost digit
                for(int x = 0; x< left.Length-2; x++)
                {
                    if (!char.IsLetter(left[x])) continue;
                    foreach(var n in nums)
                    {
                        if (x + n.Length > left.Length) continue;
                        if(left.Substring(x,n.Length)== n)
                        {
                            left = left.Remove(x,n.Length).Insert(x,Array.IndexOf(nums,n).ToString());
                        }
                    }
                }

                // checks the right side of a line for a digit, stops when it finds the rightmost digit
                for(int x = right.Length-3; x >= 0; x--)
                {
                    if (!char.IsLetter(right[x])) continue;
                    foreach(var n in nums)
                    {
                        if(x + n.Length > right.Length) continue;
                        if(right.Substring(x,n.Length)== n)
                        {
                            right = right.Remove(x,n.Length).Insert(x,Array.IndexOf(nums,n).ToString());
                        }
                    }
                }

                total += (left.Where(c => char.IsDigit(c)).First() - '0') * 10 + right.Where(c => char.IsDigit(c)).Last() - '0';
            }

            Console.Write(total);
        }
    }
}