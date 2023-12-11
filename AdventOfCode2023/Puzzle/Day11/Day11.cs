namespace AdventOfCode2023.Puzzle.Day11;

[PuzzleInformation(Name ="", Day = 11, Complete = true)]
public class Day11 : PuzzleBase<Day11>
{
    public Day11() : base("input.txt") { }

    public override string Part1() => Solve(2).ToString();

    public override string Part2() => Solve(1000000).ToString();

    private long Solve(int factor)
    {
        var lines = Lines.ToList();
        var (expandedRows, expandedCols) = GetExpandingRowsAndCols();
        
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

            int start;
            int end;

            if (galaxy1.Item1 < galaxy2.Item1)
            {
                start = galaxy1.Item1;
                end = galaxy2.Item1;
            }
            else
            {
                start = galaxy2.Item1;
                end = galaxy1.Item1;
            }
            
            var yPath = Enumerable.Range(start, end - start);
            var yDistance = yPath.Select(x => expandedRows.Contains(x) ? factor : 1).Sum();
            
            if (galaxy1.Item2 < galaxy2.Item2)
            {
                start = galaxy1.Item2;
                end = galaxy2.Item2;
            }
            else
            {
                start = galaxy2.Item2;
                end = galaxy1.Item2;
            }
            
            var xPath = Enumerable.Range(start, end - start);
            var xDistance = xPath.Select(x => expandedCols.Contains(x) ? factor : 1).Sum();
            
            galaxyPairs[pair.Key] = xDistance + yDistance;
        }

        var result = 0l;
        foreach (var pair in galaxyPairs)
            result += pair.Value;
        
        return result;
    }
    
    // (expanded lines | expanded rows)
    private (List<int>, List<int>) GetExpandingRowsAndCols()
    {
        var lines = Lines.ToArray();
        var result = (new List<int>(), new List<int>());

        for(var i = 0; i < lines.Length; i++)
            if(!lines[i].Contains('#')) result.Item1.Add(i);
        
        for(var i = 0; i < lines[0].Length; i++)
            if(!string.Join("", lines.Select(x => x[i])).Contains('#'))
               result.Item2.Add(i);
        
        return result;
    }
}