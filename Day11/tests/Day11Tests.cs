using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Day11;
using Xunit;

namespace AdventOfCode.Day11.Tests;

public class Day11Tests
{
    public Day11Tests()
    {
        data = sampleInput.Split('\n', StringSplitOptions.TrimEntries);
    }

    [Fact]
    public void ParseMonkey_WithFirstSampleMonkey_ShouldReturnMonkey()
    {
        data = new string[5] {
            "  Starting items: 79, 98",
            "  Operation: new = old * 19",
            "  Test: divisible by 23",
            "    If true: throw to monkey 2",
            "    If false: throw to monkey 3"
        };

        Monkey monkey = new Monkey(data);

        Assert.Equal(2, monkey.Items.Count);
        Assert.Equal("*", monkey.WorryLevelOp);
        Assert.Equal(19, monkey.WorryLevelValue);
        Assert.Equal(2, monkey.MonkeyIndexTrue);
        Assert.Equal(3, monkey.MonkeyIndexFalse);
    }

    [Fact]
    public void Turn_WithSampleData_ShouldWork()
    {
        data = new string[5] {
            "  Starting items: 79, 98",
            "  Operation: new = old * 19",
            "  Test: divisible by 23",
            "    If true: throw to monkey 2",
            "    If false: throw to monkey 3"
        };
        Monkey monkey0 = new Monkey(data);

        data = new string[5] {
            "  Starting items: 74",
            "  Operation: new = old + 3",
            "  Test: divisible by 17",
            "    If true: throw to monkey 0",
            "    If false: throw to monkey 1"
        };
        Monkey monkey3 = new Monkey(data);

        Monkey[] monkeys = new Monkey[4];
        monkeys[0] = monkey0;
        monkeys[3] = monkey3;

        monkeys[0].TakeTurn(monkeys);

        Assert.Equal(2, monkeys[0].NumItemsInspected);
        Assert.Empty(monkeys[0].Items);
        Assert.Equal(0, monkeys[3].NumItemsInspected);
        Assert.Equal(3, monkeys[3].Items.Count);
    }

    [Fact]
    public void Round_WithSampleData_ShouldWork()
    {
        Day11 solver = new();
        Monkey[] monkeys = solver.ParseMonkeyFromInput(data, true);

        for (int i = 0; i < monkeys.Length; i++)
        {
            monkeys[i].TakeTurn(monkeys);
        }

        Assert.Equal(4, monkeys[0].Items.Count);
        Assert.Equal(6, monkeys[1].Items.Count);
        Assert.Empty(monkeys[2].Items);
        Assert.Empty(monkeys[3].Items);
    }

    [Fact]
    public void Part1_WithSampleData_ShouldReturn10605()
    {
        Day11 solver = new();
        Monkey[] monkeys = solver.ParseMonkeyFromInput(data, true);

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

        Assert.Equal(10605, total);
    }

    [Fact (Skip = "takes way too damn long")]
    public void Part2_WithSampleData_ShouldReturn2713310158()
    {
        Day11 solver = new();
        Monkey[] monkeys = solver.ParseMonkeyFromInput(data, true);

        for (int j = 0; j < 10000; j++)
        {
            for (int i = 0; i < monkeys.Length; i++)
                monkeys[i].TakeTurn(monkeys);
        }

        BigInteger total = monkeys
                        .OrderByDescending(x => x.NumItemsInspected)
                        .Take(2)
                        .Select(m => m.NumItemsInspected)
                        .Aggregate((a, b) => a * b);

        Assert.Equal(2713310158, total);
    }

    string[] data;
    string sampleInput = """
Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1
""";
}
