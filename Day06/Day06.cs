using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day06;

public class Day06
{
    public void SolvePart1(string[] data)
    {
        int numCharsProcessed = FindIndexOfFirstUniqueRun(data[0], 4);
        System.Console.WriteLine($"Num characters processed before finding start of packet is {numCharsProcessed}.");
    }

    public void SolvePart2(string[] data)
    {
        int numCharsProcessed = FindIndexOfFirstUniqueRun(data[0], 14);
        System.Console.WriteLine($"Num characters processed before finding start of message is {numCharsProcessed}.");
    }

    public int FindIndexOfFirstUniqueRun(string signal, int numUniqueChars)
    {
        int numCharsProcessed = 0;
        for (int i = 0; i < signal.Length - numUniqueChars; i++)
        {
            HashSet<char> testFour = new HashSet<char> (signal.Substring(i,numUniqueChars).ToCharArray());
            if (testFour.Count() == numUniqueChars) { numCharsProcessed = i + numUniqueChars; break; }
        }

        return numCharsProcessed;
    }
}