// See https://aka.ms/new-console-template for more information


using day_5;
using Spectre.Console;


var line = "";
while (line is not "1" && line != "2")
{
    AnsiConsole.WriteLine("Enter the puzzle number you want to run (1-2)");
    line = Console.ReadLine();
}

switch (line)
{
    case "1":
        Puzzle1.Run();
        break;
    case "2":
        Puzzle2.Run();
        break;
}

Console.ReadLine();



