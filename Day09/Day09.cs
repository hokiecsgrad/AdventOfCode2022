using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day09;

public class Day09
{
    public void SolvePart1(string[] data)
    {
    }

    public void SolvePart2(string[] data)
    {
    }

    public (Vector, int) ParseCommand(string command)
    {
        int numSteps = int.Parse(command.Split(' ')[1]);
        Vector direction = command.Split(' ')[0] switch
        {
            "U" => new Vector(0, -1),
            "D" => new Vector(0, 1),
            "R" => new Vector(1, 0),
            "L" => new Vector(-1, 0),
            _ => throw new ArgumentException("Invalid command received in input")
        };
        return (direction, numSteps);
    }

    public Vector DirectionVecBetweenHeadAndTail(Vector headPos, Vector tailPos)
        => new Vector((int)(headPos.X - tailPos.X), (int)(headPos.Y - tailPos.Y));

    public double DistanceBetweenHeadAndTail(Vector vector)
        => vector.Magnitude();
}