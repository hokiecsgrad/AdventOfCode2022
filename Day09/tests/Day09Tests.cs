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
        List<Vector> visitedLocations = new List<Vector> { new Vector(0,0) };
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

        HashSet<Vector> uniqueLocationsHash = new HashSet<Vector>(visitedLocations);

        Assert.Equal(13, uniqueLocationsHash.Count);
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
}
