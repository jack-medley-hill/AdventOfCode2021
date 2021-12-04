using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Task3
    {
        public static double Part1()
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

        public static double Part2()
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
