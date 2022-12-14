using DayNine;
using System.Linq;

var print = (Coordinate head, Coordinate tail, string command) =>
{
    Console.WriteLine($"===== {command} {head.x}:{head.y} {tail.x}:{tail.y}  C:{tail.PositionsLog.Count()}====");
    for (var y = Math.Max(Math.Max(head.y, tail.y), 5); y >= 0; y-- )
    {
        for(var x =0; x<= Math.Max(Math.Max(head.x, tail.x), 6); x++ )
        {
            if (head.x == x && head.y == y)
            {
                Console.Write("H");
            }
            else if (tail.x == x && tail.y == y)
            {
                Console.Write("T");
            }
            else if (x == 0 && y == 0)
            {
                Console.Write("s");
            }
            else if(tail.PositionsLog.Contains($"{x}:{y}"))
            {
                Console.Write("x");
            }
            else { 
                Console.Write(".");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    Console.ReadLine();
};

var printLogs = (Coordinate tail) =>
{

    foreach(var log in tail.PositionsLog)
    {
        Console.WriteLine(log);

    }
};

var puzzleOne = (bool useExample) =>
{
    var lines = System.IO.File.ReadAllLines(useExample ? @"InputExample.txt" : @"Input.txt");

    Coordinate tail = new Coordinate (0, 0);
    Coordinate head = new Coordinate (0, 0);
    foreach (var line in lines)
    {
        var action = line.Split(' ');
        var moveDistance = Int32.Parse(action[1]);

        Coordinate movement = new Coordinate(0, 0);

        switch(action[0])
        {
            case "R":
                movement.x = moveDistance;
                break;
            case "U":
                movement.y = moveDistance;
                break;
            case "D":
                movement.y = -moveDistance;
                break;
            case "L":
                movement.x = -moveDistance;
            break;
        }
        head.Move(movement);
        tail.Follow(head, movement);

        //print(head, tail, line);
    }

    //printLogs(tail);

    return tail.PositionsLog.Count();
};

var printComplex = (Coordinate head, Coordinate tail, string command, LinkedList<Coordinate> list, int idx) =>
{    
    Console.WriteLine($"===== {command} {head.x}:{head.y} {tail.x}:{tail.y}  C:{tail.PositionsLog.Count()} idx: {idx}====");
        
    for (var y = Math.Max(Math.Max(head.y, tail.y), 20); y >= -480; y--)
    {
        for (var x = -180; x <= Math.Max(Math.Max(head.x, tail.x), 20); x++)
        {            
            if (head.x == x && head.y == y)
            {
                Console.Write("H");
            }
            else if (x == 0 && y == 0)
            {
                Console.Write("s");
            }
            else
            {
                var currentNode = list.First;
                var knotHere = 0;
                for (var i = 1; i <= list.Count; i++)
                {
                    if (currentNode.Value.PositionsLog.Last().Equals($"{x}:{y}"))
                    {
                        knotHere = i;
                        break;
                    }

                    currentNode = currentNode.Next;
                }
                if(knotHere>0)
                {
                    Console.Write(knotHere == 9 ? "T":knotHere);
                }
                else if (tail.PositionsLog.Contains($"{x}:{y}"))
                {
                    Console.Write("x");
                }
                else
                {
                    Console.Write(".");
                }

            }
            
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    //Console.ReadLine();
};

var puzzleTwo = (bool useExample) =>
{
    var lines = System.IO.File.ReadAllLines(useExample ? @"InputLargerExample.txt" : @"Input.txt");

    Coordinate tail = new Coordinate(0, 0, true);
    Coordinate head = new Coordinate(0, 0);
    LinkedList<Coordinate> list = new LinkedList<Coordinate>();
    for(var i=0; i < 8; i++)
    {
        list.AddLast(new Coordinate(0, 0));
    }
    list.AddLast(tail);

    foreach (var line in lines)
    {
        var action = line.Split(' ');
        var moveDistance = int.Parse(action[1]);

        Coordinate movement = new Coordinate(0, 0);
        switch (action[0])
        {
            case "R":
                movement.x = 1;
                break;
            case "U":
                movement.y = 1;
                break;
            case "D":
                movement.y = -1;
                break;
            case "L":
                movement.x = -1;
                break;
        }

        while(moveDistance > 0)
        {
            head.Move(movement);

            var currentNode = list.First;
        
            while ((currentNode != null))
            {
                if(list.First == currentNode)
                {
                    currentNode.Value.Follow(head, movement);
                } else
                {
                    var nextMovement = new Coordinate(currentNode.Previous.Value.x - currentNode.Value.x, currentNode.Previous.Value.y - currentNode.Value.y);

                    if(nextMovement.x != 0)
                    {
                        nextMovement.x += nextMovement.x > 0 ? -1 : 1;
                    } 
                    
                    if (nextMovement.y != 0)
                    {
                        nextMovement.y += nextMovement.y > 0 ? -1 : 1;
                    }

                    if(nextMovement.x != 0 || nextMovement.y != 0)
                    {
                        currentNode.Value.Follow(currentNode.Previous.Value, nextMovement);
                    }
                }
                currentNode = currentNode.Next;

            }
            moveDistance--;

        }
    }
    Console.ReadLine();

    return tail.PositionsLog.Distinct().Count();
};

var puzzleTwoScreen = (bool useExample) =>
{
    var lines = System.IO.File.ReadAllLines(useExample ? @"InputLargerExample.txt" : @"Input.txt");

    Coordinate tail = new Coordinate(0, 0, true);
    Coordinate head = new Coordinate(0, 0);
    LinkedList<Coordinate> list = new LinkedList<Coordinate>();

    Screen screen = new Screen();

    for (var i = 0; i < 8; i++)
    {
        list.AddLast(new Coordinate(0, 0));
    }
    list.AddLast(tail);
    foreach (var line in lines)
    {

        var action = line.Split(' ');
        var moveDistance = int.Parse(action[1]);

        Coordinate movement = new Coordinate(0, 0);
        switch (action[0])
        {
            case "R":
                movement.x = 1;
                break;
            case "U":
                movement.y = 1;
                break;
            case "D":
                movement.y = -1;
                break;
            case "L":
                movement.x = -1;
                break;
        }

        while (moveDistance > 0)
        {
            head.Move(movement);

            var currentNode = list.First;

            while ((currentNode != null))
            {
                if (list.First == currentNode)
                {
                    currentNode.Value.Follow(head, movement);
                }
                else
                {
                    var nextMovement = new Coordinate(currentNode.Previous.Value.x - currentNode.Value.x, currentNode.Previous.Value.y - currentNode.Value.y);

                    if (nextMovement.x != 0)
                    {
                        nextMovement.x += nextMovement.x > 0 ? -1 : 1;
                    }

                    if (nextMovement.y != 0)
                    {
                        nextMovement.y += nextMovement.y > 0 ? -1 : 1;
                    }

                    if (nextMovement.x != 0 || nextMovement.y != 0)
                    {
                        currentNode.Value.Follow(currentNode.Previous.Value, nextMovement);
                    }
                }
                currentNode = currentNode.Next;

            }
            moveDistance--;
            
        }
        screen.Print(head, tail, line, list);
    }
    Console.ReadLine();

    return tail.PositionsLog.Distinct().Count();
};



//Console.WriteLine("Puzzle one: " + puzzleOne(true));
//Console.WriteLine("Puzzle two: " + puzzleTwo(false));
Console.WriteLine("Puzzle two: " + puzzleTwoScreen(false));