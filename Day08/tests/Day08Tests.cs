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
        data = SampleInput.Split('\n', StringSplitOptions.TrimEntries);
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

        Tree[,] actual = solver.CreateTreeGrid(data);

        for (int i = 0; i < data.Length; i++)
            for (int j = 0; j < data[i].Length; j++)
                Assert.Equal(expected[i,j].Size, actual[i,j].Size);
    }

    [Fact]
    public void IsVisFromNorth_WhenTreeOnNorthEdge_ShouldBeTrue()
    {
        Day08 solver = new();
        Tree[,] grid = solver.CreateTreeGrid(data);
        bool isVisible = solver.IsVisibleFrom(ref grid, 0, 2, Direction.North);

        Assert.True(isVisible);
    }

    [Fact]
    public void IsVisFromNorth_WhenTreeInMid_ShouldBeTrue()
    {
        Day08 solver = new();
        Tree[,] grid = solver.CreateTreeGrid(data);
        bool isVisible = solver.IsVisibleFrom(ref grid, 3, 4, Direction.North);

        Assert.True(isVisible);
    }

    [Fact]
    public void IsVisFromNorth_WhenTreeInMide_ShouldBeFalse()
    {
        Day08 solver = new();
        Tree[,] grid = solver.CreateTreeGrid(data);
        bool isVisible = solver.IsVisibleFrom(ref grid, 1, 3, Direction.North);

        Assert.False(isVisible);
    }

    [Fact]
    public void IsVisFromAnyDirs_WithSampleData23_ShouldBeTrue()
    {
        Day08 solver = new();
        Tree[,] grid = solver.CreateTreeGrid(data);
        bool isVisible = solver.IsVisible(ref grid, 2, 3);

        Assert.True(isVisible);
    }

    [Fact]
    public void IsVisFromAnyDirs_WithSampleData22_ShouldBeFalse()
    {
        Day08 solver = new();
        Tree[,] grid = solver.CreateTreeGrid(data);
        bool isVisible = solver.IsVisible(ref grid, 2, 2);

        Assert.False(isVisible);
    }

    [Fact]
    public void Part1_WithSampleData_ShouldReturn21()
    {
        Day08 solver = new();
        Tree[,] grid = solver.CreateTreeGrid(data);
        int total = 0;

        for (int y = 0; y < grid.GetLength(0); y++)
            for (int x = 0; x < grid.GetLength(1); x++)
                if (solver.IsVisible(ref grid, y, x))
                    total++;

        Assert.Equal(21, total);
    }

    [Fact]
    public void CountVis_WithSampleData12_ShouldReturn4()
    {
        Day08 solver = new();
        Tree[,] grid = solver.CreateTreeGrid(data);

        solver.IsVisibleFrom(ref grid, 1, 2, Direction.North);
        solver.IsVisibleFrom(ref grid, 1, 2, Direction.South);
        solver.IsVisibleFrom(ref grid, 1, 2, Direction.East);
        solver.IsVisibleFrom(ref grid, 1, 2, Direction.West);

        Assert.Equal(4, grid[1,2].Visibility);
    }

    [Fact]
    public void CountVis_WithSampleData32_ShouldReturn8()
    {
        Day08 solver = new();
        Tree[,] grid = solver.CreateTreeGrid(data);

        solver.IsVisibleFrom(ref grid, 3, 2, Direction.North);
        solver.IsVisibleFrom(ref grid, 3, 2, Direction.South);
        solver.IsVisibleFrom(ref grid, 3, 2, Direction.East);
        solver.IsVisibleFrom(ref grid, 3, 2, Direction.West);

        Assert.Equal(8, grid[3,2].Visibility);
    }

    [Fact]
    public void Part2_WithSampleData_ShouldReturn8()
    {
        Day08 solver = new();
        Tree[,] grid = solver.CreateTreeGrid(data);
        int maxVisibility = 0;

        for (int y = 0; y < grid.GetLength(0); y++)
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                solver.IsVisible(ref grid, y, x);
                if (grid[y,x].Visibility > maxVisibility)
                    maxVisibility = grid[y,x].Visibility;
            }

        Assert.Equal(8, maxVisibility);
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
