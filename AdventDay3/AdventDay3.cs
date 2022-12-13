using System;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    public class AdventDay3
    {
        public static void TotalPriority()
        {
            string input = File.ReadAllText("AdventDay3\\input3.txt");
            string[] itemsPerElf = input.Split("\r\n");

            int totalPriority = 0;

            for (int i = 0; i < itemsPerElf.Length; i++)
            {
                string first = itemsPerElf[i].Substring(0, itemsPerElf[i].Length / 2);
                string second = itemsPerElf[i].Substring(itemsPerElf[i].Length / 2);

                first = RemoveDuplicates(first);
                second = RemoveDuplicates(second);

                foreach (char item in first)
                {
                    if (second.Contains(item))
                    {
                        totalPriority += CalculateValue(item);
                    }
                }
            }
            Console.WriteLine("Day 3 part 1: " + totalPriority);
        }

        public static void BadgePriority()
        {
            string input = File.ReadAllText("AdventDay3\\input3.txt");
            string[] itemsPerElf = input.Split("\r\n");
            string[][] elfGroups = new string[itemsPerElf.Length / 3][];

            int totalBadgePriority = 0;

            int j = 0;
            for (int i = 0; i < itemsPerElf.Length; i += 3, j++)
            {
                elfGroups[j] = new string[]
                {
                    RemoveDuplicates(itemsPerElf[i]),
                    RemoveDuplicates(itemsPerElf[i + 1]),
                    RemoveDuplicates(itemsPerElf[i + 2])
                };

                foreach (char item0 in elfGroups[j][0])
                {
                    foreach (char item1 in elfGroups[j][1])
                    {
                        if (item0.Equals(item1))
                        {
                            foreach (char item2 in elfGroups[j][2])
                            {
                                if (item0.Equals(item2))
                                {
                                    totalBadgePriority += CalculateValue(item2);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Day 3 part 2: " + totalBadgePriority);
        }
        public static string RemoveDuplicates(string input)
        {
            for (int j = 0; j < input.Length; j++)
            {
                for (int k = 0; k < input.Length; k++)
                {
                    if (j != k)
                    {
                        if (input[j].Equals(input[k]))
                        {
                            input = input.Remove(k, 1);
                            k--;
                        }
                    }
                }
            }

            return input;
        }

        private static int CalculateValue(char input)
        {
            if (Char.IsLower(input))
                return input - 96;
            else
                return input - 38;
        }
    }
}