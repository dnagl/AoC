namespace AdventOfCode2023.Puzzle.Day12;

[PuzzleInformation(Name ="Hot Springs", Day = 12, Complete = true)]
public class Day12 : PuzzleBase<Day12>
{
    private long _part1;
    private long _part2;
    
    public Day12() : base("input.txt")
    {
        Run();
    }

    private void Run()
    {
        foreach (var s in Lines)
        {
            var s1 = s.Split(" ").ToArray();
            var rec = s1[0];
            var desc = s1[1].Split(",").Select(a => int.Parse(a)).ToArray();

            var rec2 = rec + "?" + rec + "?" + rec + "?" + rec + "?" + rec;
            var desc2 = desc.ToList();
            
            for (var _ = 0; _ < 4; _++)
                desc2.AddRange(desc);

            var result = new Dictionary<(int p, int c), long>();
            _part1 += GetPosition(rec, desc, 0, 0, result);
            
            result = new Dictionary<(int p, int c), long>();
            _part2 += GetPosition(rec2, desc2.ToArray(), 0, 0, result);
        }
    }
    
    public override string Part1() => _part1.ToString();

    public override string Part2() => _part2.ToString();

    private static long GetPosition(string rec, IReadOnlyList<int> desc, int offset, int current,IDictionary<(int p, int c), long> results )
    {
        var pb = 0L;
        var i = offset;
        var done = false;
        
        if (results.ContainsKey((offset, current)))
            pb = results[(offset, current)];
        else
        {
            while (!done && i <= rec.Length - desc[current])
            {
                var s = rec.Substring(i, desc[current]);
                var off1 = i + desc[current];
                if (s.Length == desc[current] && !s.Contains('.'))
                {
                    if (current == desc.Count - 1)
                    {
                        if (off1 == rec.Length || !rec[off1..].Contains('#'))
                            pb++;
                    }
                    else
                    {
                        if (off1 < rec.Length && (rec[off1] == '.' || rec[off1] == '?'))
                            pb += GetPosition(rec, desc, off1 + 1, current + 1, results);
                    }
                }
                if (rec[i] == '.' || rec[i] == '?')
                    i++;
                else
                    done = true;
            }
            results[(offset, current)] = pb;
        }
        return pb;
    }
    
}