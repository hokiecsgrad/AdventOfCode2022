using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day03;

public class Day03
{
    public void SolvePart1(string[] data)
    {
        int totalScore = data
                            .Select(
                                s => GetScore(GetDuplicateItem(s))
                                )
                            .Sum();

        System.Console.WriteLine($"Score for duplicate items is {totalScore}");
    }

    public void SolvePart2(string[] data)
    {
        int totalScore = 0;
        for (int i = 0; i < data.Length - 2; i += 3)
        {
            HashSet<char> tripleCommon = new HashSet<char>(data[i]);
            tripleCommon.IntersectWith(new HashSet<char>(data[i + 1]));
            tripleCommon.IntersectWith(new HashSet<char>(data[i + 2]));

            totalScore += GetScore(tripleCommon.First());
        }

        System.Console.WriteLine($"Score for all the triples is {totalScore}");
    }

    public char GetDuplicateItem(string itemString)
    {
        HashSet<char> leftItems = new HashSet<char>(
                                            itemString
                                                .Substring(
                                                    0,
                                                    itemString.Length / 2
                                                    )
                                                .ToCharArray()
                                            );

        HashSet<char> rightItems = new HashSet<char>(
                                            itemString
                                                .Substring(
                                                    itemString.Length / 2
                                                    )
                                                .ToCharArray()
                                            );

        leftItems.IntersectWith(rightItems);

        return leftItems.FirstOrDefault();
    }

    public int GetScore(char itemCode)
    {
        if (itemCode == '\0') return 0;

        int charScore = 0;

        if (Char.IsLower(itemCode))
            charScore = (int)itemCode - (int)'a' + 1;
        else
            charScore = (int)itemCode - (int)'A' + 26 + 1;

        return charScore;
    }


}