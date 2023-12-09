namespace AdventOfCode2023.Puzzle.Day6;

[PuzzleInformation(Name ="Wait For It", Day = 6, Complete = true)]
public class Day6 : IPuzzle
{
    private readonly string _filename = "input.txt";
    private IEnumerable<string> _lines;
    
    public void Setup()
    {
        _lines = Utils.Utils.ReadPuzzleLines(6, _filename);
    }

    public string Part1()
    {
        var races = new List<Race>();
        var racesCreated = false;
        foreach (var line in _lines)
        {
            var token = line.Split(" ").Where(x => x != "").ToArray();
            for (var i = 1; i < token.Length; i++)
            {
                if (!racesCreated) races.Add(new Race { Time = long.Parse(token[i]) });
                else races[i-1].Distance = long.Parse(token[i]);
            }

            racesCreated = true;
        }

        var result = -1;
    
        foreach (var race in races)
        {
            var results = new Dictionary<long, long>();
            for (var i = 0; i <= race.Time; i++)
            {
                var distance = (race.Time - i) * i;
                results.Add(i, distance);
            }
        
            var x = results.Count(x => x.Value > race.Distance);
            if (result == -1) result = x;
            else result *= x;
        }

        return result.ToString();
    }

    public string Part2()
    {
        var lines = _lines.ToList();
        var race = new Race
        {
            Time = long.Parse(lines[0].Replace("Time:", "").Replace(" ", "")),
            Distance = long.Parse(lines[1].Replace("Distance:", "").Replace(" ", ""))
        };
    
        var results = new Dictionary<long, long>();
        for (var i = 0; i <= race.Time; i++)
        {
            var distance = (race.Time - i) * i;
            results.Add(i, distance);
        }

        return results.Count(x => x.Value > race.Distance).ToString();
    }
}