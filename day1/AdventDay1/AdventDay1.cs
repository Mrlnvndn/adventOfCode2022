using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

public class AdventDay1
{
    public static void FindElf()
    {
        string input = File.ReadAllText("input1.txt");
        string[] inputArray = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        int highest = 0;
        for (int i = 0; i < inputArray.Length; i++)
        {
            string[] items = inputArray[i].Split("\r\n");
            int total = 0;
            foreach (string item in items)
            {
                total += Convert.ToInt32(item);
            }

            if (total > highest)
            {
                highest = total;
            }
        }
        Console.WriteLine(highest.ToString());
    }
    public static string Find3Elves()
    {
        string input = File.ReadAllText("input1.txt");
        string[] inputArray = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        int[] highestTotals = new int[] { 0, 0, 0 };
        for (int i = 0; i < inputArray.Length; i++)
        {
            string[] items = inputArray[i].Split("\r\n");
            int total = 0;
            foreach (string item in items)
            {
                total += Convert.ToInt32(item);
            }
            for (int j = 0; j < 3; j++)
            {
                if (total > highestTotals[j])
                {
                    highestTotals[j] = total;
                    break;
                }
            }
            Array.Sort(highestTotals);
        }
        Console.Write((highestTotals[0] + highestTotals[1] + highestTotals[2]).ToString());
        return string.Empty;
    }

}

