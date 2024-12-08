namespace day_5;

public static class Common
{
    internal static (Dictionary<int, LineRule> lineRule, List<List<int>> updates) ReadRulesAndUpdates()
    {
        var lineRules = new Dictionary<int, LineRule>();
        var readUpdates = new List<List<int>>();

        var lines = File.ReadAllLines("input.txt");
        foreach (var line in lines)
        {
            if (line.Contains('|'))
            {
                var parts = line.Split("|").Select(int.Parse).ToArray();
                if (!lineRules.ContainsKey(parts[0])) lineRules.Add(parts[0], new LineRule());
                if (!lineRules.ContainsKey(parts[1])) lineRules.Add(parts[1], new LineRule());

                lineRules[parts[0]].After.Add(parts[1]);
                lineRules[parts[1]].Before.Add(parts[0]);
            }
            else if (line.Contains(','))
                readUpdates.Add(line.Split(',').Select(int.Parse).ToList());
        }

        return (lineRules, readUpdates);
    }
}