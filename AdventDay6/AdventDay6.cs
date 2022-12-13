using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class AdventDay6
    {
        public static void FindFirstMarkerPosition()
        {
            string input = File.ReadAllText("AdventDay6\\input6.txt");

            bool found = false;
            int i = 3;
            while (!found)
            {
                //4 niet gelijk met alle
                if (!input[i - 3].Equals(input[i]) && !input[i - 2].Equals(input[i]) && !input[i - 1].Equals(input[i]))
                {
                    //3
                    if (!input[i - 3].Equals(input[i - 1]) && !input[i - 2].Equals(input[i - 1]))
                    {
                        //2
                        if (!input[i - 3].Equals(input[i - 2]))
                        {
                            Console.WriteLine("Day 6 part 1: " + (i + 1));
                            found = true;
                        }
                    }
                }
                i++;
            }
        }

        public static void FindLastMarkerPosition()
        {
            string input = File.ReadAllText("AdventDay6\\input6.txt");

            bool found = false;
            int i = 0;
            while (!found)
            {
                //4 niet gelijk met alle
                for (int j = i; j < i + 12; j++)
                {
                    for (int k = j + 1; k < i + 13; k++)
                    {
                        if (!input[j].Equals(input[k]))
                        {
                            if (j >= i + 11 && k == j + 1)
                            {
                                Console.WriteLine("Day 6 part 2: " + (i + 14));
                                found = true;
                                break;
                            }
                        }
                        else
                        {
                            //move indices to right value
                            i += j - i + 1;
                            j = i;
                            k = j;
                        }
                    }
                }
                i++;
            }
        }
    }
}
