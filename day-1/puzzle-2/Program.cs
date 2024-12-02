// See https://aka.ms/new-console-template for more information

var lines = File.ReadAllLines("input.txt").ToList();

var (list1, list2) = (
    lines.Select(l => int.Parse(l.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0].Trim())).OrderBy(l => l).ToList(),
    lines.Select(l => int.Parse(l.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1].Trim())).OrderBy(l => l).ToList()
);

var similarity = list1.Select(l1 => {
    return list2.Count(l2 => l2 == l1) * l1;
});

Console.WriteLine(similarity.Sum());