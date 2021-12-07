using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Task7
    {
        public static int Part1()
        {
            List<string> lines = System.IO.File.ReadAllLines("input7.txt").ToList();
            List<int> values = lines.Single().Split(",").Select(x => int.Parse(x)).ToList();
            List<int> fuelCosts = new List<int>();
            for (int i = 0; i <= 1859; i++)
            {
                fuelCosts.Add(0);
                foreach (int value in values)
                {
                    fuelCosts[i] += Math.Abs(value - i);
                }
            }
            return fuelCosts.Min();
        }

        public static int Part2()
        {
            List<string> lines = System.IO.File.ReadAllLines("input7.txt").ToList();
            List<int> values = lines.Single().Split(",").Select(x => int.Parse(x)).ToList();
            List<int> fuelCosts = new List<int>();
            for (int i = 0; i <= 1859; i++)
            {
                fuelCosts.Add(0);
                foreach (int value in values)
                {
                    int fuelCost = Math.Abs(value - i);
                    for (int j = 1; j <= fuelCost; j++)
                    {
                        fuelCosts[i] += j;
                    }
                }
            }
            return fuelCosts.Min();
        }
    }
}
