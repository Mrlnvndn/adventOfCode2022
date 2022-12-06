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
                        totalPriority += item;
                    }
                }

            }


        }
        private static string RemoveDuplicates(string input)
        {
            for (int j = 0; j < input.Length - 1; j++)
            {
                for (int k = 0; k < input.Length - 1; k++)
                {
                    if (j != k)
                    {
                        if (input[j] == input[k])
                        {
                            input = input.Remove(k, 1);
                        }
                    }
                }
            }

            return input;
        }
    }
}