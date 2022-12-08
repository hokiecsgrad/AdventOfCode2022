using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Day07;
using Xunit;

namespace AdventOfCode.Day07.Tests;

public class Day07Tests
{
    private string[] data;
    private string sampleData = """
$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k
""";

    public Day07Tests()
    {
        data = sampleData.Split('\n',
                StringSplitOptions.TrimEntries |
                StringSplitOptions.RemoveEmptyEntries);
    }

    [Fact]
    public void SolvePart2_WithSampleData_ShouldReturn24933642()
    {
        Day07 solver = new();
        FileSystem fs = new();

        solver.CreateFileSystem(data, fs);

        int totalFsSize = 70000000;
        int unusedSpaceNeeded = 30000000;
        int amountOfUnusedSpaceOnDisk = totalFsSize - fs.RootNode.Size;
        int target = unusedSpaceNeeded - amountOfUnusedSpaceOnDisk;

        int dirSize = fs.ListAllDirectorySizes()
                        .Where(x => x >= target)
                        .OrderBy(x => x)
                        .First();

        Assert.Equal(24933642, dirSize);
    }
}
