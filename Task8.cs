using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Task8
    {
        public static int Part1()
        {
            List<string> lines = System.IO.File.ReadAllLines("input8.txt").ToList();
            List<List<string>> outputValues = lines.Select(x => x.Split("|")[1]).Select(y => y.Split(" ").ToList().GetRange(1, 4)).ToList();
            int count = 0;
            foreach (List<string> outputValue in outputValues)
            {
                List<int> uniqueValues = new List<int> { 2, 3, 4, 7 };
                count += outputValue.Count(x => uniqueValues.Contains(x.Length));
            }
            return count;
        }

        public static int Part2()
        {
            List<string> lines = System.IO.File.ReadAllLines("input8.txt").ToList();
            List<int> results = new List<int>();
            foreach (string line in lines)
            {
                string[] splitLine = line.Split("|");
                List<string> signalPattern = splitLine[0].Split(" ").ToList().GetRange(0, 10);
                List<string> outputValues = splitLine[1].Split(" ").ToList().GetRange(1, 4);
                List<char> oneSignalPattern = signalPattern.Find(x => x.Length == 2).ToList();
                List<char> fourSignalPattern = signalPattern.Find(x => x.Length == 4).ToList();
                List<char> sevenSignalPattern = signalPattern.Find(x => x.Length == 3).ToList();
                List<char> eightSignalPattern = signalPattern.Find(x => x.Length == 7).ToList();
                List<char> threeSignalPattern = signalPattern.Find(x => x.Length == 5 && sevenSignalPattern.All(y => x.Contains(y))).ToList();
                List<char> nineSignalPattern = signalPattern.Find(x => x.Length == 6 && fourSignalPattern.All(y => x.Contains(y))).ToList();
                List<char> fiveSignalPattern = signalPattern.Find(x => x.Length == 5 && !threeSignalPattern.All(y => x.Contains(y)) && x.All(z => nineSignalPattern.Contains(z))).ToList();
                List<char> sixSignalPattern = signalPattern.Find(x => x.Length == 6 && !nineSignalPattern.All(y => x.Contains(y)) && fiveSignalPattern.All(z => x.Contains(z))).ToList();
                List<char> twoSignalPattern = signalPattern.Find(x => x.Length == 5 && !threeSignalPattern.All(y => x.Contains(y)) && !fiveSignalPattern.All(z => x.Contains(z))).ToList();
                List<char> zeroSignalPattern = signalPattern.Find(x => x.Length == 6 && !nineSignalPattern.All(y => x.Contains(y)) && !sixSignalPattern.All(z => x.Contains(z))).ToList();
                List<string> decodedOutputValues = new List<string>();
                foreach (string outputValue in outputValues)
                {
                    if (outputValue.Length == 2) {
                        decodedOutputValues.Add("1");
                    } else if (outputValue.Length == 4)
                    {
                        decodedOutputValues.Add("4");
                    } else if (outputValue.Length == 3)
                    {
                        decodedOutputValues.Add("7");
                    } else if (outputValue.Length == 7)
                    {
                        decodedOutputValues.Add("8");
                    } else if (outputValue.Length == 5)
                    {
                        if (outputValue.All(x => threeSignalPattern.Contains(x)))
                        {
                            decodedOutputValues.Add("3");
                        } else if (outputValue.All(x => fiveSignalPattern.Contains(x)))
                        {
                            decodedOutputValues.Add("5");
                        } else if (outputValue.All(x => twoSignalPattern.Contains(x)))
                        {
                            decodedOutputValues.Add("2");
                        }
                    } else if (outputValue.Length == 6)
                    {
                        if (outputValue.All(x => nineSignalPattern.Contains(x)))
                        {
                            decodedOutputValues.Add("9");
                        }
                        else if (outputValue.All(x => sixSignalPattern.Contains(x)))
                        {
                            decodedOutputValues.Add("6");
                        }
                        else if (outputValue.All(x => zeroSignalPattern.Contains(x)))
                        {
                            decodedOutputValues.Add("0");
                        }
                    }
                }
                results.Add(int.Parse(string.Join("", decodedOutputValues)));
            }
            return results.Sum();
        }  
    }
}
