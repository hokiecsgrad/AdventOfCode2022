using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day11;

public class Day11
{
    public void SolvePart1(string[] data)
    {
        Monkey[] monkeys = ParseMonkeyFromInput(data);

        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < monkeys.Length; i++)
                monkeys[i].TakeTurn(monkeys);
        }

        int total = monkeys
                        .OrderByDescending(x => x.NumItemsInspected)
                        .Take(2)
                        .Select(m => m.NumItemsInspected)
                        .Aggregate((a, b) => a * b);
    }

    public void SolvePart2(string[] data)
    {
    }

    public Monkey[] ParseMonkeyFromInput(string[] data)
    {
        List<Monkey> monkeys = new();
        List<Monkey> monkeyData = new();
        Monkey monkey;
        for (int i = 0; i < data.Length; i++)
        {
            if (string.IsNullOrEmpty(data[i]) || i == data.Length - 1)
            {
                monkey = new Monkey(data[i - 5].Take(5).ToArray());
            }
        }

        return monkeys.ToArray();
    }
}