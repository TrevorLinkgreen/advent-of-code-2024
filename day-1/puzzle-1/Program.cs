// See https://aka.ms/new-console-template for more information
using System.Linq;

Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines("input.txt").ToList();

var (list1, list2) = (
    lines.Select(l => int.Parse(l.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0].Trim())).OrderBy(l => l).ToList(),
    lines.Select(l => int.Parse(l.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1].Trim())).OrderBy(l => l).ToList()
);

var distance = list1.Select((l1, idx) =>
{
    return Math.Abs(l1 - list2.ElementAt(idx));
});

Console.WriteLine(distance.Sum());