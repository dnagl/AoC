using System.Text.RegularExpressions;

const string inputFile = "input.txt";

Stage1();
Stage2();
return;

void Stage1()
{
    var input = File.ReadAllLines(inputFile);
    
    var result = input.Select(line => $"{line.First(char.IsDigit)}{line.Last(char.IsDigit)}").Select(value => int.Parse(value)).Sum();

    Console.WriteLine($"Stage 1: {result}");
}

void Stage2()
{
    var input = File.ReadAllLines(inputFile);
    const string PATTERN = @"one|two|three|four|five|six|seven|eight|nine|[0-9]";
    var result = 0;
    foreach (var line in input)
    {
        var first = Regex.Match(line, PATTERN);
        var last = Regex.Match(line, PATTERN, RegexOptions.RightToLeft);
        result += 10 * GetIntValue(first.Value) + GetIntValue(last.Value);
    }
    
    Console.WriteLine($"Stage 2: {result}");
}

int GetIntValue(string s)
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