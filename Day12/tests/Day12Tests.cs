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
    public void FindStartPosition_WithSampleData_ShouldReturn00()
    {
        Day12 solver = new();

        (int y, int x) startPos = solver.FindStartPosition(data);

        Assert.Equal((0, 0), startPos);
    }

    [Fact]
    public void Part1_WithSampleData_ShouldReturn31()
    {

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
