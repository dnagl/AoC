namespace AdventOfCode2023.Puzzle.Day7;

public class CardSort : IComparer<string>
{
    private readonly Dictionary<char, int> _valueMapping;
    
    public CardSort(int wildcardValue = 11)
    {
        _valueMapping = new Dictionary<char, int>
        {
            {'T', 10},
            {'J', wildcardValue},
            {'Q', 12},
            {'K', 13},
            {'A', 14}
        };
    }

    public int Compare(char x, char y)
    {
        var a = _valueMapping.TryGetValue(x, out var valX) ? valX : int.Parse(x.ToString());
        var b = _valueMapping.TryGetValue(y, out var valY) ? valY : int.Parse(x.ToString());

        return a.CompareTo(b);
    }
    
    public int Compare(string? x, string? y)
    {
        var i = 0;
        var compareValue = Compare(x[i], y[i]);
        while (compareValue == 0 && i < x.Length - 1)
            compareValue = Compare(x[++i], y[i]);
        return compareValue;
    }
}