// See https://aka.ms/new-console-template for more information
using AllDays.Day13;
using Days.Shared;

var puzzles = new List<IPuzzleRunner>()
{
    new Day13PuzzleRunner()
};

var dataLoader = new DataLoader();

string? puzzleNumberInput;
int puzzleNumber;

do
{
    do
    {
        Console.WriteLine("Enter the puzzle number (1 to 12) to run or 0 to quit");
        puzzleNumberInput = Console.ReadLine()?.Trim();

        if(!int.TryParse(puzzleNumberInput, out puzzleNumber))
        {
            puzzleNumberInput = null;
        }

    } while (puzzleNumberInput == null || puzzleNumberInput == string.Empty);

    var data = dataLoader.LoadInputs(puzzleNumber, TypeOfInput.Real);

    Console.WriteLine($"==== Puzzle {puzzleNumber} selected====");    
    Console.WriteLine($"==== Running part 1                ====\n");
    puzzles[puzzleNumber + 1].RunPartOne(data);

    Console.WriteLine($"\n\n==== Running part 2                ====\n");
    puzzles[puzzleNumber + 1].RunPartTwo(data);

} while (puzzleNumberInput != "q");



Console.WriteLine("Goodbye!");

