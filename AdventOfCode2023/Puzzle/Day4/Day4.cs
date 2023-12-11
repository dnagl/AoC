namespace AdventOfCode2023.Puzzle.Day4;

[PuzzleInformation(Name ="Scratchcards", Day = 4, Complete = true)]
public class Day4 : PuzzleBase<Day4>
{
    public Day4() : base("input.txt") { }

    public override string Part1() => Lines.Select(Card.Parse).Sum(x => x.GetValue()).ToString();

    public override string Part2()
    {
        var cards = Lines.Select(Card.Parse).ToList();
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