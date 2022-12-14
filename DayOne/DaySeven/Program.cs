
using System.IO;
using System.Linq;

var puzzleOne = (bool useExample) =>
{
    var os = new OS();
    foreach (string line in System.IO.File.ReadLines(useExample ? @"InputExample.txt" : @"Input.txt"))
    {
        os.ProcessLine(line);
    }

    var directories = os.GetAllDirectoriesSize(os.Directories.First());

    return directories.Where(x => x <= 100000).Sum(x => x);
};

var puzzleTwo = (bool useExample) =>
{
    var os = new OS();
    foreach (string line in System.IO.File.ReadLines(useExample ? @"InputExample.txt" : @"Input.txt"))
    {
        os.ProcessLine(line);
    }

    var directories = os.GetAllDirectoriesSize(os.Directories.First());
    var freeSpace = os.DiskSize - os.UsedDiskSpace;
    var sizeNeeded = 30000000 - freeSpace;

    Console.WriteLine($"Size needed {sizeNeeded}");
    Console.WriteLine($"Disk total size: {os.DiskSize}\nUsed disk space: {os.UsedDiskSpace}\nDisk total free space: {freeSpace}");
    directories.Sort();
    return directories.First(x=> x >= sizeNeeded);

};

Console.WriteLine("Puzzle one: " + puzzleOne(false));
Console.WriteLine("Puzzle two: " + puzzleTwo(false));