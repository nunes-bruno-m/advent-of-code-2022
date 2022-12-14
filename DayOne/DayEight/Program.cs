
using System.Collections;
using System.IO;
using System.Linq;

var puzzleOne = (bool useExample) =>
{
    var lines = System.IO.File.ReadAllLines(useExample ? @"InputExample.txt" : @"Input.txt");

    double totalVisible = 0;

    var smallerList = new HashSet<string>();

    for(var y = 0; y< lines.Length; y++)
    {
        var heighestLeft = -1;
        var x = 0;
        for (; x < lines[y].Length ; x++ )
        {
            if(heighestLeft < lines[y][x])
            {
                heighestLeft = lines[y][x];
                smallerList.Add($"{y}:{x}");
            }
        }

        var heighestRight = -1;
        for (var x2 = lines[y].Length - 1; x2 > 0; x2--)
        {
            if (heighestRight < lines[y][x2])
            {
                heighestRight = lines[y][x2];
                smallerList.Add($"{y}:{x2}");
            }
            else if(heighestRight == heighestLeft)
            {
                break;
            }
        }
    }
    for (var x = 0; x < lines[0].Length; x++)
    {
        var heighestTop = -1;
        var y = 0;
        for (; y < lines.Length; y++)
        {
            if (heighestTop < lines[y][x])
            {
                heighestTop = lines[y][x];
                smallerList.Add($"{y}:{x}");
            }
        }

        var heighestBottom = -1;
        for (var y2 = lines.Length - 1; y2 > 0; y2--)
        {
            if (heighestBottom < lines[y2][x])
            {
                heighestBottom = lines[y2][x];
                smallerList.Add($"{y2}:{x}");
                Console.WriteLine($"{y2}:{x}");
            }
            else if (heighestBottom == heighestTop)
            {
                break;
            }
        }
    }

    for (var y = 0; y < lines.Length; y++)
    {
        for(var x = 0; x < lines[y].Length; x++)
        {
            if(smallerList.Contains($"{y}:{x}"))
            {
                Console.Write("x");
            } else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }

    return smallerList.Count;
};


var puzzleTwo = (bool useExample) =>
{
    var lines = System.IO.File.ReadAllLines(useExample ? @"InputExample.txt" : @"Input.txt");

    var map = new ElfMap(lines);
    return map.Process();
};

//Console.WriteLine("Puzzle one: " + puzzleOne(false));
Console.WriteLine("Puzzle two: " + puzzleTwo(false));