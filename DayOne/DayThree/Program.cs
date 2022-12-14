var getPriority = (char item) =>
{
    if (item >= 65 && item <= 90)
    {
        return item - (65 - 27);
    }
    else
    {
        return item - (96);
    }
};

var puzzleOne = (bool useExample) =>
{
    if (useExample)
        Console.WriteLine($"{getPriority('a')} {getPriority('z')} {getPriority('A')} {getPriority('Z')}");

    int totalScore = 0;

    foreach (string line in System.IO.File.ReadLines(useExample? @"InputExample.txt" : @"Input.txt"))
    {
        var bagSize = line.Length / 2;
        var leftBag = line.Substring(0, bagSize);
        var rightBag = line.Substring(line.Length / 2);

        var l = leftBag.ToArray().Distinct().ToList();
        var r = rightBag.ToArray().Distinct().ToList();

        var sharedItem = l.Intersect(r).First();

        int charNumber = getPriority(sharedItem);

        totalScore += charNumber;

        Console.WriteLine($"{sharedItem} {charNumber}");
    }
    return totalScore;
};


var puzzleTwo = (bool useExample) =>
{
    int totalScore = 0;
    int lineCount = 0;
    List<char> groupUniques = new List<char>();

    foreach (string line in System.IO.File.ReadLines(useExample ? @"InputExample.txt" : @"Input.txt"))
    {
        lineCount++;

        groupUniques.AddRange(line.ToArray().Distinct());
        

        if(lineCount % 3 == 0)
        {
            Console.WriteLine($"GroupUniques {string.Join("", groupUniques)}");

            var list = groupUniques.GroupBy(x => x).ToList();
            var badge = list.Where(x => x.Count() == 3).First().Key;

            totalScore += getPriority(badge);
            Console.WriteLine($"{lineCount} {badge}");
            groupUniques.Clear();            
        }

    }
    return totalScore;
};

Console.WriteLine("Puzzle one: " + puzzleOne(false));
Console.WriteLine("Puzzle two: " + puzzleTwo(false));