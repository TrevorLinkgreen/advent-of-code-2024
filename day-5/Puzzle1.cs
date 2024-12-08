using Spectre.Console;

namespace day_5;

public class Puzzle1
{
    public static void Run()
    {
        var badCounter = 0;
        var goodCounter = 0;
        var middleAccumulator = 0;

        var (rules, updates) = Common.ReadRulesAndUpdates();
        var (layout, table) = RenderLayout();




        AnsiConsole.Live(layout).Start(ctx =>
        {
            foreach (var update in updates)
            {
                var good = true;

                AddUpdateRowToTable(table, update);

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
                            ColorCell(table, i, update[i], "red");
                        }
                        else
                        {
                            ColorCell(table, i, update[i], "green");

                        }
                        ctx.Refresh();
                    }

                    table.UpdateCell(table.Rows.Count - 1, table.Columns.Count - 1, good ? "[green]true[/]" : "[red]false[/]");

                }

                if (good)
                {
                    goodCounter++;

                    var middle = (int)Math.Ceiling((decimal)update.Count / 2) - 1;
                    middleAccumulator += update.ElementAt(middle);
                    ColorCell(table, middle, update[middle], "aqua");
                    ctx.Refresh();
                }
                else
                {
                    badCounter++;
                }

                layout["Top"]["Left"].Update(new Markup($"Good: {goodCounter}\r\nBad: {badCounter}"));
                layout["Top"]["Right"].Update(new Markup($"Middle Values: {middleAccumulator}"));
            }

            ctx.Refresh();
        });


        Console.ReadLine();
        return;
    
        (Layout layout, Table table) RenderLayout()
        {

            var dataTable = new Table();
            var maxLength = updates.Max(u => u.Count);
            for (var i = 0; i < maxLength; i++)
                dataTable.AddColumn("");

            dataTable.AddColumn("Good?");
            dataTable.HideHeaders();


            var newLayout = new Layout("Root")
                .SplitRows(
                    new Layout("Top").SplitColumns(
                        new Layout("Left"),
                        new Layout("Right")),
                    new Layout("Bottom"));
            newLayout["Top"].Size = 5;
            newLayout["Bottom"].Update(dataTable);

            return (newLayout, dataTable);
        }

        void AddUpdateRowToTable(Table updateTable, IEnumerable<int> update)
        {
            updateTable.AddRow(update.Select(u => u.ToString()).ToArray());
            if (updateTable.Rows.Count > 15)
                updateTable.Rows.RemoveAt(0);
        }

        void ColorCell(Table updateTable, int colIndex, int cellValue, string color)
        {
            updateTable.UpdateCell(updateTable.Rows.Count - 1, colIndex, $"[{color}]{cellValue}[/]");
        }
    }
}