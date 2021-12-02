using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Result2Part2());
        }

        static int Result1Part1()
        {
            int count = 0;
            List<int> lines = System.IO.File.ReadAllLines("input.txt").Select(x => int.Parse(x)).ToList();
            for (int i = 1; i < lines.Count; i++)
            {
                if (lines[i - 1] < lines[i])
                {
                    count++;
                }
            }
            return count;
        }

        static int Result1Part2()
        {
            int count = 0;
            List<int> lines = System.IO.File.ReadAllLines("input.txt").Select(x => int.Parse(x)).ToList();
            for (int i = 1; i < lines.Count - 2; i++)
            {
                if (lines[i - 1] < lines[i + 2])
                {
                    count++;
                }
            }
            return count;
        }

        static int Result2Part1()
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

        static int Result2Part2()
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
