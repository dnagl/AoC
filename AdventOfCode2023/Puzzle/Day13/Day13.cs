using System.Numerics;

namespace AdventOfCode2023.Puzzle.Day13;

[PuzzleInformation(Name ="", Day = 13, Complete = true)]
public class Day13 : PuzzleBase<Day13>
{
    private Complex _right = 1;
    private Complex _down = Complex.ImaginaryOne;
    private Complex _ortho(Complex dir) => dir == _right ? _down : _right;
    
    public Day13() : base("input.txt")
    {
    }
    
    public override string Part1() => Solve(string.Join("\n", Lines), 0).ToString();
    public override string Part2() => Solve(string.Join("\n", Lines), 1).ToString();

    private double Solve(string input, int allowedSmudges) => (
        from block in input.Split("\n\n")
        let map = ParseMap(block)
        select GetScore(map, allowedSmudges)).Sum();

    private double GetScore(Dictionary<Complex, char> map, int allowedSmudges) => (
        from dir in new Complex[] { _right, _down }
        from mirror in Positions(map, dir, dir)
        where FindSmudges(map, mirror, dir) == allowedSmudges
        select mirror.Real + 100 * mirror.Imaginary).First();
    
    private int FindSmudges(Dictionary<Complex, char> map, Complex mirror, Complex rayDir) => (
        from ray0 in Positions(map, mirror, _ortho(rayDir))
        let rayA = Positions(map, ray0, rayDir)
        let rayB = Positions(map, ray0 - rayDir, -rayDir)
        select Enumerable.Zip(rayA, rayB).Count(p => map[p.First] != map[p.Second])).Sum();
    
    private IEnumerable<Complex> Positions(Dictionary<Complex, char> map, Complex start, Complex dir) {
        for (var pos = start; map.ContainsKey(pos); pos += dir) 
            yield return pos; 
    }

    private Dictionary<Complex, char> ParseMap(string input) {
        var rows = input.Split("\n");
        return (
            from row in Enumerable.Range(0, rows.Length)
            from col in Enumerable.Range(0, rows[0].Length)
            let pos = new Complex(col, row)
            let cell = rows[row][col]
            select new KeyValuePair<Complex, char>(pos, cell)
        ).ToDictionary(x => x.Key, x => x.Value);
    }
    
}