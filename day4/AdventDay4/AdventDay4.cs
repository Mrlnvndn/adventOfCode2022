using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AdventDay4
{
    public static void ContainingPairs()
    {
        string input = File.ReadAllText("input4.txt");
        string[] pairs = input.Split("\r\n");
        int fullyIncluded = 0;

        foreach (var pair in pairs)
        {
            int[] splitPair = pair.Split(new char[] { ',', '-' }).Select(int.Parse).ToArray();
            if (splitPair[0] == splitPair[2])
            {
                fullyIncluded++;
            }
            else if (splitPair[0] < splitPair[2])
            {
                if (splitPair[1] >= splitPair[3])
                {
                    fullyIncluded++;
                }
            }
            else
            {
                if (splitPair[1] <= splitPair[3])
                {
                    fullyIncluded++;
                }
            }
        }
        Console.WriteLine(fullyIncluded);
    }
    public static void OverlappingPairs()
    {
        string input = File.ReadAllText("input4.txt");
        string[] pairs = input.Split("\r\n");
        int overlapping = 0;

        foreach (var pair in pairs)
        {
            int[] splitPair = pair.Split(new char[] { ',', '-' }).Select(int.Parse).ToArray();
            if (!(splitPair[0] > splitPair[3] || splitPair[1] < splitPair[2]))
            {
                overlapping++;
            }

        }
        Console.WriteLine(overlapping);
    }
}

