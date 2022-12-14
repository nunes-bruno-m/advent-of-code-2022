
using System.Diagnostics;
using System.IO;
using System.Linq;

var puzzleOne = (bool useExample) =>
{
    var processor = new ElfCPU();
    foreach (string line in System.IO.File.ReadLines(useExample ? @"InputLargerExample.txt" : @"Input.txt"))
    {
        processor.Process(line);
    }

    double totalStrength = 0;
    for(var i =20; i <= 220; i+=40)
    {
        totalStrength+= processor.GetCycleStrength(i);
        Console.WriteLine($"Cycle: {i} Strength: {processor.GetCycleStrength(i)} total: {totalStrength}");
    }

    return totalStrength;
};

var printer = (ElfGraphicCPU processor) =>
{
    var list = processor.CycleResults.Values.ToList();

    Console.WriteLine();
    for (var i = 1; i <= list.Count; i++)
    {
        if (i % 40 == 0)
        {
            Console.WriteLine();
        }
        Console.Write(list[i - 1] ? "#" : ".");
    }
    Console.WriteLine();
};

var puzzleTwo = (bool useExample) =>
{
    var processor = new ElfGraphicCPU();
    foreach (string line in System.IO.File.ReadLines(useExample ? @"InputLargerExample.txt" : @"Input.txt"))
    {
        processor.Process(line);
    }   

    return 0;
};
//Console.WriteLine("Puzzle one: " + puzzleOne(false));
Console.WriteLine("Puzzle two: " + puzzleTwo(false));