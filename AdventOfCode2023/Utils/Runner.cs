using System.Diagnostics;
using System.Reflection;
using AdventOfCode2023.Puzzle;

namespace AdventOfCode2023.Utils;

public class Runner
{

    public void RunAll()
    {
        var types = typeof(Runner).Assembly.GetTypes()
            .Where(x => x.GetCustomAttributes(typeof(PuzzleInformation), true).Length > 0);

        foreach (var type in types)
            Run(type);
    }

    public void RunIncomplete()
    {
        var types = typeof(Runner).Assembly.GetTypes()
            .Where(x => x.GetCustomAttributes(typeof(PuzzleInformation), true).Length > 0)
            .Where(x => !((x.GetCustomAttribute(typeof(PuzzleInformation)) as PuzzleInformation)!).Complete);

        foreach (var type in types)
            Run(type);
    }
    
    public void Run<T>() where T : PuzzleBase<T> => Run(typeof(T));

    public void Run(Type type)
    {
        var puzzle = Activator.CreateInstance(type)!;
        type.GetMethod("Setup")?.Invoke(puzzle, Array.Empty<object?>());

        var attribute = Attribute.GetCustomAttribute(type, typeof(PuzzleInformation)) as PuzzleInformation;
        var stopwatch = new Stopwatch();
        
        Console.WriteLine($"Running day {attribute!.Day} '{attribute.Name}'");
        stopwatch.Start();
        var part1 = (string) type.GetMethod("Part1")?.Invoke(puzzle, Array.Empty<object?>())!;
        stopwatch.Stop();
        
        Console.WriteLine($"    Stage 1: {part1} (Completed in {stopwatch.ElapsedMilliseconds} ms - {stopwatch.ElapsedTicks} ticks)");
        
        stopwatch.Reset();
        stopwatch.Start();
        var part2 = (string) type.GetMethod("Part2")?.Invoke(puzzle, Array.Empty<object?>())!;
        stopwatch.Stop();
        Console.WriteLine($"    Stage 2: {part2} (Completed in {stopwatch.ElapsedMilliseconds} ms - {stopwatch.ElapsedTicks} ticks)");
    }
    
}