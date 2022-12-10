using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day09;

public class Day09
{
    public void SolvePart1(string[] data)
    {
        Vector[] rope = new Vector[2];
        rope[0] = new Vector();
        rope[1] = new Vector();

        List<Vector> visitedLocations = MoveRope(data, rope);

        int total = visitedLocations.Count;
        System.Console.WriteLine($"The number of unique locations visited is {total}.");
    }

    public void SolvePart2(string[] data)
    {
        Vector[] rope = new Vector[10];
        rope[0] = new Vector();
        rope[1] = new Vector();
        rope[2] = new Vector();
        rope[3] = new Vector();
        rope[4] = new Vector();
        rope[5] = new Vector();
        rope[6] = new Vector();
        rope[7] = new Vector();
        rope[8] = new Vector();
        rope[9] = new Vector();

        List<Vector> visitedLocations = MoveRope(data, rope);

        int total = visitedLocations.Count;
        System.Console.WriteLine($"The number of locations visited by the tail is {total}.");
    }

    public List<Vector> MoveRope(string[] data, Vector[] rope)
    {
        List<Vector> visitedLocations = new List<Vector> { new Vector(0, 0) };

        for (int i = 0; i < data.Length; i++)
        {
            (Vector direction, int numSteps) cmd = ParseCommand(data[i]);

            for (int j = 0; j < cmd.numSteps; j++)
            {
                // move head
                rope[0].X += cmd.direction.X;
                rope[0].Y += cmd.direction.Y;

                // move everything else
                for (int knotIndex = 1; knotIndex < rope.Length; knotIndex++)
                {
                    Vector dir = DirectionVecBetweenHeadAndTail(
                                            rope[knotIndex - 1],
                                            rope[knotIndex]
                                            );

                    if (DistanceBetweenHeadAndTail(dir) > 1)
                    {
                        Vector directionToGo = dir.ToUnit();
                        rope[knotIndex] = new Vector(
                                rope[knotIndex].X + directionToGo.X,
                                rope[knotIndex].Y + directionToGo.Y
                                );
                    }
                }

                if (false == visitedLocations
                                .Where(vec => vec.X == rope[rope.Length - 1].X &&
                                              vec.Y == rope[rope.Length - 1].Y)
                                .Any()
                                )
                    visitedLocations.Add(rope[rope.Length - 1]);
            }
        }

        return visitedLocations;
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