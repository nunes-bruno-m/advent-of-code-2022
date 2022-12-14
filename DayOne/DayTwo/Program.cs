// See https://aka.ms/new-console-template for more information

var getHandValue = (string hand) =>
{
    return hand switch
    {
        "A" => 1,//Rock
        "X" => 1,//Rock
        "B" => 2,//Paper
        "Y" => 2,//Paper
        "C" => 3,//Scissors
        "Z" => 3,//Scissors
        _ => 0,
    };
};

var getTargetValue = (string target) =>
{
    return target switch
    {
        "X" => -1,//Lose
        "Y" => 0,//Draw
        "Z" => 1,//Win
        _ => 0,
    };
};

var getTargetHand = (string hand, string target) =>
{
    var options = new List<string> { "Z", "X", "Y", "Z", "X" };

    var handValue = getHandValue(hand);
    var targetValue = getTargetValue(target);

    return options[handValue + targetValue];
};

var getMatchPoints = (int opponent, int you) =>
{    
    if(Math.Abs(opponent - you) == 2)
    {
        if (opponent > you) return 6 + you;
        return 0 + you;
    }

    if (opponent > you) return 0 + you;
    if (opponent == you) return 3 + you;
    return 6 + you;
};

var puzzleOne = () =>
{
    int totalScore = 0;

    // Read the file and display it line by line.  
    foreach (string line in System.IO.File.ReadLines(@"Input.txt"))
    {
        var hands = line.Split(" ");
        Console.WriteLine($"Opponent: {hands[0]} {getHandValue(hands[0])}");
        Console.WriteLine($"You: {hands[1]}{getHandValue(hands[1])}");
        Console.WriteLine($"Total: {getMatchPoints(getHandValue(hands[0]),
        getHandValue(hands[1]))}");
        totalScore += getMatchPoints(getHandValue(hands[0]),
        getHandValue(hands[1]));
        Console.WriteLine($"Accumulated: {totalScore}");
        //Console.ReadLine();
    }
    return totalScore;
};

var puzzleTwo = () =>
{
    int totalScore = 0;

    // Read the file and display it line by line.  
    foreach (string line in System.IO.File.ReadLines(@"Input.txt"))
    {
        var hands = line.Split(" ");

        var opponentHandValue = getHandValue(hands[0]);
        var yourHand = getTargetHand(hands[0], hands[1]);
        var yourHandValue = getHandValue(yourHand);
        var matchValue = getMatchPoints(opponentHandValue, yourHandValue);

        Console.WriteLine($"Opponent: {hands[0]} {opponentHandValue}");
        Console.WriteLine($"You: {yourHand}{yourHandValue}");
        Console.WriteLine($"Total: {matchValue}");
        totalScore += matchValue;
        Console.WriteLine($"Accumulated: {totalScore}");
        //Console.ReadLine();
    }
    return totalScore;
};

Console.WriteLine("Puzzle one: " + puzzleOne());
Console.WriteLine("Puzzle two: " + puzzleTwo());
