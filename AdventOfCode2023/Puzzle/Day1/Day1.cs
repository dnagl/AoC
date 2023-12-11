using System.Text.RegularExpressions;

namespace AdventOfCode2023.Puzzle.Day1;

[PuzzleInformation(Name ="Trebuchet", Day = 1, Complete = true)]
public class Day1 : PuzzleBase<Day1>
{
    public Day1() : base("input.txt"){ }

    public override string Part1()
    {
        return Lines.Select(line => $"{line.First(char.IsDigit)}{line.Last(char.IsDigit)}")
            .Select(value => int.Parse(value)).Sum().ToString();
    }

    public override string Part2()
    {
        const string PATTERN = @"one|two|three|four|five|six|seven|eight|nine|[0-9]";
        var result = 0;
        foreach (var line in Lines)
        {
            var first = Regex.Match(line, PATTERN);
            var last = Regex.Match(line, PATTERN, RegexOptions.RightToLeft);
            result += 10 * GetIntValue(first.Value) + GetIntValue(last.Value);
        }

        return result.ToString();
    }
    
    private int GetIntValue(string s)
    {
        return s switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => int.Parse(s)
        };
    }
}