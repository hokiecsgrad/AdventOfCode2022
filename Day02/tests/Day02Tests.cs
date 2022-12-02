using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Day02;
using Xunit;

namespace AdventOfCode.Day02.Tests;

public class Day02Tests
{
    [Fact]
    public void ScoreGame_WithSampleData_ShouldReturn15()
    {
        string[] data = "A Y\nB X\nC Z".Split("\n", StringSplitOptions.TrimEntries);
        Day02 solver = new Day02();

        int totalScore = 0;
        for (int i = 0; i < data.Length; i++)
        {
            string player1Shape = solver.GetShape(data[i][0]);
            string player2Shape = solver.GetShape(data[i][2]);
            totalScore += solver.ScoreGame(player1Shape, player2Shape);
        }

        Assert.Equal(15, totalScore);
    }

    [Fact]
    public void DetermineStrategy_WhenElfChoosesRockAndNeedToDraw_ShouldReturnRock()
    {
        string game = "A Y";
        Day02 solver = new();

        Assert.Equal("Rock",
                        solver.DetermineShapeForGameStrategy(
                                solver.GetShape(game[0]),
                                solver.GetStrategy(game[2])
                                )
                    );
    }

    [Fact]
    public void ScoreGamePart2_WithSampleData_ShouldReturn12()
    {
        string[] data = "A Y\nB X\nC Z".Split("\n", StringSplitOptions.TrimEntries);
        Day02 solver = new();

        int totalScore = 0;
        for (int i = 0; i < data.Length; i++)
        {
            string player1Shape = solver.GetShape(data[i][0]);
            string gameStrategy = solver.GetStrategy(data[i][2]);
            string player2Shape = solver.DetermineShapeForGameStrategy(
                                        player1Shape,
                                        gameStrategy
                                        );
            totalScore += solver.ScoreGame(player1Shape, player2Shape);
        }

        Assert.Equal(12, totalScore);
    }
}
