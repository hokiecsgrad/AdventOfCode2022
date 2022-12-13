using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Day12;
using Xunit;

namespace AdventOfCode.Day12.Tests;

public class Day12Tests
{
    public Day12Tests()
    {
        data = sampleInput.Split('\n', StringSplitOptions.TrimEntries);
    }

    [Fact]
    public void Part1_WithSampleData_ShouldReturn31()
    {
        Path path = new Path(data);
        List<string> paths = path.FindPaths();

        int shortestPath = paths
                            .Where(str => str[^1] == 'E')
                            .Select(str => str.Replace(",", string.Empty))
                            .OrderBy(str => str.Length)
                            .First()
                            .Length - 1;

        Assert.Equal(31, shortestPath);
    }

    string[] data;
    string sampleInput = """
Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi
""";
}
