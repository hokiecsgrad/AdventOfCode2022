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
        Assert.False(solver.IsFullOverlap(new HashSet<int> { 2, 3, 4 },
                                          new HashSet<int> { 6, 7, 8 }
                                          ));
    }

    [Fact]
    public void IsFullyContained_WithLeftOverlap_ShouldBeFalse()
    {
        Day04 solver = new();
        Assert.False(solver.IsFullOverlap(new HashSet<int> { 5, 6, 7 },
                                          new HashSet<int> { 7, 8, 9 }
                                          ));
    }

    [Fact]
    public void IsFullyContained_WithRightOverlap_ShouldBeFalse()
    {
        Day04 solver = new();
        Assert.False(solver.IsFullOverlap(new HashSet<int> { 7, 8, 9 },
                                          new HashSet<int> { 5, 6, 7 }
                                          ));
    }

    [Fact]
    public void IsFullyContained_WithFullOverlap_ShouldBeTrue()
    {
        Day04 solver = new();
        Assert.True(solver.IsFullOverlap(new HashSet<int> { 6 },
                                         new HashSet<int> { 4, 5, 6 }
                                         ));
    }

    [Fact]
    public void IsPartiallyContained_WithNoOverlap_ShouldBeFalse()
    {
        Day04 solver = new();
        Assert.False(solver.IsPartialOverlap(new HashSet<int> { 2, 3, 4 },
                                             new HashSet<int> { 6, 7, 8 }
                                             ));
    }

    [Fact]
    public void IsPartiallyContained_WitLowerOverlap_ShouldBeTrue()
    {
        Day04 solver = new();
        Assert.True(solver.IsPartialOverlap(new HashSet<int> { 5, 6, 7 },
                                            new HashSet<int> { 7, 8, 9 }
                                            ));
    }

    [Fact]
    public void IsPartiallyContained_WitUpperOverlap_ShouldBeTrue()
    {
        Day04 solver = new();
        Assert.True(solver.IsPartialOverlap(new HashSet<int> { 6 },
                                            new HashSet<int> { 4, 5, 6 }
                                            ));
    }
}
