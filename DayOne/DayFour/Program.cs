var isFullyOverlapping = ((int, int) leftPair, (int, int) rightPair) =>
{
    return leftPair.Item1 >= rightPair.Item1 && leftPair.Item2 <= rightPair.Item2;
};

var getPairTuple = (string pair) =>
{
    var intPair = pair.Split('-').Select(x => Int32.Parse(x)).ToList();
    return (intPair[0], intPair[1]);
};

var puzzleOne = (bool useExample) =>
{
    int totalFullOverlaps = 0;

    foreach (string line in System.IO.File.ReadLines(useExample ? @"InputExample.txt" : @"Input.txt"))
    {
        var pair = new Pair(line);

        totalFullOverlaps += pair.AreFullyOverlapping() ? 1 : 0;

    }
    return totalFullOverlaps;
};


var puzzleTwo = (bool useExample) =>
{
    int totalFullOverlaps = 0;

    foreach (string line in System.IO.File.ReadLines(useExample ? @"InputExample.txt" : @"Input.txt"))
    {
        var pair = new Pair(line);

        totalFullOverlaps += pair.ArePartiallyOrFullyOverlapping() ? 1 : 0;

    }
    return totalFullOverlaps;
};

Console.WriteLine("Puzzle one: " + puzzleOne(false));
Console.WriteLine("Puzzle two: " + puzzleTwo(false));