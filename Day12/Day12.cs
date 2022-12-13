using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day12;

public class Day12
{
    public void SolvePart1(string[] data)
    {
        System.Console.WriteLine($"Creating graph...");
        Path path = new Path(data);

        System.Console.WriteLine($"Traversing graph...");
        List<string> paths = path.FindPaths();

        int shortestPath = paths
                            .Where(str => str[^1] == 'E')
                            .Select(str => str.Replace(",", string.Empty))
                            .OrderBy(str => str.Length)
                            .First()
                            .Length - 1;
        System.Console.WriteLine($"The shortest path from S to E is {shortestPath}.");
    }

    public void SolvePart2(string[] data)
    {
    }
}