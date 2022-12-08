using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day07;

public class Program
{
    public static void Main(string[] args)
    {
        InputGetter input = new InputGetter("input.txt");

        ProgramFramework framework = new ProgramFramework();
        framework.InputHandler = input.GetStringsFromInput;
        framework.Part1Handler = new Day07().SolvePart1;
        framework.Part2Handler = new Day07().SolvePart2;
        framework.RunProgram();
    }
}