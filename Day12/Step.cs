using System;
using System.Collections.Generic;

namespace AdventOfCode.Day12;

public class Step
{
    public string Name { get; set; }
    public List<Step> Edges { get; private set; } = new();
    public bool Visited { get; set; } = false;
    public int DistanceToSource { get; set; } = int.MaxValue;

    public Step(string name)
    {
        Name = name;
    }

    public void AddEdge(Step dest)
    {
        if (!Edges.Contains(dest))
            Edges.Add(dest);
    }
}
