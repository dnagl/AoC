using Scratchcards;

const string inputFile = "input.txt";

Stage1(inputFile);
Stage2(inputFile);
return;

void Stage1(string inputFile)
{
    var result = File.ReadLines(inputFile)
        .Select(Card.Parse)
        .Sum(x => x.GetValue());
    Console.WriteLine($"Stage 1: {result}");
}

void Stage2(string inputFile)
{
    var cards = File.ReadLines(inputFile).Select(Card.Parse).ToList();
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
    
    var result = cardPile.Sum(x => x.Value);
    Console.WriteLine($"Stage 1: {result}");
}