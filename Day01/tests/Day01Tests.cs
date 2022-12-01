using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Day01;
using Xunit;

namespace AdventOfCode.Day01.Tests;

public class Day01Tests
{
    private string[] data;

    public Day01Tests()
    {
        data = "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000"
                .Split(
                    "\n",
                    StringSplitOptions.TrimEntries
                    );
    }

    [Fact]
    public void GroupListItems_WithSmallSample_ShouldReturnSmallerList()
    {
        Day01 solver = new Day01();
        List<int> elfsCalorieTotal = solver.SumListGroups(data);

        Assert.Equal(5, elfsCalorieTotal.Count());
    }

    [Fact]
    public void FindMax_WithSampleData_ShouldReturn24000()
    {
        Day01 solver = new Day01();
        List<int> elfsCalorieTotal = solver.SumListGroups(data);

        Assert.Equal(24000, elfsCalorieTotal.Max());
    }

    [Fact]
    public void FindTopThree_WithSampleData_ShouldReturn45000()
    {
        Day01 solver = new Day01();
        List<int> elfsCalorieTotal = solver.SumListGroups(data);

        int topThreeTotal = elfsCalorieTotal
                                .OrderByDescending(x => x)
                                .Take(3)
                                .Sum();

        Assert.Equal(45000, topThreeTotal);
    }
}