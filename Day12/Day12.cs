using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day12;

public class Day12
{
    public void SolvePart1(string[] data)
    {
        HashSet<(int y,int x)> unvisited = new();
        for (int y = 0; y < data.Length; y++)
            for (int x = 0; x < data[y].Length; x++)
                unvisited.Add( (y, x) );

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

    public (int,int) BredthFirstSearch(string[] data, (int y, int x) start, (int y, int x) dest, HashSet<(int y, int x)> explored)
    {
        Queue<(int,int)> search = new();
        explored.Add(start);
        search.Enqueue(start);
        while (search.Count > 0)
        {
            (int y, int x) curr = search.Dequeue();
            if (curr == dest) return curr;
            List<(int y, int x)> neighbors = GetValidNeighbors(curr, data);
            foreach (var node in neighbors)
            {
                if (!explored.Contains(node))
                {
                    explored.Add(node);
                    node.parent = curr;
                    search.Enqueue(node);
                }
            }
        }
    }

    public int DijkstrasSearch((int y, int x) curr, (int y, int x) dest, string[] data, HashSet<(int y, int x)> unvisited, int[,] distance)
    {
        bool searching = true;
        while (searching)
        {
            //System.Console.WriteLine($"dest y, x: {dest.y}, {dest.x}");
            System.Console.WriteLine($"y, x = {curr.y}, {curr.x}");
            //System.Console.WriteLine($"{data[curr.y][curr.x].ToString()}");
            List<(int y, int x)> neighbors = GetValidNeighbors(curr, data);
            foreach (var node in neighbors)
            {
                if (unvisited.Contains(node))
                    if (distance[curr.y, curr.x] + 1 < distance[node.y, node.x])
                        distance[node.y, node.x] = distance[curr.y, curr.x] + 1;
            }
            unvisited.Remove((curr.y, curr.x));

            if (curr == dest) searching = false;

            // get shortest distance unvisited node
            // set next node to smallest, unvisited neighbor
            int shortest = int.MaxValue;
            (int y, int x) shortestPos = (-1, -1);
            foreach (var node in neighbors)
            {
                if (unvisited.Contains(node) && distance[node.y, node.x] < shortest)
                {
                    shortest = distance[node.y, node.x];
                    shortestPos = node;
                }
            }
            if (shortestPos == (-1,-1))
            {
                foreach (var node in unvisited)
                {
                    if (distance[node.y, node.x] < shortest)
                    {
                        shortest = distance[node.y, node.x];
                        shortestPos = node;
                    }
                }
            }
            curr = shortestPos;

            PrintGrid(distance);
        }

        return distance[dest.y, dest.x];
    }

    private void PrintGrid(int[,] grid)
    {
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                if (grid[y,x] == int.MaxValue)
                    System.Console.Write($" XXX");
                else
                    System.Console.Write($"{grid[y,x],4}");
            }
            System.Console.WriteLine();
        }
        System.Console.WriteLine();
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