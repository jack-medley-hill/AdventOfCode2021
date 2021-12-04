using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Task1
    {
        public static int Part1()
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

        public static int Part2()
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
    }
}
