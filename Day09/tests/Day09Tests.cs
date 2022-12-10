using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Day09;
using Xunit;

namespace AdventOfCode.Day09.Tests;

public class Day09Tests
{
    [Fact]
    public void Part1_WithSampleData_ShouldReturn13()
    {
        Day09 solver = new();
        List<Vector> visitedLocations = new List<Vector> { new Vector(0, 0) };
        Vector headPos = new Vector();

        for (int i = 0; i < data.Length; i++)
        {
            (Vector direction, int numSteps) cmd = solver.ParseCommand(data[i]);

            for (int j = 0; j < cmd.numSteps; j++)
            {
                headPos.X += cmd.direction.X;
                headPos.Y += cmd.direction.Y;
                Vector dir = solver.DirectionVecBetweenHeadAndTail(headPos, visitedLocations.Last());
                if (solver.DistanceBetweenHeadAndTail(dir) > 1)
                {
                    Vector directionToGo = dir.ToUnit();
                    Vector newTailPos = new Vector(visitedLocations.Last().X + directionToGo.X, visitedLocations.Last().Y + directionToGo.Y);
                    visitedLocations.Add(newTailPos);
                }
            }
        }

        List<Vector> uniqueLocList = new();
        foreach (Vector item in visitedLocations)
        {
            if (!uniqueLocList.Where(vec => vec.X == item.X && vec.Y == item.Y).Any())
            {
                uniqueLocList.Add(item);
            }
        }

        Assert.Equal(13, uniqueLocList.Count);
    }

    [Fact]
    public void Part2_WithPart1SampleData_ShouldReturn1()
    {
        Day09 solver = new();
        List<Vector> visitedLocations = new List<Vector> { new Vector(0, 0) };
        Vector[] rope = new Vector[9];
        rope[0] = new Vector();
        rope[1] = new Vector();
        rope[2] = new Vector();
        rope[3] = new Vector();
        rope[4] = new Vector();
        rope[5] = new Vector();
        rope[6] = new Vector();
        rope[7] = new Vector();
        rope[8] = new Vector();

        for (int i = 0; i < data.Length; i++)
        {
            (Vector direction, int numSteps) cmd = solver.ParseCommand(data[i]);

            for (int j = 0; j < cmd.numSteps; j++)
            {
                // move head
                rope[0].X += cmd.direction.X;
                rope[0].Y += cmd.direction.Y;

                // move everything else
                for (int knotIndex = 1; knotIndex < rope.Length; knotIndex++)
                {
                    Vector dir = solver.DirectionVecBetweenHeadAndTail(
                                            rope[knotIndex - 1],
                                            rope[knotIndex]
                                            );
                    if (solver.DistanceBetweenHeadAndTail(dir) > 1)
                    {
                        Vector directionToGo = dir.ToUnit();
                        rope[knotIndex] = new Vector(
                                rope[knotIndex].X + directionToGo.X,
                                rope[knotIndex].Y + directionToGo.Y
                                );
                    }
                }
                visitedLocations.Add(rope[rope.Length - 1]);
            }
        }

        List<Vector> uniqueLocList = new();
        foreach (Vector item in visitedLocations)
        {
            if (!uniqueLocList.Where(vec => vec.X == item.X && vec.Y == item.Y).Any())
            {
                uniqueLocList.Add(item);
            }
        }

        Assert.Equal(1, uniqueLocList.Count);
    }

    [Fact]
    public void Part2_WithPart2SampleData_ShouldReturn36()
    {
        data = sampleInput2.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        Day09 solver = new();
        List<Vector> visitedLocations = new List<Vector> { new Vector(0, 0) };
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

        for (int i = 0; i < data.Length; i++)
        {
            (Vector direction, int numSteps) cmd = solver.ParseCommand(data[i]);

            for (int j = 0; j < cmd.numSteps; j++)
            {
                // move head
                rope[0].X += cmd.direction.X;
                rope[0].Y += cmd.direction.Y;

                // move everything else
                for (int knotIndex = 1; knotIndex < rope.Length; knotIndex++)
                {
                    Vector dir = solver.DirectionVecBetweenHeadAndTail(
                                            rope[knotIndex - 1],
                                            rope[knotIndex]
                                            );
                    if (solver.DistanceBetweenHeadAndTail(dir) > 1)
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

        Assert.Equal(36, visitedLocations.Count);
    }

    public Day09Tests()
    {
        data = sampleInput.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
    }

    private string[] data;
    private string sampleInput = """
R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2
""";

    private string sampleInput2 = """
R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20
""";
}
