using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day02;

public enum Outcome
{
    Lose = 0,
    Draw = 3,
    Win = 6
}

public class Day02
{
    public void SolvePart1(string[] data)
    {
        int totalScore = data
            .Select(
                gameCode => ScoreGame(GetShape(gameCode[0]), GetShape(gameCode[2]))
                )
            .Sum();

        System.Console.WriteLine($"Total score for all games is {totalScore}");
    }

    public void SolvePart2(string[] data)
    {
        int totalScore = data
            .Select(
                gameCode => ScoreGame(
                                GetShape(gameCode[0]),
                                DetermineShapeForGameStrategy(
                                    GetShape(gameCode[0]),
                                    GetStrategy(gameCode[2])
                                    )
                                )
                )
            .Sum();

        System.Console.WriteLine($"Total score for all ideal games should be {totalScore}");
    }

    private Dictionary<char, string> decodeShape = new Dictionary<char, string> {
            { 'A', "Rock" },
            { 'B', "Paper" },
            { 'C', "Scissors" },
            { 'X', "Rock" },
            { 'Y', "Paper" },
            { 'Z', "Scissors" }
        };
    private Dictionary<string, int> shapeScores = new Dictionary<string, int> {
            { "Rock", 1 },
            { "Paper", 2 },
            { "Scissors", 3 }
        };
    private Dictionary<string, Outcome> outcomes = new Dictionary<string, Outcome> {
            { "RockRock", Outcome.Draw }, { "RockPaper", Outcome.Lose }, { "RockScissors", Outcome.Win },
            { "PaperRock", Outcome.Win }, { "PaperPaper", Outcome.Draw }, { "PaperScissors", Outcome.Lose },
            { "ScissorsRock", Outcome.Lose }, { "ScissorsPaper", Outcome.Win }, { "ScissorsScissors", Outcome.Draw }
        };

    public int ScoreGame(string elfShape, string ryanShape)
    {
        return shapeScores[ryanShape] + (int)outcomes[ryanShape + elfShape];
    }

    private Dictionary<char, Outcome> decodeStrategy = new Dictionary<char, Outcome> {
            { 'X', Outcome.Lose },
            { 'Y', Outcome.Draw },
            { 'Z', Outcome.Win }
        };

    private Dictionary<string, string> strategies = new Dictionary<string, string> {
            { "RockWin", "Paper" }, { "RockDraw", "Rock" }, { "RockLose", "Scissors" },
            { "PaperWin", "Scissors" }, { "PaperDraw", "Paper" }, { "PaperLose", "Rock" },
            { "ScissorsWin", "Rock" }, { "ScissorsDraw", "Scissors" }, { "ScissorsLose", "Paper" }
        };


    public string GetShape(char shapeCode)
    {
        return decodeShape[shapeCode];
    }

    public string GetStrategy(char strat)
    {
        return decodeStrategy[strat].ToString();
    }

    public string DetermineShapeForGameStrategy(string elfsPlay, string strategy)
    {
        return strategies[elfsPlay + strategy];
    }
}