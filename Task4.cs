using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Task4
    {
        public static int Part1()
        {
            List<string> lines = System.IO.File.ReadAllLines("input4.txt").ToList();
            List<int> numbers = lines.First().Split(",").Select(x => int.Parse(x)).ToList();
            lines.RemoveRange(0, 1);
            lines.RemoveAll(x => x == "");
            List<int> selectedNumbers = new List<int>();
            List<List<int>> splitLines = lines.Select(x => x.Split(" ").Select(y => int.Parse(y)).ToList()).ToList();
            List<int[,]> grids = new List<int[,]>();
            for (int i = 0; i < lines.Count(); i += 5)
            {
                grids.Add(new int[,] { { splitLines[i][0], splitLines[i][1], splitLines[i][2], splitLines[i][3], splitLines[i][4] },
                    { splitLines[i+1][0], splitLines[i+1][1], splitLines[i+1][2], splitLines[i+1][3], splitLines[i+1][4] },
                    { splitLines[i+2][0], splitLines[i+2][1], splitLines[i+2][2], splitLines[i+2][3], splitLines[i+2][4] },
                    { splitLines[i+3][0], splitLines[i+3][1], splitLines[i+3][2], splitLines[i+3][3], splitLines[i+3][4] },
                    { splitLines[i+4][0], splitLines[i+4][1], splitLines[i+4][2], splitLines[i+4][3], splitLines[i+4][4] } });
            }
            foreach (int number in numbers)
            {
                selectedNumbers.Add(number);
                foreach (int[,] grid in grids)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        List<int> verticalRow = new List<int>();
                        verticalRow.Add(grid[x, 0]);
                        verticalRow.Add(grid[x, 1]);
                        verticalRow.Add(grid[x, 2]);
                        verticalRow.Add(grid[x, 3]);
                        verticalRow.Add(grid[x, 4]);
                        List<int> horizontalRow = new List<int>();
                        horizontalRow.Add(grid[0, x]);
                        horizontalRow.Add(grid[1, x]);
                        horizontalRow.Add(grid[2, x]);
                        horizontalRow.Add(grid[3, x]);
                        horizontalRow.Add(grid[4, x]);
                        if (selectedNumbers.Count(x => verticalRow.Contains(x)) == 5 || selectedNumbers.Count(x => horizontalRow.Contains(x)) == 5)
                        {
                            int total = 0;
                            for (int y = 0; y < 5; y++)
                            {
                                for (int z = 0; z < 5; z++)
                                {
                                    if (!selectedNumbers.Contains(grid[y, z]))
                                    {
                                        total += grid[y, z];
                                    }
                                }
                            }
                            return total * number;
                        }
                    }
                }
            }
            return -1;
        }

        public static int Part2()
        {
            List<string> lines = System.IO.File.ReadAllLines("input4.txt").ToList();
            List<int> numbers = lines.First().Split(",").Select(x => int.Parse(x)).ToList();
            lines.RemoveRange(0, 1);
            lines.RemoveAll(x => x == "");
            List<int> selectedNumbers = new List<int>();
            List<List<int>> splitLines = lines.Select(x => x.Split(" ").Select(y => int.Parse(y)).ToList()).ToList();
            List<int[,]> grids = new List<int[,]>();
            for (int i = 0; i < lines.Count(); i += 5)
            {
                grids.Add(new int[,] { { splitLines[i][0], splitLines[i][1], splitLines[i][2], splitLines[i][3], splitLines[i][4] },
                    { splitLines[i+1][0], splitLines[i+1][1], splitLines[i+1][2], splitLines[i+1][3], splitLines[i+1][4] },
                    { splitLines[i+2][0], splitLines[i+2][1], splitLines[i+2][2], splitLines[i+2][3], splitLines[i+2][4] },
                    { splitLines[i+3][0], splitLines[i+3][1], splitLines[i+3][2], splitLines[i+3][3], splitLines[i+3][4] },
                    { splitLines[i+4][0], splitLines[i+4][1], splitLines[i+4][2], splitLines[i+4][3], splitLines[i+4][4] } });
            }
            foreach (int number in numbers)
            {
                selectedNumbers.Add(number);
                List<int> completedGrids = new List<int>();
                foreach (int[,] grid in grids)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        List<int> verticalRow = new List<int>();
                        verticalRow.Add(grid[x, 0]);
                        verticalRow.Add(grid[x, 1]);
                        verticalRow.Add(grid[x, 2]);
                        verticalRow.Add(grid[x, 3]);
                        verticalRow.Add(grid[x, 4]);
                        List<int> horizontalRow = new List<int>();
                        horizontalRow.Add(grid[0, x]);
                        horizontalRow.Add(grid[1, x]);
                        horizontalRow.Add(grid[2, x]);
                        horizontalRow.Add(grid[3, x]);
                        horizontalRow.Add(grid[4, x]);
                        if (selectedNumbers.Count(x => verticalRow.Contains(x)) == 5 || selectedNumbers.Count(x => horizontalRow.Contains(x)) == 5)
                        {
                            if (grids.Count() == 1)
                            {
                                int total = 0;
                                for (int y = 0; y < 5; y++)
                                {
                                    for (int z = 0; z < 5; z++)
                                    {
                                        if (!selectedNumbers.Contains(grid[y, z]))
                                        {
                                            total += grid[y, z];
                                        }
                                    }
                                }
                                return total * number;
                            }
                            completedGrids.Add(grids.IndexOf(grid));
                        }
                    }
                }
                completedGrids.Sort((x, y) => y.CompareTo(x));
                foreach (int completedGrid in completedGrids)
                {
                    grids.RemoveAt(completedGrid);
                }
            }
            return -1;
        }
    }
}
