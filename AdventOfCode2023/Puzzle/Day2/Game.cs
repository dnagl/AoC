namespace AdventOfCode2023.Puzzle.Day2;

public class Game
{
    
    public int Id { get; set; }
    public List<Draft> Drafts { get; set; } = new();

    public Draft GetMinimumCubeSet()
    {
        return new Draft
        {
            Red = Drafts.Max(x => x.Red),
            Green = Drafts.Max(x => x.Green),
            Blue = Drafts.Max(x => x.Blue),
        };
    }
    
    public static Game Parse(string input)
    {
        var game = new Game();
        var parts = input.Split(":");

        game.Id = int.Parse(parts[0].Split(" ")[1]);
        foreach (var s in parts[1].Split(";"))
        {
            var draft = new Draft();

            foreach (var part in s.Split(","))
            {
                var token = part.Trim().Split(" ");
                switch (token[1].ToLower())
                {
                    case "red":
                        draft.Red = int.Parse(token[0]);
                        break;
                    case "blue":
                        draft.Blue = int.Parse(token[0]);
                        break;
                    case "green":
                        draft.Green = int.Parse(token[0]);
                        break;
                }
            }
            game.Drafts.Add(draft);
        }

        return game;
    }
    
}