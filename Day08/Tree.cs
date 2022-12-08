using System;

namespace AdventOfCode.Day08;

public class Tree
{
    public int Size { get; } = 0;
    public bool IsVisFromNorth = false;
    public bool IsVisFromSouth = false;
    public bool IsVisFromEast = false;
    public bool IsVisFromWest = false;

    public bool IsVisible
    {
        get
        {
            return IsVisFromNorth || IsVisFromSouth || IsVisFromEast || IsVisFromWest;
        }
    }

    public Tree(int size)
    {
        Size = size;
    }
}