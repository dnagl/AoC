using System.Text.RegularExpressions;

namespace AdventOfCode2023.Puzzle.Day3;

[PuzzleInformation(Name ="Gear Ratios", Day = 3, Complete = true)]
public class Day3 : PuzzleBase<Day3>
{
    public Day3() : base("input.txt") { }

    public override string Part1()
    {
        var input = Lines.ToArray();
        return input.Select((line, index) =>
            new Regex(@"\d+").Matches(line).SelectMany(match => match.Groups.Cast<Group>().Select(group => group.Captures.First()))
                .Where(n =>
                    Enumerable.Range(0, n.Length).Select(j => (index - 1, n.Index + j)).Concat(Enumerable.Range(0, n.Length).Select(j => (index + 1, n.Index + j)))
                        .Concat(Enumerable.Range(-1, 3).Select(j => (index + j, n.Index - 1))).Concat(Enumerable.Range(-1, 3).Select(j => (index + j, n.Index + n.Length)))
                        .Where(c => c.Item1 >= 0 && c.Item1 < input.Length && c.Item2 >= 0 && c.Item2 < input[c.Item1].Length)
                        .Select(c => input[c.Item1][c.Item2])
                        .Any(i => i != '.' && i is < '0' or > '9')
                ).Sum(n => int.Parse(n.Value))
        ).Sum().ToString();
    }

    public override string Part2()
    {
        var input = Lines.ToArray();
        return input.Select((line, index) =>
            new Regex(@"\*").Matches(line).SelectMany(match => match.Groups.Cast<Group>().Select(group => group.Captures.First()))
                .Select(g => new (int, int)[] { (index - 1, g.Index), (index + 1, g.Index) }
                    .Concat(Enumerable.Range(-1, 3).Select(j => (index + j, g.Index - 1))).Concat(Enumerable.Range(-1, 3).Select(j => (index + j, g.Index + 1)))
                    .Where(c => c.Item1 >= 0 && c.Item1 < input.Length && c.Item2 >= 0 && c.Item2 < input[c.Item1].Length)
                    .Where(i => input[i.Item1][i.Item2] >= '0' && input[i.Item1][i.Item2] <= '9')
                    .Select(n => (n.Item1, n.Item2,
                        string.Concat(input[n.Item1][..n.Item2].Reverse().TakeWhile(c => c is >= '0' and <= '9').Reverse()), string.Concat(input[n.Item1][(n.Item2 + 1)..].TakeWhile(c => c is >= '0' and <= '9'))))
                    .Select(t => (t.Item1, t.Item2, t.Item3, t.Item4, t.Item2 - t.Item3.Length, t.Item2 + t.Item4.Length))
                    .DistinctBy(t => (t.Item1, t.Item5, t.Item6))
                    .Select(t => t.Item3 + input[t.Item1][t.Item2] + t.Item4)
                    .Select(int.Parse)
                )
                .Where(g => g.Count() == 2)
                .Sum(g => g.Aggregate((acc, v) => acc * v))
        ).Sum().ToString();
    }
}