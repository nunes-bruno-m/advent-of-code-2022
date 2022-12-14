var puzzleOne = (bool useExample) =>
{
    var crane = new Crane();

    foreach (string line in System.IO.File.ReadLines(useExample ? @"InputExample.txt" : @"Input.txt"))
    {
        crane.ProcessLine(line);
    }

    crane.Reorganize(false);
    Console.WriteLine(crane.GetState());
    return crane.GetTops(); 
};

var puzzleTwo = (bool useExample) =>
{
    var crane = new Crane();

    foreach (string line in System.IO.File.ReadLines(useExample ? @"InputExample.txt" : @"Input.txt"))
    {
        crane.ProcessLine(line);
    }

    crane.Reorganize(true);
    Console.WriteLine(crane.GetState());
    return crane.GetTops();
};

Console.WriteLine("Puzzle one: " + puzzleOne(false));
Console.WriteLine("Puzzle two: " + puzzleTwo(false));