using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day04;

public class Day04
{
    public void SolvePart1(string[] data)
    {
        int totalPairsWithOverlap = 0;
        for (int i = 0; i < data.Length; i++)
        {
            (string, string) pair = ParseAssignment(data[i]);
            if (IsFullOverlap(pair.Item1, pair.Item2))
                totalPairsWithOverlap++;
        }

        System.Console.WriteLine($"The numer of pairs with fully overlap is {totalPairsWithOverlap}");
    }

    public void SolvePart2(string[] data)
    {
        int totalPairsWithOverlap = 0;
        for (int i = 0; i < data.Length; i++)
        {
            (string, string) pair = ParseAssignment(data[i]);
            if (IsPartialOverlap(pair.Item1, pair.Item2))
                totalPairsWithOverlap++;
        }

        System.Console.WriteLine($"The numer of pairs with partial overlap is {totalPairsWithOverlap}");
    }

    public (string, string) ParseAssignment(string input)
        => (input.Split(',', StringSplitOptions.TrimEntries)[0],
            input.Split(',', StringSplitOptions.TrimEntries)[1]);

    public bool IsFullOverlap(string pair1, string pair2)
    {
        bool fullyContained = false;
        int p1Lower = int.Parse(pair1.Split('-', 2, StringSplitOptions.TrimEntries)[0]);
        int p1Upper = int.Parse(pair1.Split('-', 2, StringSplitOptions.TrimEntries)[1]);
        int p2Lower = int.Parse(pair2.Split('-', 2, StringSplitOptions.TrimEntries)[0]);
        int p2Upper = int.Parse(pair2.Split('-', 2, StringSplitOptions.TrimEntries)[1]);

        if (p1Lower >= p2Lower && p1Upper <= p2Upper) fullyContained = true;
        if (p2Lower >= p1Lower && p2Upper <= p1Upper) fullyContained = true;

        return fullyContained;
    }

    public bool IsPartialOverlap(string pair1, string pair2)
    {
        bool partialOverlap = false;
        (int, int) p1 = (int.Parse(pair1.Split('-', 2, StringSplitOptions.TrimEntries)[0]),
                          int.Parse(pair1.Split('-', 2, StringSplitOptions.TrimEntries)[1]));
        (int, int) p2 = (int.Parse(pair2.Split('-', 2, StringSplitOptions.TrimEntries)[0]),
                          int.Parse(pair2.Split('-', 2, StringSplitOptions.TrimEntries)[1]));

        if (p1.Item1 > p2.Item1)
        {
            var temp = p1;
            p1 = p2;
            p2 = temp;
        }

        if (p1.Item2 >= p2.Item1 || p2.Item1 <= p1.Item2) partialOverlap = true;

        return partialOverlap;
    }
}