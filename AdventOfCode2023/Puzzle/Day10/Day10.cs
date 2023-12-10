using System.Data;
using System.Numerics;

namespace AdventOfCode2023.Puzzle.Day10;

[PuzzleInformation(Name ="Pipe Maze", Day = 10, Complete = true)]
public class Day10 : IPuzzle
{
    private readonly string _filename = "input.txt";
    private IEnumerable<string> _lines;

    private Dictionary<Complex, char> _map = new();

    static readonly Complex Up = -Complex.ImaginaryOne;
    static readonly Complex Down = Complex.ImaginaryOne;
    static readonly Complex Right = Complex.One;
    static readonly Complex Left = -Complex.One;
    static readonly Complex[] Directions = { Up, Right, Down, Left };
    
    public void Setup()
    {
        _lines = Utils.Utils.ReadPuzzleLines(10, _filename).ToArray();
        var lines = _lines.ToArray();

        for (var i = 0; i < lines.Length; i++)
            for (var j = 0; j < lines[i].Length; j++)
                _map[new Complex(j, i)] = lines[i][j];
    }

    public string Part1()
    {
        var loop = LoopPositions();
        return (loop.Count / 2).ToString();
    }

    public string Part2()
    {
        throw new NotImplementedException();
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

            var directionsOut = DirectionsOut(_map[current]);
            direction = DirectionsOut(_map[current]).Single(x => x != -direction);
        }
        
        return result;
    }

    private Complex[] DirectionsIn(char c) => DirectionsOut(c).Select(c => -c).ToArray();

    private Complex[] DirectionsOut(char c)
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