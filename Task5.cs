using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Task5
    {
        public static int Part1()
        {
            List<string> lines = System.IO.File.ReadAllLines("input5.txt").ToList();
            List<List<int>> grid = new List<List<int>>();
            for (int i = 0; i < 1000; i++)
            {
                grid.Add(new List<int>());
                for (int j = 0; j < 1000; j++)
                {
                    grid[i].Add(0);
                }
            }
            foreach (string line in lines)
            {
                List<string> coords = line.Split(" ").ToList();
                coords.RemoveAt(1);
                List<string> coord1 = coords[0].Split(",").ToList();
                List<string> coord2 = coords[1].Split(",").ToList();
                Tuple<int, int> coord3 = new Tuple<int, int>(int.Parse(coord1[0]), int.Parse(coord1[1]));
                Tuple<int, int> coord4 = new Tuple<int, int>(int.Parse(coord2[0]), int.Parse(coord2[1]));
                if (coord3.Item1 == coord4.Item1)
                {
                    if (coord3.Item2 > coord4.Item2)
                    {
                        for (int i = coord4.Item2; i <= coord3.Item2; i++)
                        {
                            grid[coord3.Item1][i]++;
                        }
                    } else
                    {
                        for (int i = coord3.Item2; i <= coord4.Item2; i++)
                        {
                            grid[coord3.Item1][i]++;
                        }
                    }
                } else if (coord3.Item2 == coord4.Item2)
                {
                    if (coord3.Item1 > coord4.Item1)
                    {
                        for (int i = coord4.Item1; i <= coord3.Item1; i++)
                        {
                            grid[i][coord3.Item2]++;
                        }
                    } else
                    {
                        for (int i = coord3.Item1; i <= coord4.Item1; i++)
                        {
                            grid[i][coord3.Item2]++;
                        }
                    }
                }
            }
            int count = 0;
            foreach (List<int> list in grid)
            {
                foreach (int value in list)
                {
                    if (value >= 2)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int Part2()
        {
            List<string> lines = System.IO.File.ReadAllLines("input5.txt").ToList();
            List<List<int>> grid = new List<List<int>>();
            for (int i = 0; i < 1000; i++)
            {
                grid.Add(new List<int>());
                for (int j = 0; j < 1000; j++)
                {
                    grid[i].Add(0);
                }
            }
            foreach (string line in lines)
            {
                List<string> coords = line.Split(" ").ToList();
                coords.RemoveAt(1);
                List<string> coord1 = coords[0].Split(",").ToList();
                List<string> coord2 = coords[1].Split(",").ToList();
                Tuple<int, int> coord3 = new Tuple<int, int>(int.Parse(coord1[0]), int.Parse(coord1[1]));
                Tuple<int, int> coord4 = new Tuple<int, int>(int.Parse(coord2[0]), int.Parse(coord2[1]));
                if (coord3.Item1 == coord4.Item1)
                {
                    if (coord3.Item2 > coord4.Item2)
                    {
                        for (int i = coord4.Item2; i <= coord3.Item2; i++)
                        {
                            grid[coord3.Item1][i]++;
                        }
                    }
                    else
                    {
                        for (int i = coord3.Item2; i <= coord4.Item2; i++)
                        {
                            grid[coord3.Item1][i]++;
                        }
                    }
                }
                else if (coord3.Item2 == coord4.Item2)
                {
                    if (coord3.Item1 > coord4.Item1)
                    {
                        for (int i = coord4.Item1; i <= coord3.Item1; i++)
                        {
                            grid[i][coord3.Item2]++;
                        }
                    }
                    else
                    {
                        for (int i = coord3.Item1; i <= coord4.Item1; i++)
                        {
                            grid[i][coord3.Item2]++;
                        }
                    }
                }
                else if (Math.Abs(coord3.Item1 - coord4.Item1) == Math.Abs(coord3.Item2 - coord4.Item2))
                {
                    int distance = Math.Abs(coord3.Item1 - coord4.Item1);
                    for (int i = 0; i <= distance; i++)
                    {
                        if (coord3.Item1 < coord4.Item1 && coord3.Item2 < coord4.Item2)
                        {
                            grid[coord3.Item1 + i][coord3.Item2 + i]++;
                        }
                        else if (coord3.Item1 < coord4.Item1 && coord3.Item2 > coord4.Item2)
                        {
                            grid[coord3.Item1 + i][coord3.Item2 - i]++;
                        }
                        else if (coord3.Item1 > coord4.Item1 && coord3.Item2 < coord4.Item2)
                        {
                            grid[coord3.Item1 - i][coord3.Item2 + i]++;
                        }
                        else if (coord3.Item1 > coord4.Item1 && coord3.Item2 > coord4.Item2)
                        {
                            grid[coord3.Item1 - i][coord3.Item2 - i]++;
                        }
                    }
                }
            }
            int count = 0;
            foreach (List<int> list in grid)
            {
                foreach (int value in list)
                {
                    if (value >= 2)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
