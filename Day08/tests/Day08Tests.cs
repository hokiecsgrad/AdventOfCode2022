using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Day08;
using Xunit;

namespace AdventOfCode.Day08.Tests;

public class Day08Tests
{
    public Day08Tests()
    {
        string[] data = SampleInput.Split('\n', StringSplitOptions.TrimEntries);
    }

    [Fact]
    public void CreateTreeGrid_WithSampleData_ShouldMatchExpected()
    {
        Day08 solver = new();

        Tree[,] expected = new Tree[5, 5] {
            {new Tree(3),new Tree(0),new Tree(3),new Tree(7),new Tree(3)},
            {new Tree(2),new Tree(5),new Tree(5),new Tree(1),new Tree(2)},
            {new Tree(6),new Tree(5),new Tree(3),new Tree(3),new Tree(2)},
            {new Tree(3),new Tree(3),new Tree(5),new Tree(4),new Tree(9)},
            {new Tree(3),new Tree(5),new Tree(3),new Tree(9),new Tree(0)}
        };

        Assert.Equal(expected, solver.CreateTreeGrid(data));
    }

    [Fact]
    public void IsVisFromNorth_WhenTreeOnNorthEdge_ShouldBeTrue()
    {

    }

    private string[] data;
    private string SampleInput = """
30373
25512
65332
33549
35390
""";
}
