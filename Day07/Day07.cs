using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day07;

public class Day07
{
    public void SolvePart1(string[] data)
    {
        FileSystem fs = new();
        CreateFileSystem(data, fs);

        List<int> dirSizes = new();
        dirSizes = fs.ListAllDirectorySizes();

        int totalSmallFileSize = dirSizes.Where(x => x < 100000).Sum();

        System.Console.WriteLine($"The sum of all the small files is {totalSmallFileSize}");
    }

    public void SolvePart2(string[] data)
    {
        FileSystem fs = new();
        CreateFileSystem(data, fs);

        int totalFsSize = 70000000;
        int unusedSpaceNeeded = 30000000;
        int amountOfUnusedSpaceOnDisk = totalFsSize - fs.RootNode.Size;
        int target = unusedSpaceNeeded - amountOfUnusedSpaceOnDisk;

        int dirSize = fs.ListAllDirectorySizes()
                        .Where(x => x >= target)
                        .OrderBy(x => x)
                        .First();

        System.Console.WriteLine($"The size of the directory to delete is {dirSize}");
    }

    public void CreateFileSystem(string[] data, FileSystem fs)
    {
        File curr = fs.RootNode;

        for (int i = 0; i < data.Length; i++)
        {
            List<string> tokens = data[i].Split(' ', StringSplitOptions.TrimEntries).ToList();
            if (tokens[0] == "$" && tokens[1] == "cd" && tokens[2] == "/")
            {

            }
            else if (tokens[0] == "$" && tokens[1] == "cd" && tokens[2] == "..")
            {
                curr = curr?.parent ?? fs.RootNode;
            }
            else if (tokens[0] == "$" && tokens[1] == "cd")
            {
                foreach (File item in curr.Files)
                {
                    if (item.Name == tokens[2])
                    {
                        curr = item;
                        break;
                    }
                }
            }
            else if (tokens[0] == "$" && tokens[1] == "ls")
            {

            }
            else if (tokens[0] == "dir")
            {
                File newDir = new File();
                newDir.Name = tokens[1];
                newDir.Type = FileType.Directory;
                newDir.parent = curr;
                curr?.Files.Add(newDir);
            }
            else
            {
                File newFile = new File();
                newFile.Name = tokens[1];
                newFile.Type = FileType.File;
                newFile.Size = int.Parse(tokens[0]);
                newFile.parent = curr;
                curr.Size += newFile.Size;
                curr?.Files.Add(newFile);

                File temp = curr;
                while (temp.parent != null)
                {
                    temp = temp.parent;
                    temp.Size += newFile.Size;
                }
            }
        }
    }

}