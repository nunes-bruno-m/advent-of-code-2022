// See https://aka.ms/new-console-template for more information

var puzzleOne = () =>
{
    int biggestTotal = 0;
    int currentTotal = 0;

    // Read the file and display it line by line.  
    foreach (string line in System.IO.File.ReadLines(@"Input.txt"))
    {
        if (line == string.Empty)
        {
            if (currentTotal > biggestTotal)
            {
                biggestTotal = currentTotal;
            }
            currentTotal = 0;
        }
        else
        {
            currentTotal += Int32.Parse(line);
        }
    }
    return biggestTotal;
};

var puzzleTwo = () =>
{
    List<int> totals = new List<int>();
    int currentTotal = 0;

    // Read the file and display it line by line.  
    foreach (string line in System.IO.File.ReadLines(@"Input.txt"))
    {
        if (line == string.Empty)
        {
            totals.Add(currentTotal);
            currentTotal = 0;
        }
        else
        {
            currentTotal += Int32.Parse(line);
        }
    }


    return totals.OrderDescending().Take(3).Sum();
};


Console.WriteLine("Puzzle one: " + puzzleOne());
Console.WriteLine("Puzzle two: " + puzzleTwo());
