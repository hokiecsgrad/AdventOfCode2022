using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day11;

public class Monkey
{
    public Queue<Item> Items { get; set; } = new();
    public int NumItemsInspected { get; set; } = 0;

    public string WorryLevelOp { get; set; } = string.Empty;
    public int WorryLevelValue { get; set; } = 0;

    public int TestDivBy { get; set; } = 0;
    public int MonkeyIndexTrue { get; set; } = 0;
    public int MonkeyIndexFalse { get; set; } = 0;

    public Monkey(string[] data)
    {
        ParseMonkey(data);
    }

    private void ParseMonkey(string[] data)
    {
        // Starting items: 57, 58
        List<Item> items = data[0]
                    .Substring(data[0].IndexOf(':') + 1)
                    .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => new Item(int.Parse(x)))
                    .ToList<Item>();
        foreach (Item item in items) Items.Enqueue(item);

        // Operation: new = old * 19
        if (data[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)[5] == "old")
        {
            WorryLevelOp = "**";
            WorryLevelValue = 0;
        }
        else
        {
            WorryLevelOp = data[1]
                        .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                        [4];
            WorryLevelValue = int.Parse(data[1]
                        .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                        [5]);
        }

        // Test: divisible by 7
        TestDivBy = int.Parse(data[2].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)[3]);
        // If true: throw to monkey 2
        MonkeyIndexTrue = int.Parse(data[3].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)[5]);
        // If false: throw to monkey 3
        MonkeyIndexFalse = int.Parse(data[4].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)[5]);
    }

    public void TakeTurn(Monkey[] monkeys)
    {
        Item currItem;
        while (Items.Count > 0)
        {
            currItem = InspectItem();

            currItem.WorryLevel /= 3;

            bool test = currItem.WorryLevel % TestDivBy == 0;
            monkeys[test ? MonkeyIndexTrue : MonkeyIndexFalse].Items.Enqueue(currItem);
        }
    }

    public Item InspectItem()
    {
        Item currItem = Items.Dequeue();
        currItem.WorryLevel = WorryLevelOp switch
        {
            "+" => currItem.WorryLevel + WorryLevelValue,
            "-" => currItem.WorryLevel - WorryLevelValue,
            "*" => currItem.WorryLevel * WorryLevelValue,
            "/" => currItem.WorryLevel / WorryLevelValue,
            "**" => (int)Math.Pow(currItem.WorryLevel, 2),
            _ => throw new InvalidOperationException()
        };
        NumItemsInspected++;
        return currItem;
    }
}