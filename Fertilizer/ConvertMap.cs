namespace Fertilizer;

public class ConvertMap
{
    private List<Range> Ranges { get; set; } = new();

    public long ProcessMap(long seedLocation)
    {
        foreach (var range in Ranges.Where(range => seedLocation >= range.SourceStart && seedLocation < range.SourceStart + range.Length))
            return range.DestinationStart + (seedLocation - range.SourceStart);

        return seedLocation;
    }

    private static ConvertMap Parse(IEnumerable<string> lines)
    {
        var tmp = lines.ToArray();
        var convertMap = new ConvertMap();
        
        for(var i = 1; i < tmp.Length; i++) convertMap.Ranges.Add(Range.Parse(tmp[i]));
        return convertMap;
    }

    public static List<ConvertMap> ParseMaps(IEnumerable<string> lines)
    {
        var maps = new List<ConvertMap>();

        var batch = new List<string>();
        var l = lines.ToList();
        for (var i = 2; i < l.Count; i++)
        {
            if (i + 1 == l.Count)
            {
                batch.Add(l[i]);
                maps.Add(Parse(batch));
                continue;
            }
        
            if (l[i].Trim() == "")
            {
                maps.Add(Parse(batch));
                batch = new List<string>();
                continue;
            }
        
            batch.Add(l[i]);
        }
        
        return maps;
    }
}

