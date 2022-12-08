using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day08;

public class Day08
{
    public void SolvePart1(string[] data)
    {
    }

    public void SolvePart2(string[] data)
    {
    }

    public Tree[,] CreateTreeGrid(string[] data)
    {
        Tree[,] trees = new Tree[data.Length, data[0].Length];

        for (int i = 0; i < data.Length; i++)
            for (int j = 0; j < data[0].Length; j++)
                trees[i, j] = new Tree((int)char.GetNumericValue(data[i][j]));

        return trees;
    }
}