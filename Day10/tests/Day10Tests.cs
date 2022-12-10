using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Day10;
using Xunit;

namespace AdventOfCode.Day10.Tests;

public class Day10Tests
{
    public Day10Tests()
    {
        data = sampleInput.Split(
                            '\n',
                            StringSplitOptions.TrimEntries |
                            StringSplitOptions.RemoveEmptyEntries
                            );
    }

    [Fact]
    public void Part1_WithSampleData_ShouldReturn13140()
    {
        Day10 solver = new();

        Queue<int> instructions = new();
        List<int> checkSums = new List<int> { 20, 60, 100, 140, 180, 220 };
        int total = 0;
        int register = 1;
        int cycle = 0;

        while (cycle <= data.Length || instructions.Count > 0)
        {
            cycle++;
            if (cycle <= data.Length)
                solver.ProcessCommand(data[cycle - 1], ref instructions);

            // do cycle stuff here
            if (checkSums.Find(x => x == cycle) > 0)
                total += cycle * register;

            register += instructions.Dequeue();
        }

        Assert.Equal(13140, total);
    }

    [Fact]
    public void Part2_WithSampleData_ShouldRenderScreen()
    {
        Day10 solver = new();

        Queue<int> instructions = new();
        string render = string.Empty;
        int register = 1;
        int cycle = 0;

        while (cycle < data.Length || instructions.Count > 0)
        {
            if (cycle < data.Length)
                solver.ProcessCommand(data[cycle], ref instructions);

            // do cycle stuff here
            if (cycle > 0 && cycle % 40 == 0) render += "\r\n";
            if (cycle % 40 >= register - 1 && cycle % 40 <= register + 1)
                render += "#";
            else
                render += ".";

            register += instructions.Dequeue();

            cycle++;
        }

        string expected = """
##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....
""";

        Assert.Equal(expected, render);
    }

    private string[] data;
    private string sampleInput = """
addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop
""";

}
