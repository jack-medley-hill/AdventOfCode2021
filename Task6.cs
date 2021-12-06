using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Task6
    {
        public static int Part1()
        {
            List<string> lines = System.IO.File.ReadAllLines("input6.txt").ToList();
            List<int> fishTimers = lines.Single().Split(",").Select(x => int.Parse(x)).ToList();
            for (int i = 0; i < 80; i++)
            {
                List<int> newFishTimers = new List<int>();
                newFishTimers.AddRange(fishTimers);
                for (int j = 0; j < fishTimers.Count(); j++)
                {
                    if (fishTimers[j] == 0)
                    {
                        newFishTimers[j] = 6;
                        newFishTimers.Add(8);
                    } else
                    {
                        newFishTimers[j]--;
                    }
                }
                fishTimers = newFishTimers;
            }
            return fishTimers.Count();
        }

        public static double Part2()
        {
            List<string> lines = System.IO.File.ReadAllLines("input6.txt").ToList();
            List<int> fishTimers = lines.Single().Split(",").Select(x => int.Parse(x)).ToList();
            //for (int i = 0; i < 6; i++)
            //{
            //    List<int> newFishTimers = new List<int>();
            //    newFishTimers.AddRange(fishTimers);
            //    for (int j = 0; j < fishTimers.Count(); j++)
            //    {
            //        if (fishTimers[j] == 0)
            //        {
            //            newFishTimers[j] = 6;
            //            newFishTimers.Add(8);
            //        }
            //        else
            //        {
            //            newFishTimers[j]--;
            //        }
            //    }
            //    fishTimers = newFishTimers;
            //}
            List<double> dayCounts = new List<double>();
            for (int i = 0; i <= 8; i++)
            {
                dayCounts.Add(fishTimers.Count(x => x == i));
            }
            for (int i = 0; i < 256; i++)
            {
                double newHatches = dayCounts[0];
                for (int j = 0; j <= 7; j++)
                {
                    dayCounts[j] = dayCounts[j + 1];
                }
                dayCounts[6] += newHatches;
                dayCounts[8] = newHatches;
            }

            return dayCounts.Sum();
        }
    }
}
