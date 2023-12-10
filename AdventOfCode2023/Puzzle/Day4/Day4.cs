namespace AdventOfCode2023.Puzzle.Day4;

[PuzzleInformation(Name ="Scratchcards", Day = 4, Complete = true)]
public class Day4 : IPuzzle
{
    private const string Filename = "input.txt";
    private IEnumerable<string> _lines;
    
    public void Setup()
    {
        _lines = Utils.Utils.ReadPuzzleLines(4, Filename);
    }

    public string Part1() => _lines.Select(Card.Parse).Sum(x => x.GetValue()).ToString();

    public string Part2()
    {
        var cards = _lines.Select(Card.Parse).ToList();
        var cardPile = cards.ToDictionary(x => x, x => 1);

        foreach (var entry in cardPile)
        {
            var matches = entry.Key.GetMatches();
            if(matches == 0) continue;

            var cardIndex = cards.IndexOf(entry.Key);
            for (var i = cardIndex + 1; i <= cardIndex + matches; i++)
            {
                for (var j = 0; j < entry.Value; j++)
                    cardPile[cards[i]]++;
            }
        }
    
        return cardPile.Sum(x => x.Value).ToString();
    }
}