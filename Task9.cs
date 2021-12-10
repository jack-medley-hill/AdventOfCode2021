using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Task9
    {
        public static int Part1()
        {
            List<string> lines = System.IO.File.ReadAllLines("input9.txt").ToList();
            List<List<int>> grid = lines.Select(x => x.ToList().Select(y => int.Parse(y.ToString())).ToList()).ToList();
            int riskLevels = 0;
            int gridSize = grid.Count() - 1;

            if (grid[0][0] < grid[0][1] &&
                grid[0][0] < grid[1][0])
            {
                riskLevels += 1 + grid[0][0];
            }

            if (grid[0][gridSize] < grid[0][gridSize - 1] &&
                grid[0][gridSize] < grid[1][gridSize])
            {
                riskLevels += 1 + grid[0][gridSize];
            }

            if (grid[gridSize][0] < grid[gridSize][1] &&
                grid[gridSize][0] < grid[gridSize - 1][0])
            {
                riskLevels += 1 + grid[gridSize][0];
            }

            if (grid[gridSize][gridSize] < grid[gridSize - 1][gridSize] &&
                grid[gridSize][gridSize] < grid[gridSize][gridSize - 1])
            {
                riskLevels += 1 + grid[gridSize][gridSize];
            }

            for (int i = 1; i < gridSize; i++)
            {
                if (grid[i][0] < grid[i - 1][0] &&
                    grid[i][0] < grid[i + 1][0] &&
                    grid[i][0] < grid[i][1])
                {
                    riskLevels += 1 + grid[i][0];
                }

                if (grid[0][i] < grid[0][i - 1] &&
                    grid[0][i] < grid[0][i + 1] &&
                    grid[0][i] < grid[1][i])
                {
                    riskLevels += 1 + grid[0][i];
                }

                for (int j = 1; j < gridSize; j++)
                {
                    if (grid[i][j] < grid[i + 1][j] &&
                        grid[i][j] < grid[i - 1][j] &&
                        grid[i][j] < grid[i][j + 1] &&
                        grid[i][j] < grid[i][j - 1])
                    {
                        riskLevels += 1 + grid[i][j];
                    }
                }

                if (grid[gridSize][i] < grid[gridSize][i - 1] &&
                    grid[gridSize][i] < grid[gridSize][i + 1] &&
                    grid[gridSize][i] < grid[gridSize - 1][i])
                {
                    riskLevels += 1 + grid[gridSize][i];
                }

                if (grid[i][gridSize] < grid[i - 1][gridSize] &&
                    grid[i][gridSize] < grid[i + 1][gridSize] &&
                    grid[i][gridSize] < grid[i][gridSize - 1])
                {
                    riskLevels += 1 + grid[i][gridSize];
                }
            }

            return riskLevels;
        }

        public static int Part2()
        {
            List<string> lines = System.IO.File.ReadAllLines("input9.txt").ToList();
            List<List<int>> grid = lines.Select(x => x.ToList().Select(y => int.Parse(y.ToString())).ToList()).ToList();
            int gridSize = grid.Count() - 1;
            Dictionary<KeyValuePair<int, int>, int> basins = new Dictionary<KeyValuePair<int, int>, int>();

            if (grid[0][0] < grid[0][1] &&
                grid[0][0] < grid[1][0])
            {
                basins.Add(new KeyValuePair<int, int>(0, 0), 0);
            }

            if (grid[0][gridSize] < grid[0][gridSize - 1] &&
                grid[0][gridSize] < grid[1][gridSize])
            {
                basins.Add(new KeyValuePair<int, int>(0, gridSize), 0);
            }

            if (grid[gridSize][0] < grid[gridSize][1] &&
                grid[gridSize][0] < grid[gridSize - 1][0])
            {
                basins.Add(new KeyValuePair<int, int>(gridSize, 0), 0);
            }

            if (grid[gridSize][gridSize] < grid[gridSize - 1][gridSize] &&
                grid[gridSize][gridSize] < grid[gridSize][gridSize - 1])
            {
                basins.Add(new KeyValuePair<int, int>(gridSize, gridSize), 0);
            }

            for (int i = 1; i < gridSize; i++)
            {
                if (grid[i][0] < grid[i - 1][0] &&
                    grid[i][0] < grid[i + 1][0] &&
                    grid[i][0] < grid[i][1])
                {
                    basins.Add(new KeyValuePair<int, int>(i, 0), 0);
                }

                if (grid[0][i] < grid[0][i - 1] &&
                    grid[0][i] < grid[0][i + 1] &&
                    grid[0][i] < grid[1][i])
                {
                    basins.Add(new KeyValuePair<int, int>(0, i), 0);
                }

                for (int j = 1; j < gridSize; j++)
                {
                    if (grid[i][j] < grid[i + 1][j] &&
                        grid[i][j] < grid[i - 1][j] &&
                        grid[i][j] < grid[i][j + 1] &&
                        grid[i][j] < grid[i][j - 1])
                    {
                        basins.Add(new KeyValuePair<int, int>(i, j), 0);
                    }
                }

                if (grid[gridSize][i] < grid[gridSize][i - 1] &&
                    grid[gridSize][i] < grid[gridSize][i + 1] &&
                    grid[gridSize][i] < grid[gridSize - 1][i])
                {
                    basins.Add(new KeyValuePair<int, int>(gridSize, i), 0);
                }

                if (grid[i][gridSize] < grid[i - 1][gridSize] &&
                    grid[i][gridSize] < grid[i + 1][gridSize] &&
                    grid[i][gridSize] < grid[i][gridSize - 1])
                {
                    basins.Add(new KeyValuePair<int, int>(i, gridSize), 0);
                }
            }

            List<KeyValuePair<int, int>> basinsKeys = basins.Keys.ToList();

            foreach (KeyValuePair<int, int> coords in basinsKeys)
            {
                List<KeyValuePair<int, int>> currentBasin = new List<KeyValuePair<int, int>>
                {
                    coords
                };
                List<KeyValuePair<int, int>> currentPass = new List<KeyValuePair<int, int>>
                {
                    coords
                }; 
                basins[coords]++;

                while (currentPass.Count() != 0)
                {
                    List<KeyValuePair<int, int>> nextPass = new List<KeyValuePair<int, int>>();

                    foreach (KeyValuePair<int, int> coord in currentPass)
                    {
                        if (coord.Key != 0 && grid[coord.Key - 1][coord.Value] != 9 &&
                            grid[coord.Key - 1][coord.Value] >= grid[coord.Key][coord.Value])
                        {
                            if (!currentBasin.Contains(new KeyValuePair<int, int>(coord.Key - 1, coord.Value)))
                            {
                                currentBasin.Add(new KeyValuePair<int, int>(coord.Key - 1, coord.Value));
                                nextPass.Add(new KeyValuePair<int, int>(coord.Key - 1, coord.Value));
                                basins[coords]++;
                            }
                        }

                        if (coord.Key != 99 && grid[coord.Key + 1][coord.Value] != 9 &&
                            grid[coord.Key + 1][coord.Value] >= grid[coord.Key][coord.Value])
                        {
                            if (!currentBasin.Contains(new KeyValuePair<int, int>(coord.Key + 1, coord.Value)))
                            {

                                currentBasin.Add(new KeyValuePair<int, int>(coord.Key + 1, coord.Value));
                                nextPass.Add(new KeyValuePair<int, int>(coord.Key + 1, coord.Value));
                                basins[coords]++;
                            }
                        }

                        if (coord.Value != 0 && grid[coord.Key][coord.Value - 1] != 9 &&
                            grid[coord.Key][coord.Value - 1] >= grid[coord.Key][coord.Value])
                        {
                            if (!currentBasin.Contains(new KeyValuePair<int, int>(coord.Key, coord.Value - 1)))
                            {

                                currentBasin.Add(new KeyValuePair<int, int>(coord.Key, coord.Value - 1));
                                nextPass.Add(new KeyValuePair<int, int>(coord.Key, coord.Value - 1));
                                basins[coords]++;
                            }
                        }

                        if (coord.Value != 99 && grid[coord.Key][coord.Value + 1] != 9 &&
                            grid[coord.Key][coord.Value + 1] >= grid[coord.Key][coord.Value])
                        {
                            if (!currentBasin.Contains(new KeyValuePair<int, int>(coord.Key, coord.Value + 1)))
                            {
                                currentBasin.Add(new KeyValuePair<int, int>(coord.Key, coord.Value + 1));
                                nextPass.Add(new KeyValuePair<int, int>(coord.Key, coord.Value + 1));
                                basins[coords]++;
                            }
                        }
                    }

                    currentPass = nextPass;
                }
            }

            return basins.OrderByDescending(x => x.Value).Take(3).Aggregate(1, (acc, value) => acc * value.Value);
        }
    }
}
