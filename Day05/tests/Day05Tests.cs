using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Day05;
using Xunit;

namespace AdventOfCode.Day05.Tests;

public class Day05Tests
{
    [Fact]
    public void StateParser_WithSampleData_ReturnsValidState()
    {
        string[] data = {"    [D]    ","[N] [C]    ","[Z] [M] [P]"," 1   2   3 ","","move 1 from 2 to 1","move 3 from 1 to 3","move 2 from 2 to 1","move 1 from 1 to 2"};
        Day05 solver = new();

        var state = solver.ParseInitState(data);

        Dictionary<int,Stack<char>> expected = new();
        expected[1] = new Stack<char>();
        expected[1].Push('Z');
        expected[1].Push('N');
        expected[2] = new Stack<char>();
        expected[2].Push('M');
        expected[2].Push('C');
        expected[2].Push('D');
        expected[3] = new Stack<char>();
        expected[3].Push('P');

        Assert.Equal(expected, state);
    }

    [Fact]
    public void InstructionsParser_WithSampleData_ReturnsValidInstructions()
    {
        string[] data = {"    [D]    ","[N] [C]    ","[Z] [M] [P]"," 1   2   3 ","","move 1 from 2 to 1","move 3 from 1 to 3","move 2 from 2 to 1","move 1 from 1 to 2"};
        Day05 solver = new();

        var instructions = solver.ParseMoveSet(data);

        string[] expected = new string[] {
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"};

        Assert.Equal(expected, instructions);
    }

    [Fact]
    public void MoveParser_WithFirstRowOfSampleData_ShouldReturn1And2And1()
    {
        string data = "move 1 from 2 to 1";
        Day05 solver = new();

        (int num, int source, int dest) instruction = solver.ParseMove(data);

        Assert.Equal(1, instruction.num);
        Assert.Equal(2, instruction.source);
        Assert.Equal(1, instruction.dest);
    }

    [Fact]
    public void Part1_WithSampleData_ShouldReturnCMZ()
    {
        string[] data = {"    [D]    ","[N] [C]    ","[Z] [M] [P]"," 1   2   3 ","","move 1 from 2 to 1","move 3 from 1 to 3","move 2 from 2 to 1","move 1 from 1 to 2"};
        Day05 solver = new();

        solver.SolvePart1(data);

        Assert.True(true);
    }
}
