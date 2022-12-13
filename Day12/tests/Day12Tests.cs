using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Day12;
using Xunit;

namespace AdventOfCode.Day12.Tests;

public class Day12Tests
{
    public Day12Tests()
    {
        data = sampleInput.Split('\n', StringSplitOptions.TrimEntries);
    }

    [Fact(Skip="This works fine")]
    public void TestTupleEquality()
    {
        (int y, int x) a = (1,3);
        (int y, int x) b = (1,3);
        (int y, int x) c = (2,5);
        (int, int) blah = (1,3);

        Assert.True(a == b);
        Assert.False(a == c);

        HashSet<(int y,int x)> unique = new();
        unique.Add(a);
        unique.Add(b);
        unique.Add(c);
        unique.Add(blah);
        Assert.Equal(2, unique.Count);

        unique.Remove((1,3));
        Assert.Equal(1, unique.Count);
    }

    [Fact(Skip="This works fine")]
    public void Part1_WithSampleData_ShouldReturn31()
    {
        Day12 solver = new();

        // create unvisited grid from data
        HashSet<(int y,int x)> unvisited = new();
        for (int y = 0; y < data.Length; y++)
            for (int x = 0; x < data[y].Length; x++)
                unvisited.Add( (y, x) );
       
        int[,] distance = new int[data.Length, data[0].Length];
        for (int y = 0; y < data.Length; y++)
            for (int x = 0; x < data[y].Length; x++)
                distance[y,x] = int.MaxValue;

        (int y, int x) start = solver.FindPosOf('S', data);
        (int y, int x) dest = solver.FindPosOf('E', data);

        distance[start.y, start.x] = 0;

        int shortestPath = solver.DijkstrasSearch(start, dest, data, unvisited, distance);

        Assert.Equal(31, shortestPath);
    }

    [Fact]
    public void Part1_WithRealData_ShouldFindShortestPath()
    {
        Day12 solver = new();
        data = realInput.Split('\n', StringSplitOptions.TrimEntries);

        // create unvisited grid from data
        HashSet<(int y,int x)> unvisited = new();
        for (int y = 0; y < data.Length; y++)
            for (int x = 0; x < data[y].Length; x++)
                unvisited.Add( (y, x) );
       
        int[,] distance = new int[data.Length, data[0].Length];
        for (int y = 0; y < data.Length; y++)
            for (int x = 0; x < data[y].Length; x++)
                distance[y,x] = int.MaxValue;

        (int y, int x) start = solver.FindPosOf('S', data);
        (int y, int x) dest = solver.FindPosOf('E', data);

        distance[start.y, start.x] = 0;

        int shortestPath = solver.DijkstrasSearch(start, dest, data, unvisited, distance);

        Assert.Equal(31, shortestPath);
    }

    string[] data;
    string sampleInput = """
Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi
""";

    string realInput = """
abaacccccccccccccaaaaaaaccccccccccccccccccccccccccccccccccaaaaaa
abaaccccccccccccccaaaaaaaaaaccccccccccccccccccccccccccccccccaaaa
abaaaaacccccccccaaaaaaaaaaaaccccccccccccccccccccccccccccccccaaaa
abaaaaaccccccccaaaaaaaaaaaaaacccccccccccccccccdcccccccccccccaaaa
abaaaccccccccccaaaaaaaaccacacccccccccccccccccdddcccccccccccaaaaa
abaaacccccccccaaaaaaaaaaccaaccccccccccccciiiiddddcccccccccccaccc
abcaaaccccccccaaaaaaaaaaaaaaccccccccccciiiiiijddddcccccccccccccc
abccaaccccccccaccaaaaaaaaaaaacccccccccciiiiiijjddddccccaaccccccc
abccccccccccccccaaacaaaaaaaaaaccccccciiiiippijjjddddccaaaccccccc
abccccccccccccccaacccccaaaaaaacccccciiiippppppjjjdddddaaaaaacccc
abccccccccccccccccccccaaaaaaccccccckiiippppppqqjjjdddeeeaaaacccc
abccccccccccccccccccccaaaaaaccccckkkiippppuupqqjjjjdeeeeeaaccccc
abccccccccccccccccccccccccaaccckkkkkkipppuuuuqqqjjjjjeeeeeaccccc
abccccccccccccccccccccccccccckkkkkkoppppuuuuuvqqqjjjjjkeeeeccccc
abcccccccccccccccccccccccccckkkkooooppppuuxuvvqqqqqqjkkkeeeecccc
abccaaccaccccccccccccccccccckkkoooooopuuuuxyvvvqqqqqqkkkkeeecccc
abccaaaaacccccaaccccccccccckkkoooouuuuuuuxxyyvvvvqqqqqkkkkeecccc
abcaaaaacccccaaaacccccccccckkkooouuuuxxxuxxyyvvvvvvvqqqkkkeeeccc
abcaaaaaaaaaaaaacccccccccccjjjooottuxxxxxxxyyyyyvvvvrrrkkkeecccc
abcccaaaacaaaaaaaaacaaccccccjjoootttxxxxxxxyyyyyyvvvrrkkkfffcccc
SbccaacccccaaaaaaaaaaaccccccjjjooottxxxxEzzzyyyyvvvrrrkkkfffcccc
abcccccccccaaaaaaaaaaaccccccjjjooootttxxxyyyyyvvvvrrrkkkfffccccc
abcaacccccaaaaaaaaaaaccccccccjjjooottttxxyyyyywwvrrrrkkkfffccccc
abaaacccccaaaaaaaaaaaaaacccccjjjjonnttxxyyyyyywwwrrlllkfffcccccc
abaaaaaaaaaaacaaaaaaaaaaccccccjjjnnnttxxyywwyyywwrrlllffffcccccc
abaaaaaaaaaaaaaaaaaaaaaaccccccjjjnntttxxwwwwwywwwrrlllfffccccccc
abaaccaaaaaaaaaaaaaaacccccccccjjjnntttxwwwsswwwwwrrlllfffccccccc
abaacccaaaaaaaacccaaacccccccccjjinnttttwwsssswwwsrrlllgffacccccc
abccccaaaaaaccccccaaaccccccccciiinnntttsssssssssssrlllggaacccccc
abccccaaaaaaaccccccccccaaccccciiinnntttsssmmssssssrlllggaacccccc
abccccaacaaaacccccccaacaaaccccciinnnnnnmmmmmmmsssslllgggaaaacccc
abccccccccaaacccccccaaaaacccccciiinnnnnmmmmmmmmmmllllgggaaaacccc
abaaaccccccccccccccccaaaaaacccciiiinnnmmmhhhmmmmmlllgggaaaaccccc
abaaaaacccccccccccaaaaaaaaaccccciiiiiiihhhhhhhhmmlgggggaaacccccc
abaaaaaccccaaccccaaaaaaacaacccccciiiiihhhhhhhhhhggggggcaaacccccc
abaaaaccccaaaccccaaaacaaaaacccccccciiihhaaaaahhhhggggccccccccccc
abaaaaaaacaaacccccaaaaaaaaaccccccccccccccaaaacccccccccccccccccaa
abaacaaaaaaaaaaaccaaaaaaaaccccccccccccccccaaaccccccccccccccccaaa
abcccccaaaaaaaaacccaaaaaaaccccccccccccccccaacccccccccccccccccaaa
abccccccaaaaaaaaaaaaaaaaacccccccccccccccccaaacccccccccccccaaaaaa
abcccccaaaaaaaaaaaaaaaaaaaaaccccccccccccccccccccccccccccccaaaaaa
""";
}
