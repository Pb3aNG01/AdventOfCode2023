using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace CubeConundrum
{
    class CubeConundrum
    {
        static void Main(string[] args)
        {
            var total = 0;

            IEnumerable<string> lines = File.ReadAllLines("C:\\Users\\PhKn1\\source\\repos\\AdventOfCode2023\\AOC2023Day2\\AOC2023Day2\\test.txt");

            void partone()
            {
                var maxred = 12;
                var maxgreen = 13;
                var maxblue = 14;

                foreach (var line in lines) // goes through all the lines in the text file
                {
                    var games = line.Split(':');
                    var gameid = int.Parse(games[0].Split(' ')[1]); // grabs what game number the line is on by segmenting the string line to just have the int
                    var rounds = games[1].Split(';', StringSplitOptions.TrimEntries); // contains the data with the color cubes and the amounts
                    bool possible = true;

                    foreach (var round in rounds)
                    {
                        var colors = round.Split(',', StringSplitOptions.TrimEntries); // separates the rounds to just have the color cube and its amount

                        foreach (var color in colors)
                        {
                            var colorinfo = color.Split(' ');
                            var colorcount = int.Parse(colorinfo[0]); // grabs the amount of color cubes by grabbing the string on the "left side" of the split
                            var colorname = colorinfo[1]; // grabs the color which is on the "right side"

                            switch (colorname)
                            {
                                case "red":
                                    if (colorcount > maxred) { possible = false; }
                                    break;
                                case "green":
                                    if (colorcount > maxgreen) { possible = false; }
                                    break;
                                case "blue":
                                    if (colorcount > maxblue) { possible = false; }
                                    break;
                            }

                            if (!possible) { break; }
                        }
                    }

                    if (possible) { total += gameid; }
                }
            }

            void parttwo()
            {
                foreach (var line in lines)
                {
                    var games = line.Split(':');
                    var gameid = int.Parse(games[0].Split(' ')[1]);
                    var rounds = games[1].Split(';', StringSplitOptions.TrimEntries);

                    var maxred = 0;
                    var maxgreen = 0;
                    var maxblue = 0;

                    foreach (var round in rounds)
                    {
                        var colors = round.Split(',', StringSplitOptions.TrimEntries);

                        foreach (var color in colors)
                        {
                            var colorinfo = color.Split(' ');
                            var colorcount = int.Parse(colorinfo[0]);
                            var colorname = colorinfo[1];

                            switch (colorname)
                            {
                                case "red":
                                    maxred = Math.Max(colorcount, maxred);
                                    break;
                                case "green":
                                    maxgreen = Math.Max(colorcount, maxgreen);
                                    break;
                                case "blue":
                                    maxblue = Math.Max(colorcount, maxblue);
                                    break;
                            }
                        }
                    }
                    var product = maxred * maxgreen * maxblue;
                    total += product;
                }
            }
            //partone();
            parttwo();
            Console.WriteLine(total);
        }
    }
}
