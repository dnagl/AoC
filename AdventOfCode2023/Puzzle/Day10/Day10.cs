using System.Numerics;

namespace AdventOfCode2023.Puzzle.Day10;

[PuzzleInformation(Name ="Pipe Maze", Day = 10, Complete = true)]
public class Day10 : IPuzzle
{
    private static readonly Complex Up = -Complex.ImaginaryOne;
    private static readonly Complex Down = Complex.ImaginaryOne;
    private static readonly Complex Right = Complex.One;
    private static readonly Complex Left = -Complex.One;
    private static readonly Complex[] Directions = { Up, Right, Down, Left };

    private const string Filename = "input.txt";
    private IEnumerable<string> _lines;

    private Dictionary<Complex, char> _map = new();

    public void Setup()
    {
        _lines = Utils.Utils.ReadPuzzleLines(10, Filename).ToArray();
        var lines = _lines.ToArray();

        for (var i = 0; i < lines.Length; i++)
            for (var j = 0; j < lines[i].Length; j++)
                _map[new Complex(j, i)] = lines[i][j];
    }

    public string Part1() => (LoopPositions().Count / 2).ToString();

    public string Part2()
    {
        var loop = LoopPositions();

        var map = (
                from entry in _map
                let position = entry.Key
                let cell = loop.Contains(position) ? entry.Value : '.'
                select (position, cell))
            .ToDictionary(x => x.position, x => x.cell);

        return (map.Keys.Count(position => Inside(map, position))).ToString();
    }

    private HashSet<Complex> LoopPositions()
    {
        var current = _map.Keys.Single(x => _map[x] == 'S');
        var result = new HashSet<Complex>();
        var direction = Directions.First(x => DirectionsIn(_map[current + x]).Contains(x));

        while (!result.Contains(current))
        {
            result.Add(current);
            current += direction;
            if (_map[current] == 'S')
                break;

            direction = DirectionsOut(_map[current]).Single(x => x != -direction);
        }
        
        return result;
    }

    private bool Inside(Dictionary<Complex, char> map, Complex position)
    {
        if (map[position] != '.')
            return false;

        var result = false;
        position--;
        while (map.ContainsKey(position))
        {
            if ("SJL|".Contains(map[position]))
                result = !result;
            position--;
        }
        return result;
    }
    
    private static IEnumerable<Complex> DirectionsIn(char c) => DirectionsOut(c).Select(c => -c).ToArray();

    private static IEnumerable<Complex> DirectionsOut(char c)
    {
        return c switch
        {
            '7' => new[] { Left, Down },
            'F' => new[] { Right, Down },
            'L' => new[] { Up, Right },
            'J' => new[] { Up, Left },
            '|' => new[] { Up, Down },
            '-' => new[] { Left, Right },
            'S' => new[] { Up, Down, Left, Right },
            _ => Array.Empty<Complex>()
        };
    }
}