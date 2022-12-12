using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day12;

public class Day12
{
    public void SolvePart1(string[] data)
    {
    }

    public void SolvePart2(string[] data)
    {
    }

    public (int, int) FindStartPosition(string[] grid)
    {
        (int, int) startPos = (0, 0);

        for (int y = 0; y < grid.Length; y++)
            for (int x = 0; x < grid[y].Length; x++)
                if (grid[y][x] == 'S')
                {
                    startPos = (y, x);
                    break;
                }

        return startPos;
    }

    public List<int> FindPaths((int y, int x) start, string[] grid)
    {
        List<int> paths = new();

        return paths;
    }

    public List<int> FindPath((int y, int x) curr, string[] grid, List<int> visited)
    {
        // get list of valid neighbors

        // loop over neighbors

        // foreach valid neighbor, FindPath 

        // return paths
    }
}