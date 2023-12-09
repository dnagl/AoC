namespace AdventOfCode2023.Puzzle.Day4;

public class Card
{
    public int Id { get; set; }
    public List<int> WinningNumbers { get; set; } = new();
    public List<int> Numbers { get; set; } = new();

    public int GetMatches() => WinningNumbers.Intersect(Numbers).Count();

    public int GetValue()
    {
        var matches = GetMatches();
        if (matches <= 1) return matches;

        return Convert.ToInt32(Math.Pow(2, matches - 1));
    }
    
    public static Card Parse(string s)
    {
        return new Card
        {
            Id = int.Parse(s.Split(":").First().Replace("Card ", "")),
            WinningNumbers = s.Split(":").Last().Split("|").First().Trim().Split(" ").Where(x => x != "").Select(int.Parse).ToList(),
            Numbers = s.Split(":").Last().Split("|").Last().Trim().Split(" ").Where(x => x != "").Select(int.Parse).ToList()
        };
    }

}