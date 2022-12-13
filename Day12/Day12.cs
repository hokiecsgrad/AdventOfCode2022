using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day12;

public class Day12
{
    public void SolvePart1(string[] data)
    {
        bool[,] unvisited = new bool[data.Length, data[0].Length];
        for (int y = 0; y < data.Length; y++)
            for (int x = 0; x < data[y].Length; x++)
                unvisited[y, x] = true;

        int[,] distance = new int[data.Length, data[0].Length];
        for (int y = 0; y < data.Length; y++)
            for (int x = 0; x < data[y].Length; x++)
                distance[y, x] = int.MaxValue;

        (int y, int x) start = FindPosOf('S', data);
        (int y, int x) dest = FindPosOf('E', data);

        distance[start.y, start.x] = 0;

        int shortestPath = DijkstrasSearch(start, dest, data, unvisited, distance);

        System.Console.WriteLine($"The shortest path from S to E is {shortestPath}.");
    }

    public void SolvePart2(string[] data)
    {
    }

    public int DijkstrasSearch((int y, int x) curr, (int y, int x) dest, string[] data, bool[,] unvisited, int[,] distance)
    {
        bool searching = true;
        while (searching)
        {
            List<(int y, int x)> neighbors = GetValidNeighbors(curr, data);
            foreach (var node in neighbors)
            {
                if (unvisited[node.y, node.x])
                    if (distance[curr.y, curr.x] + 1 < distance[node.y, node.x])
                        distance[node.y, node.x] = distance[curr.y, curr.x] + 1;
            }
            unvisited[curr.y, curr.x] = false;

            if (curr == dest) searching = false;
            bool allVisited = true;
            for (int y = 0; y < unvisited.GetLength(0); y++)
                for (int x = 0; x < unvisited.GetLength(1); x++)
                    if (unvisited[y, x])
                        allVisited = false;
            if (allVisited) throw new Exception();

            if (searching)
            {
                // get shortest distance unvisited node
                int shortest = int.MaxValue;
                (int y, int x) shortestPos = (0, 0);
                for (int y = 0; y < unvisited.GetLength(0); y++)
                {
                    for (int x = 0; x < unvisited.GetLength(1); x++)
                    {
                        if (unvisited[y, x] && distance[y, x] < shortest)
                        {
                            shortest = distance[y, x];
                            shortestPos = (y, x);
                        }
                    }
                }

                curr = shortestPos;
                // FIND NEXT CURR
                //curr = neighbors
                //        .Where(pos => unvisited[pos.y, pos.x])
                //        .OrderBy(pos => distance[pos.y, pos.x])
                //        .First();
            }
        }

        return distance[dest.y, dest.x];
    }

    public List<(int, int)> GetValidNeighbors((int y, int x) curr, string[] grid)
    {
        List<(int, int)> neighbors = new();
        (int y, int x) neighbor;

        neighbor = (curr.y - 1, curr.x);
        if (curr.y - 1 >= 0 && CanReachNeighbor(grid, curr, neighbor))
            neighbors.Add((curr.y - 1, curr.x));
        neighbor = (curr.y + 1, curr.x);
        if (curr.y + 1 < grid.Length && CanReachNeighbor(grid, curr, neighbor))
            neighbors.Add((curr.y + 1, curr.x));
        neighbor = (curr.y, curr.x - 1);
        if (curr.x - 1 >= 0 && CanReachNeighbor(grid, curr, neighbor))
            neighbors.Add((curr.y, curr.x - 1));
        neighbor = (curr.y, curr.x + 1);
        if (curr.x + 1 < grid[curr.y].Length && CanReachNeighbor(grid, curr, neighbor))
            neighbors.Add((curr.y, curr.x + 1));

        return neighbors;
    }

    public bool CanReachNeighbor(string[] grid, (int y, int x) c, (int y, int x) n)
     => (Math.Abs((int)grid[c.y][c.x] - (int)grid[n.y][n.x]) <= 1)
         || (grid[c.y][c.x] == 'z' && grid[n.y][n.x] == 'E')
         || (grid[c.y][c.x] == 'E' && grid[n.y][n.x] == 'z')
         || (grid[c.y][c.x] == 'S' && grid[n.y][n.x] == 'a')
         || (grid[c.y][c.x] == 'a' && grid[n.y][n.x] == 'S');

    public (int, int) FindPosOf(char target, string[] data)
    {
        for (int y = 0; y < data.Length; y++)
            for (int x = 0; x < data[y].Length; x++)
                if (data[y][x] == target) return (y, x);
        return (int.MaxValue, int.MaxValue);
    }
}