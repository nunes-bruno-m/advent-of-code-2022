var puzzleOne = (bool useExample) =>
{
    var game = new Game();
    var lines = System.IO.File.ReadLines(useExample ? @"InputExample.txt" : @"Input.txt");
    game.Load(lines);

    for (var i = 1; i <= 20; i++)
    {
        game.StartRound();

        Console.WriteLine("After round " + i);
        foreach (var monkey in game.Monkeys)
        {
            Console.WriteLine($"Monkey {monkey.Id}: {string.Join(", ", monkey.StartingItems.ToList())}");
        }
    }


    var inpsections = game.Monkeys.Select(x => x.Inspections);

    var sorted = inpsections.OrderByDescending(x => x).ToList();

    return sorted[0] * sorted[1];
};

var puzzleTwoOld = (bool useExample) =>
{
    var game = new Game();
    var lines = System.IO.File.ReadLines(useExample ? @"InputExample.txt" : @"Input.txt");
    game.Load(lines, 1);


    var printIndexes = new int[]
    {
        1, 20, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000
    };

    for (var i = 1; i <= 10000; i++)
    {
        game.StartRound();


        if (printIndexes.Contains(i))
        {
            Console.WriteLine("===== After round " + i);
            foreach (var monkey in game.Monkeys)
            {
                Console.WriteLine($"Monkey {monkey.Id} inpsected items {monkey.Inspections} times");
            }
        }
    }


    var inpsections = game.Monkeys.Select(x => x.Inspections);

    var sorted = inpsections.OrderByDescending(x => x).ToList();

    return sorted[0] * sorted[1];
};

var puzzleTwo = (bool useExample) =>
{
    var lines = System.IO.File.ReadLines(useExample ? @"InputExample.txt" : @"Input.txt");

    var game = new Game();
    game.Load(lines, 1);


    var printIndexes = new int[]
    {
       1, 20, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000
    };

    for (var i = 1; i <= 10000; i++)
    {
        if (i == 20)
        {
            Console.WriteLine("On round " + i);
            foreach (var monkey in game.Monkeys)
            {
                Console.WriteLine($"Monkey {monkey.Id}: {string.Join(", ", monkey.StartingItems.ToList())}");
            }

            if (printIndexes.Contains(i))
            {
                Console.WriteLine("===== On round " + i);
                foreach (var monkey in game.Monkeys)
                {
                    Console.WriteLine($"Monkey {monkey.Id} inpsected items {monkey.Inspections} times");
                }
            }
        }

        game.StartRound();

        if (printIndexes.Contains(i))
        {
            Console.WriteLine("===== After round " + i);
            foreach (var monkey in game.Monkeys)
            {
                Console.WriteLine($"Monkey {monkey.Id} inpsected items {monkey.Inspections} times");
            }
        }
    }
    Console.WriteLine();
    var inpsections = game.Monkeys.Select(x => x.Inspections);
    var sorted = inpsections.OrderByDescending(x => x).ToList();



    return sorted[0] * sorted[1];
};

//Console.WriteLine("Puzzle one: " + puzzleOne(false));
Console.WriteLine("Puzzle two: " + puzzleTwo(false));