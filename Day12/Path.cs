using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day12;

public class Path
{
    private Step _rootNode;

    public Path(string[] data)
    {
        CreateGraph(data);
    }

    public List<string> FindPaths()
    {
        return TravelPaths(_rootNode, new List<Step>());
    }

    private List<string> TravelPaths(Step currNode, List<Step> visited)
    {
        if (visited.Contains(currNode)) return new List<string>();
        if (currNode.Name[^1] == 'E') return new List<string> { ",E" };

        List<string> currPaths = new();
        foreach (var node in currNode.Edges)
        {
            List<string> paths = TravelPaths(node, new List<Step>(visited) { currNode });
            string prefix = currNode.Name[^1] == 'S' ? "" : ",";
            paths = paths.Select(p => prefix + currNode.Name[^1] + p).ToList();
            currPaths.AddRange(paths);
        }

        return currPaths;
    }

    private void CreateGraph(string[] data)
    {
        Step[,] pathGrid = new Step[data.Length, data[0].Length];
        for (int y = 0; y < data.Length; y++)
            for (int x = 0; x < data[y].Length; x++)
            {
                pathGrid[y, x] ??= new Step($"{y},{x}: {data[y][x]}");
                if (data[y][x] == 'S') _rootNode = pathGrid[y, x];

                List<Step> neighbors = GetValidNeighbors((y, x), data, pathGrid);
                foreach (Step neighbor in neighbors)
                {
                    pathGrid[y, x].AddEdge(neighbor);
                    neighbor.AddEdge(pathGrid[y, x]);
                }
            }
    }

    public List<Step> GetValidNeighbors((int y, int x) curr, string[] grid, Step[,] pathGrid)
    {
        List<Step> neighbors = new();
        (int y, int x) neighbor;

        neighbor = (curr.y - 1, curr.x);
        if (curr.y - 1 >= 0 && CanReachNeighbor(grid, curr, neighbor) && pathGrid[curr.y - 1, curr.x] is not null)
            neighbors.Add(pathGrid[curr.y - 1, curr.x]);
        neighbor = (curr.y + 1, curr.x);
        if (curr.y + 1 < grid.Length - 1 && CanReachNeighbor(grid, curr, neighbor) && pathGrid[curr.y + 1, curr.x] is not null)
            neighbors.Add(pathGrid[curr.y + 1, curr.x]);
        neighbor = (curr.y, curr.x - 1);
        if (curr.x - 1 >= 0 && CanReachNeighbor(grid, curr, neighbor) && pathGrid[curr.y, curr.x - 1] is not null)
            neighbors.Add(pathGrid[curr.y, curr.x - 1]);
        neighbor = (curr.y, curr.x + 1);
        if (curr.x + 1 < grid[curr.y].Length - 1 && CanReachNeighbor(grid, curr, neighbor) && pathGrid[curr.y, curr.x + 1] is not null)
            neighbors.Add(pathGrid[curr.y, curr.x + 1]);

        return neighbors;
    }

    public bool CanReachNeighbor(string[] grid, (int y, int x) c, (int y, int x) n)
     => (Math.Abs((int)grid[c.y][c.x] - (int)grid[n.y][n.x]) <= 1)
         || (grid[c.y][c.x] == 'z' && grid[n.y][n.x] == 'E')
         || (grid[c.y][c.x] == 'E' && grid[n.y][n.x] == 'z')
         || (grid[c.y][c.x] == 'S' && grid[n.y][n.x] == 'a')
         || (grid[c.y][c.x] == 'a' && grid[n.y][n.x] == 'S');


    public Step GetRootNode() => _rootNode;
}