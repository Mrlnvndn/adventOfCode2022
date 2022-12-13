using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class AdventDay7
    {
        public int total;
        public Directory smallestPossibleDir;
        public static void FindDir()
        {
            string input = File.ReadAllText("AdventDay7\\input7.txt");
            string[] inputArray = input.Split("\r\n");
            AdventDay7 adventDay7 = new AdventDay7();
            Directory root = adventDay7.ParseTerminalInput(inputArray);
            adventDay7.CalculateSize(root);
            Console.WriteLine("Day 7 part 1: " + adventDay7.total);
            Console.WriteLine("Day 7 part 2: " + adventDay7.smallestPossibleDir.size);
        }
        public Directory ParseTerminalInput(string[] inputArray)
        {
            Directory root = new Directory("/", null);
            Directory currentDirectory = root;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i].Contains("$ cd"))
                {
                    if (inputArray[i].Equals("$ cd .."))
                    {
                        if (currentDirectory.parent != null)
                            currentDirectory = currentDirectory.parent;
                    }
                    else if (inputArray[i].Equals("$ cd /"))
                    {
                        currentDirectory = root;
                    }
                    else
                    {
                        currentDirectory = currentDirectory.children.Where(child => child.name.Equals(inputArray[i][5..])).First();
                    }
                }
                else if (inputArray[i].Equals("$ ls"))
                {
                    while (i + 1 < inputArray.Length && inputArray[i + 1][0] != '$')
                    {
                        string[] split = inputArray[i + 1].Split(" ");
                        if (split[0].Equals("dir"))
                        {
                            currentDirectory.children.Add(new Directory(inputArray[i + 1][4..], currentDirectory));
                        }
                        else
                        {
                            currentDirectory.files.Add(new(int.Parse(split[0]), split[1]));
                        }
                        i++;
                    }
                }
            }
            return root;
        }
        public void CalculateSize(Directory directory)
        {
            foreach ((int, string) file in directory.files)
            {
                directory.size += file.Item1;
            }
            if (directory.children.Count != 0)
            {
                foreach (Directory dir in directory.children)
                {
                    CalculateSize(dir);
                    directory.size += dir.size;
                    // add files from current dir;
                    if (dir.size <= 100000)
                    {
                        total += dir.size;
                    }
                    if (dir.size >= 5717263)
                    {
                        if (smallestPossibleDir != null)
                        {
                            if (dir.size < smallestPossibleDir.size)
                            {
                                smallestPossibleDir = dir;
                            }
                        }
                        else
                        {
                            smallestPossibleDir = dir;
                        }

                    }
                }
            }
        }
    }

    public class Directory
    {
        public string name;
        public Directory? parent;
        public List<Directory> children;
        public List<(int, string)> files;
        public int size;

        public Directory(string name, Directory? parent)
        {
            this.name = name;
            this.parent = parent;
            this.children = new List<Directory>();
            this.files = new List<(int, string)>();
            this.size = 0;
        }
    }

}

