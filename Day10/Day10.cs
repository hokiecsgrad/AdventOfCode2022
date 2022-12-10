using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day10;

public class Day10
{
    public void SolvePart1(string[] data)
    {
        Queue<int> instructions = new();
        List<int> checkSums = new List<int> { 20, 60, 100, 140, 180, 220 };
        int total = 0;
        int register = 1;
        int cycle = 0;

        while (cycle <= data.Length || instructions.Count > 0)
        {
            cycle++;
            if (cycle <= data.Length)
                ProcessCommand(data[cycle - 1], ref instructions);

            // do cycle stuff here
            if (checkSums.Find(x => x == cycle) > 0)
                total += cycle * register;

            if (instructions.Count > 0)
                register += instructions.Dequeue();
        }

        System.Console.WriteLine($"Sum of registers is {total}.");
    }

    public void SolvePart2(string[] data)
    {
        Queue<int> instructions = new();
        string render = string.Empty;
        int register = 1;
        int cycle = 0;

        while (cycle < data.Length || instructions.Count > 0)
        {
            if (cycle < data.Length)
                ProcessCommand(data[cycle], ref instructions);

            // do cycle stuff here
            if (cycle > 0 && cycle % 40 == 0) render += "\r\n";
            if (cycle % 40 >= register - 1 && cycle % 40 <= register + 1)
                render += "#";
            else
                render += " ";

            register += instructions.Dequeue();

            cycle++;
        }

        System.Console.WriteLine(render);
    }

    public void ProcessCommand(string input, ref Queue<int> instr)
    {
        string cmd = input.Split(' ', StringSplitOptions.TrimEntries)[0];
        switch (cmd)
        {
            case "noop":
                instr.Enqueue(0);
                break;
            case "addx":
                int param = int.Parse(input.Split(' ', StringSplitOptions.TrimEntries)[1]);
                instr.Enqueue(0);
                instr.Enqueue(param);
                break;
        }
    }
}