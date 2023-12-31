﻿namespace AdventOfCode2023.Puzzle.Day8;

[PuzzleInformation(Name ="Haunted Wasteland", Day = 8, Complete = true)]
public class Day8 : PuzzleBase<Day8>
{
    public Day8() : base("input.txt") { }
    
    public override string Part1()
    {
        var map = Map.Parse(Lines);
        
        var result = 0;
        var node = "AAA";
        while(node != "ZZZ")
            if (map.Directions[result++ % map.Directions.Count] == 'L')
                node = map.Nodes[node].Item1;
            else
                node = map.Nodes[node].Item2;

        return result.ToString();
    }

    public override string Part2()
    {
        var map = Map.Parse(Lines);

        var startingNodes = map.Nodes.Where(x => x.Key.EndsWith("A"));

        var leastCommonMultiple = 1l;

        foreach (var node in startingNodes)
        {
            var n = node.Key;
            var count = 0;
            while (!n.EndsWith("Z"))
            {
                var direction = map.Directions[count++ % map.Directions.Count];
                if (direction == 'L')
                    n = map.Nodes[n].Item1;
                else
                    n = map.Nodes[n].Item2;
            }
            leastCommonMultiple = LeastCommonMultiple(leastCommonMultiple, count);
        }


        return leastCommonMultiple.ToString();
    }
    
    private long LeastCommonMultiple(long a, long b)
    {
        var max = Math.Max(a, b);
        var min = Math.Min(a, b);

        for (long i = 1; i <= min; i++)
        {
            if (max * i % min == 0)
                return i * max;
        }
    
        return min;
    }
}