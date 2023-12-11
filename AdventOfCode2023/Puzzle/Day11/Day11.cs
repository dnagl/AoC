using System.Diagnostics;

namespace AdventOfCode2023.Puzzle.Day11;

[PuzzleInformation(Name ="", Day = 11, Complete = true)]
public class Day11 : IPuzzle
{
    private const string Filename = "input_test.txt";
    private IEnumerable<string> _lines;
    
    public void Setup()
    {
        _lines = Utils.Utils.ReadPuzzleLines(11, Filename);
    }

    public string Part1()
    {
        var lines = ExpandMap();
        
        var galaxyPositions = new Dictionary<int, Tuple<int, int>>();

        for (var i = 0; i < lines.Count(); i++)
            for (var j = 0; j < lines[i].Length; j++)
                if(lines[i][j] == '#')
                    galaxyPositions.Add(galaxyPositions.Count(), new Tuple<int, int>(i, j));

        var galaxyPairs = new Dictionary<Tuple<int, int>, int>();
        
        for (var i = 0; i < galaxyPositions.Count; i++)
            for (var j = i + 1; j < galaxyPositions.Count(); j++)
                galaxyPairs.Add(new Tuple<int, int>(i, j), -1);

        foreach (var pair in galaxyPairs)
        {
            var galaxy1 = galaxyPositions[pair.Key.Item1];
            var galaxy2 = galaxyPositions[pair.Key.Item2];

            var xDistance = galaxy1.Item1 < galaxy2.Item1 ? Math.Abs(galaxy2.Item1 - galaxy1.Item1) : Math.Abs(galaxy1.Item1 - galaxy2.Item1);
            var yDistance = galaxy1.Item2 < galaxy2.Item2 ? Math.Abs(galaxy2.Item2 - galaxy1.Item2) : Math.Abs(galaxy1.Item2 - galaxy2.Item2);
            galaxyPairs[pair.Key] = xDistance + yDistance;
        }
        
        return galaxyPairs.Values.Sum().ToString();
    }

    public string Part2()
    {
        return "";
    }
    
    private List<string> ExpandMap(int factor = 1)
    {
        var lines = _lines.ToList();

        var columns = new List<string>();

        for (var i = 0; i < lines[0].Length; i++)
            columns.Add(string.Join("", lines.Select(x => x[i])));

        var columnsExpanded = new List<string>();
        for (var i = 0; i < columns.Count; i++)
        {
            if (!columns[i].Contains("#"))
                for(var _ = 0; _ < factor; _++)
                    columnsExpanded.Add(columns[i]);
            columnsExpanded.Add(columns[i]);
        }
        
        var rows = new List<string>();
        for (var i = 0; i < columnsExpanded[0].Length; i++)
            rows.Add(string.Join("", columnsExpanded.Select(x => x[i])));
        
        var rowsExpanded = new List<string>();
        for (var i = 0; i < rows.Count; i++)
        {
            if(!rows[i].Contains("#"))
                for(var _ = 0; _ < factor; _++)
                    rowsExpanded.Add(rows[i]);
            rowsExpanded.Add(rows[i]);
        }

        return rowsExpanded;
    }
}