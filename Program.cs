using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Result3Part2());
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

        static double Result3Part1()
        {
            double gamma = 0;
            double epsilon = 0;
            List<string> lines = System.IO.File.ReadAllLines("input3.txt").ToList();
            int length = lines.Count();
            for (int i = 0; i < lines[0].Length; i++)
            {
                int bit = lines.Select(x => int.Parse(x[i].ToString())).Sum();
                gamma += bit > length / 2 ? Math.Pow(2, lines[0].Length - 1 - i) : 0;
                epsilon += bit < length / 2 ? Math.Pow(2, lines[0].Length - 1 - i) : 0;
            }
            return gamma * epsilon;
        }

        static double Result3Part2()
        {
            double generator = 0;
            double scrubber = 0;
            List<string> generatorLines = System.IO.File.ReadAllLines("input3.txt").ToList();
            List<string> scrubberLines = System.IO.File.ReadAllLines("input3.txt").ToList();
            int length = generatorLines[0].Length;
            for (int i = 0; i < length; i++)
            {

                int generatorBit = generatorLines.Select(x => int.Parse(x[i].ToString())).Sum();
                int generatorMostCommon = generatorBit >= generatorLines.Count() / (double)2 ? 1 : 0;
                generatorLines = generatorLines.Where(x => x[i].ToString() == generatorMostCommon.ToString()).ToList();
                if (generatorLines.Count == 1)
                {
                    generator = Convert.ToInt32(generatorLines.Single(), 2);
                }

                int scrubberBit = scrubberLines.Select(x => int.Parse(x[i].ToString())).Sum();
                int scrubberMostCommon = scrubberBit >= scrubberLines.Count() / (double)2 ? 0 : 1;
                scrubberLines = scrubberLines.Where(x => x[i].ToString() == scrubberMostCommon.ToString()).ToList();
                if (scrubberLines.Count == 1)
                {
                    scrubber = Convert.ToInt32(scrubberLines.Single(), 2);
                }
            }
            return generator * scrubber;
        }
    }
}
