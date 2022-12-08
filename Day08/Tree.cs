using System;

namespace AdventOfCode.Day08;

public class Tree
{
    public int Size { get; } = 0;
    public int NorthVis { get; set; } = 0;
    public int SouthVis { get; set; } = 0;
    public int EastVis { get; set; } = 0;
    public int WestVis { get; set; } = 0;

    public int Visibility {
        get {
            return NorthVis * SouthVis * EastVis * WestVis;
        }
    }

    public Tree(int size)
    {
        Size = size;
    }
}