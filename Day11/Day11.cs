using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day11;

public class Day11
{
    public void SolvePart1(string[] data)
    {
        Monkey[] monkeys = ParseMonkeyFromInput(data, true);

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

        System.Console.WriteLine($"The product of the top two monkeys after 20 rounds is {total}.");
    }

    public void SolvePart2(string[] data)
    {
        Monkey[] monkeys = ParseMonkeyFromInput(data, false);

        for (int j = 0; j < 10000; j++)
        {
            for (int i = 0; i < monkeys.Length; i++)
                monkeys[i].TakeTurn(monkeys);
            if (j % 20 == 0) System.Console.WriteLine($"Finished round {j}");
        }

        int total = monkeys
                        .OrderByDescending(x => x.NumItemsInspected)
                        .Take(2)
                        .Select(m => m.NumItemsInspected)
                        .Aggregate((a, b) => a * b);

        System.Console.WriteLine($"The product of the top two monkeys after 10,000 rounds is {total}.");
    }

    public Monkey[] ParseMonkeyFromInput(string[] data, bool isPart1)
    {
        List<Monkey> monkeys = new();

        for (int i = 0; i < data.Length; i++)
        {
            if (string.IsNullOrEmpty(data[i]) || i == data.Length - 1)
            {
                int startIndex = (i == data.Length - 1) ? 4 : 5;
                Monkey monkey = new Monkey(new string[] {data[i-startIndex--], data[i-startIndex--], data[i-startIndex--], data[i-startIndex--], data[i-startIndex]}, isPart1);
                monkeys.Add(monkey);
            }
        }

        return monkeys.ToArray();
    }
}