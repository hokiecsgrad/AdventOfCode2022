using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day01;

public class Day01
{
    public void SolvePart1(string[] data)
    {
        List<int> elfsTotalCalories = SumListGroups(data);
        int maxCalories = elfsTotalCalories.Max();

        Console.WriteLine($"Max calories from a single elf is {maxCalories}");
    }

    public void SolvePart2(string[] data)
    {
        List<int> elfsTotalCalories = SumListGroups(data);

        int topThreeTotal = elfsTotalCalories
                                .OrderByDescending(x => x)
                                .Take(3)
                                .Sum();

        System.Console.WriteLine($"The total calorie count for the top 3 elves is {topThreeTotal}");
    }

    public List<int> SumListGroups(string[] data)
    {
        int[] foodCalorieList = Array.ConvertAll(
                                        data,
                                        s =>
                                        {
                                            int i;
                                            return int.TryParse(s, out i) ? i : 0;
                                        });

        List<int> elfsCalorieSum = new();

        int totalCalories = 0;
        for (int i = 0; i < foodCalorieList.Length; i++)
        {
            if (foodCalorieList[i] == 0)
            {
                elfsCalorieSum.Add(totalCalories);
                totalCalories = 0;
                continue;
            }
            totalCalories += foodCalorieList[i];
        }
        elfsCalorieSum.Add(totalCalories);

        return elfsCalorieSum;
    }
}