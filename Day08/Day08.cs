using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day08;

public class Day08
{
    public void SolvePart1(string[] data)
    {
        Tree[,] grid = CreateTreeGrid(data);
        int total = 0;

        for (int y = 0; y < grid.GetLength(0); y++)
            for (int x = 0; x < grid.GetLength(1); x++)
                if (IsVisible(ref grid, y, x))
                    total++;

        System.Console.WriteLine($"The number of visible trees is {total}.");
    }

    public void SolvePart2(string[] data)
    {
        Tree[,] grid = CreateTreeGrid(data);
        int maxVisibility = 0;

        for (int y = 0; y < grid.GetLength(0); y++)
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                IsVisible(ref grid, y, x);
                if (grid[y, x].Visibility > maxVisibility)
                    maxVisibility = grid[y, x].Visibility;
            }

        System.Console.WriteLine($"Tree with the best view is {maxVisibility}.");
    }

    public Tree[,] CreateTreeGrid(string[] data)
    {
        Tree[,] trees = new Tree[data.Length, data[0].Length];

        for (int i = 0; i < data.Length; i++)
            for (int j = 0; j < data[0].Length; j++)
                trees[i, j] = new Tree((int)char.GetNumericValue(data[i][j]));

        return trees;
    }

    public bool IsVisible(ref Tree[,] grid, int y, int x)
    {
        bool isVisN = IsVisibleFrom(ref grid, y, x, Direction.North);
        bool isVisS = IsVisibleFrom(ref grid, y, x, Direction.South);
        bool isVisE = IsVisibleFrom(ref grid, y, x, Direction.East);
        bool isVisW = IsVisibleFrom(ref grid, y, x, Direction.West);

        if (isVisN || isVisS || isVisE || isVisW)
            return true;
        else
            return false;
    }

    public bool IsVisibleFrom(ref Tree[,] grid, int y, int x, Direction direction)
    {
        bool isVisible = true;

        int yLow = 0;
        int yHigh = grid.GetLength(0) - 1;
        int xLow = 0;
        int xHigh = grid.GetLength(1) - 1;

        (int y, int x) dir = direction switch
        {
            Direction.North => (-1, 0),
            Direction.South => (1, 0),
            Direction.East => (0, 1),
            Direction.West => (0, -1),
            _ => (0, 0)
        };

        (int y, int x) curr = (y + dir.y, x + dir.x);
        while (curr.y >= yLow && curr.y <= yHigh && curr.x >= xLow && curr.x <= xHigh)
        {
            if (direction == Direction.North) grid[y, x].NorthVis++;
            else if (direction == Direction.South) grid[y, x].SouthVis++;
            else if (direction == Direction.East) grid[y, x].EastVis++;
            else if (direction == Direction.West) grid[y, x].WestVis++;

            if (grid[y, x].Size <= grid[curr.y, curr.x].Size)
                return false;

            curr.y += dir.y;
            curr.x += dir.x;
        }

        return isVisible;
    }
}