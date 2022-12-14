public class Game
{
    public List<Monkey> Monkeys { get; set; } = new List<Monkey>();
    public double TotalMonkeysDividers { get; set; } = 1;
    public void Load(IEnumerable<string> lines, int divider = 3)
    {
        var toSkip = 0;
        do
        {
            Monkeys.Add(Monkey.Create(lines.Skip(toSkip).Take(7).ToList(), divider));

            toSkip += 7;
        } while (toSkip < lines.Count());

        foreach(var monkey in Monkeys) 
        {
            TotalMonkeysDividers *= monkey.Divisor;
        }
    }

    public void StartRound()
    {
        foreach(var monkey in Monkeys)
        {
            monkey.Play(Monkeys, TotalMonkeysDividers);
        }
    }
}
//Console.WriteLine("Puzzle two: " + puzzleTwo(false));