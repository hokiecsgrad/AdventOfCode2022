using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Day06;
using Xunit;

namespace AdventOfCode.Day06.Tests;

public class Day06Tests
{
    [Fact]
    public void ParseFour_WithSampleData_ShouldReturnIndex7()
    {
        string data = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";
        
        Day06 solver = new();
        int numCharsProcessed = solver.FindIndexOfFirstUniqueRun(data, 4);

        Assert.Equal(7, numCharsProcessed);
    }

    [Fact]
    public void ParseFourteen_WithSampleData_ShouldReturnIndex19()
    {
        string data = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";
        
        Day06 solver = new();
        int numCharsProcessed = solver.FindIndexOfFirstUniqueRun(data, 14);

        Assert.Equal(19, numCharsProcessed);
    }
}
