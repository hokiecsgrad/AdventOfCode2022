using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Day03;
using Xunit;

namespace AdventOfCode.Day03.Tests;

public class Day03Tests
{
    [Fact]
    public void GetDuplicate_WithFirstLineOfSampleInput_ShouldReturnLowercaseP()
    {
        string data = "vJrwpWtwJgWrhcsFMMfFFhFp";

        Day03 solver = new();
        char duplicate = solver.GetDuplicateItem(data);

        Assert.Equal('p', duplicate);
    }

    [Fact]
    public void GetScore_WithLowercaseP_ShouldReturn16()
    {
        Day03 solver = new();
        int score = solver.GetScore('p');

        Assert.Equal(16, score);
    }

    [Fact]
    public void GetScore_WithUppercaseP_ShouldReturn42()
    {
        Day03 solver = new();
        int score = solver.GetScore('P');

        Assert.Equal(42, score);
    }

    [Fact]
    public void GetScore_WithNoDuplicates_ShouldReturn0()
    {
        string data = "DBHTnlGGBPjPmwRWhm";

        Day03 solver = new();
        char duplicate = solver.GetDuplicateItem(data);
        Assert.Equal('\0', duplicate);

        int score = solver.GetScore(duplicate);
        Assert.Equal(0, score);
    }

    [Fact]
    public void Part1_WithSampleInput_ShouldReturn157()
    {
        string[] data = {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };
        Day03 solver = new();

        int totalScore = 0;
        for (int i = 0; i < data.Length; i++)
        {
            char dupe = solver.GetDuplicateItem(data[i]);
            totalScore += solver.GetScore(dupe);
        }

        Assert.Equal(157, totalScore);
    }

    [Fact]
    public void Part2_WithSampleData_ShouldReturn70()
    {
        string[] data = {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };
        Day03 solver = new();

        int totalScore = 0;
        for (int i = 0; i < data.Length - 2; i += 3)
        {
            HashSet<char> tripleCommon = new HashSet<char>(data[i]);
            tripleCommon.IntersectWith(new HashSet<char>(data[i + 1]));
            tripleCommon.IntersectWith(new HashSet<char>(data[i + 2]));

            totalScore += solver.GetScore(tripleCommon.First());
        }

        Assert.Equal(70, totalScore);
    }
}
