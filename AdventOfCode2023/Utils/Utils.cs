namespace AdventOfCode2023.Utils;

public static class Utils
{
    public static IEnumerable<string> ReadPuzzleLines(int day, string fileName) =>
        File.ReadLines($"InputFiles/day{day}/{fileName}");
}