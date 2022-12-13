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
    public void Dijkstra_WithSampleData_ShouldFindShortestPath31()
    {
        Day12 solver = new();

        // create unvisited grid from data
        bool[,] unvisited = new bool[data.Length, data[0].Length];
        for (int y = 0; y < data.Length; y++)
            for (int x = 0; x < data[y].Length; x++)
                unvisited[y,x] = true;
        
        int[,] distance = new int[data.Length, data[0].Length];
        for (int y = 0; y < data.Length; y++)
            for (int x = 0; x < data[y].Length; x++)
                distance[y,x] = int.MaxValue;

        (int y, int x) start = solver.FindPosOf('S', data);
        (int y, int x) dest = solver.FindPosOf('E', data);

        distance[start.y, start.x] = 0;

        int shortestPath = solver.DijkstrasSearch(start, dest, data, unvisited, distance);

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
