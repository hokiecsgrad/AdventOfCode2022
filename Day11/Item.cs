using System;
using System.Numerics;

namespace AdventOfCode.Day11;

public class Item
{
    public BigInteger WorryLevel { get; set; } = 0;

    public Item(BigInteger level)
    {
        WorryLevel = level;
    }
}