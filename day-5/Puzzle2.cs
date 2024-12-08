using Spectre.Console;

namespace day_5;

public class Puzzle2
{
    public static void Run()
    {
        var middleAccumulator = 0;

        var (rules, updates) = Common.ReadRulesAndUpdates();
        var badRows = new List<List<int>>();


        foreach (var update in updates)
        {
            var good = true;

            // -1 because we don't care about the last one
            for (var i = 0; i < update.Count - 1; i++)
            {
                if (rules.TryGetValue(update[i], out var rule))
                {
                    var after = update[(i + 1)..];
                    var before = update[..i];
                    if (after.Any(a => rule.Before.Contains(a))
                        || before.Any(b => rule.After.Contains(b)))
                    {
                        good = false;
                    }
                }
            }

            if (!good)
            {
                badRows.Add(update);
            }
        }

        foreach (var update in badRows)
        {
            AnsiConsole.Write(new Markup(string.Join(',', update.Select(u => $"[red]{u}[/]")) + Environment.NewLine));


            update.Sort((x, y) =>
            {
                if (rules.TryGetValue(x, out var xRule))
                {
                    if (xRule.After.Contains(y))
                        return -1;
                    if (xRule.Before.Contains(y))
                        return 1;
                }

                if (rules.TryGetValue(y, out var yRule))
                {
                    if (yRule.Before.Contains(x))
                        return 1;
                    if (yRule.After.Contains(y))
                        return -1;
                }

                return 0;
            });


            var middle = (int)Math.Ceiling((decimal)update.Count / 2) - 1;
            AnsiConsole.Write(new Markup("\t" + string.Join(',', update.Select((u, idx) =>
                                         {
                                             if (idx == middle)
                                                 return $"[aqua]{u}[/]";

                                             return $"[green]{u}[/]";
                                         })) +
                                         Environment.NewLine));
            Thread.Sleep(100);


            middleAccumulator += update.ElementAt(middle);
        }

        Console.WriteLine("Middle Accumulator: " + middleAccumulator);



        Console.ReadLine();



    }
}