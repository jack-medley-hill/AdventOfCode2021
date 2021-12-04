using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Task2
    {
        public static int Part1()
        {
            int x = 0;
            int y = 0;
            List<string> lines = System.IO.File.ReadAllLines("input2.txt").ToList();
            foreach (string line in lines)
            {
                List<string> direction = line.Split(" ").ToList();
                switch (direction[0])
                {
                    case "forward":
                        x += int.Parse(direction[1]);
                        break;
                    case "up":
                        y -= int.Parse(direction[1]);
                        break;
                    case "down":
                        y += int.Parse(direction[1]);
                        break;
                }
            }
            return x * y;
        }

        public static int Part2()
        {
            int x = 0;
            int y = 0;
            int aim = 0;
            List<string> lines = System.IO.File.ReadAllLines("input2.txt").ToList();
            foreach (string line in lines)
            {
                List<string> direction = line.Split(" ").ToList();
                switch (direction[0])
                {
                    case "forward":
                        x += int.Parse(direction[1]);
                        y += aim * int.Parse(direction[1]);
                        break;
                    case "up":
                        aim -= int.Parse(direction[1]);
                        break;
                    case "down":
                        aim += int.Parse(direction[1]);
                        break;
                }
            }
            return x * y;
        }
    }
}
