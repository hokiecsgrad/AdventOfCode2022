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
            (HashSet<int> p1, HashSet<int> p2) pair = ParseAssignment(data[i]);

            if (IsFullOverlap(pair.p1, pair.p2))
                totalPairsWithOverlap++;
        }

        System.Console.WriteLine($"The numer of pairs with fully overlap is {totalPairsWithOverlap}");
    }

    public void SolvePart2(string[] data)
    {
        int totalPairsWithOverlap = 0;
        for (int i = 0; i < data.Length; i++)
        {
            (HashSet<int> p1, HashSet<int> p2) pair = ParseAssignment(data[i]);

            if (IsPartialOverlap(pair.p1, pair.p2))
                totalPairsWithOverlap++;
        }

        System.Console.WriteLine($"The numer of pairs with partial overlap is {totalPairsWithOverlap}");
    }

    public (HashSet<int>, HashSet<int>) ParseAssignment(string input)
    {
        string assignment = input.Split(',', StringSplitOptions.TrimEntries)[0];
        HashSet<int> p1 = Enumerable
                            .Range(
                                int.Parse(assignment.Split('-')[0]),
                                int.Parse(assignment.Split('-')[1])
                                    - int.Parse(assignment.Split('-')[0])
                                    + 1
                                )
                            .ToHashSet();

        assignment = input.Split(',', StringSplitOptions.TrimEntries)[1];
        HashSet<int> p2 = Enumerable
                            .Range(
                                int.Parse(assignment.Split('-')[0]),
                                int.Parse(assignment.Split('-')[1])
                                    - int.Parse(assignment.Split('-')[0])
                                    + 1
                                )
                            .ToHashSet();

        return (p1, p2);
    }

    public bool IsFullOverlap(HashSet<int> p1, HashSet<int> p2)
        => (p1.IsSubsetOf(p2) || p2.IsSubsetOf(p1));

    public bool IsPartialOverlap(HashSet<int> p1, HashSet<int> p2)
        => (p1.Intersect(p2).Count() > 0);
}