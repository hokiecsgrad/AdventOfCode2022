using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Day04;
using Xunit;

namespace AdventOfCode.Day04.Tests;

public class Day04Tests
{
    [Fact]
    public void IsFullyContained_WithNoOverlap_ShouldBeFalse()
    {
        Day04 solver = new();
        Assert.False(solver.IsFullOverlap("2-4", "6-8"));
    }

    [Fact]
    public void IsFullyContained_WithLeftOverlap_ShouldBeFalse()
    {
        Day04 solver = new();
        Assert.False(solver.IsFullOverlap("5-7", "7-9"));
    }

    [Fact]
    public void IsFullyContained_WithRightOverlap_ShouldBeFalse()
    {
        Day04 solver = new();
        Assert.False(solver.IsFullOverlap("7-9", "5-7"));
    }

    [Fact]
    public void IsFullyContained_WithFullOverlap_ShouldBeTrue()
    {
        Day04 solver = new();
        Assert.True(solver.IsFullOverlap("6-6", "4-6"));
    }

    [Fact]
    public void IsPartiallyContained_WithNoOverlap_ShouldBeFalse()
    {
        Day04 solver = new();
        Assert.False(solver.IsPartialOverlap("2-4", "6-8"));
    }

    [Fact]
    public void IsPartiallyContained_WitLowerOverlap_ShouldBeTrue()
    {
        Day04 solver = new();
        Assert.True(solver.IsPartialOverlap("5-7", "7-9"));
    }

    [Fact]
    public void IsPartiallyContained_WitUpperOverlap_ShouldBeTrue()
    {
        Day04 solver = new();
        Assert.True(solver.IsPartialOverlap("6-6", "4-6"));
    }
}
