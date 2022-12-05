using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Common;

namespace AdventOfCode.Day05;

public class Day05
{
    public void SolvePart1(string[] data)
    {
        Dictionary<int, Stack<char>> state = ParseInitState(data);
        string[] instructions = ParseMoveSet(data);

        for (int i = 0; i < instructions.Length; i++)
        {
            (int num, int source, int dest) instruction = ParseMove(instructions[i]);
            for (int j = 0; j < instruction.num; j++)
            {
                char item;
                item = state[instruction.source].Pop();
                state[instruction.dest].Push(item);
            }
        }

        System.Console.WriteLine("The top items on the stack are:");
        for (int i = 0; i < state.Count(); i++)
            System.Console.Write(state[i+1].Pop());
        System.Console.WriteLine();
    }

    public void SolvePart2(string[] data)
    {
        Dictionary<int, Stack<char>> state = ParseInitState(data);
        string[] instructions = ParseMoveSet(data);

        for (int i = 0; i < instructions.Length; i++)
        {
            (int num, int source, int dest) instruction = ParseMove(instructions[i]);
            char[] items = new char[instruction.num];
            for (int j = 0; j < instruction.num; j++)
                items[j] = state[instruction.source].Pop();
            for (int j = instruction.num - 1; j >= 0; j--)
                state[instruction.dest].Push(items[j]);
        }

        System.Console.WriteLine("The top items on the stack are:");
        for (int i = 0; i < state.Count(); i++)
            System.Console.Write(state[i+1].Pop());
        System.Console.WriteLine();
    }

    public Dictionary<int, Stack<char>> ParseInitState(string[] data)
    {
        int indexOfLineOfStateEnding = 0;
        for (indexOfLineOfStateEnding = 0; indexOfLineOfStateEnding < data.Length; indexOfLineOfStateEnding++)
            if (String.IsNullOrEmpty(data[indexOfLineOfStateEnding]))
                break;
        indexOfLineOfStateEnding--;

        Dictionary<int, Stack<char>> state = new();

        int maxCols = int.Parse(
                            data[indexOfLineOfStateEnding]
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)[^1]
                            );
        int[] charPositions = new int[maxCols];
        for (int i = 0; i < data[indexOfLineOfStateEnding].Length; i++)
            if (data[indexOfLineOfStateEnding][i] != ' ' ) charPositions[data[indexOfLineOfStateEnding][i] - '1'] = i;

        for (int i = indexOfLineOfStateEnding - 1; i >= 0; i--)
        {
            for (int j = 0; j < maxCols; j++)
            {
                if (i == indexOfLineOfStateEnding - 1)
                    state[j+1] = new Stack<char>();

                if (data[i][charPositions[j]] != ' ')
                    state[j+1].Push(data[i][charPositions[j]]);
            }
        }

        return state;
    }

    public string[] ParseMoveSet(string[] data)
    {
        int i = 0;
        for (i = 0; i < data.Length; i++)
            if (String.IsNullOrEmpty(data[i]))
                break;
        i++;

        string[] instructions = new string[data.Length - i];
        
        Array.Copy(data, i, instructions, 0, data.Length - i);

        return instructions;
    }

    public (int,int,int) ParseMove(string moveInstructions)
    {
        string pattern = @"^move ([\d]+) from ([\d]+) to ([\d]+)$";
        Match match = Regex.Match(moveInstructions, pattern, RegexOptions.IgnoreCase);
        
        return (int.Parse(match.Groups[1].Value), 
                int.Parse(match.Groups[2].Value), 
                int.Parse(match.Groups[3].Value));
    }
}