public class Monkey
{
    public Queue<double> StartingItems { get; } = new Queue<double>();
    public Func<double, double, double> Operation { get; set; }
    public Func<double, int> Test { get; set; }
    public int Id { get; set; }
    public double Divisor { get; set; }
    public double Inspections { get; set; } = 0;

    public Monkey(int id)
    {
        Id = id;
    }

    public void Play(List<Monkey> monkeys, double totalMonkeysDividers = 0)
    {
        while (StartingItems.Any())
        {
            
            var worryLevel = StartingItems.Dequeue();
            var newWorryLevel = Operation(worryLevel, totalMonkeysDividers);
            var targetMonkey = Test(newWorryLevel);

            monkeys[targetMonkey].StartingItems.Enqueue(newWorryLevel);
            Inspections++;
        }
    }

    public static Monkey Create(List<string> lines, int divider = 3)
    {
        var monkey = new Monkey(int.Parse(lines[0].Split(' ', ':')[1]));
        
        var items = lines[1].Split(new string[] { "  Starting items:", " ", "," }, StringSplitOptions.RemoveEmptyEntries);
        foreach(var item in items)
        {
            monkey.StartingItems.Enqueue(double.Parse(item));
        }

        var operation = lines[2].Replace("  Operation: new = old ", "").Split(' ');
        var mathOperation = operation[0];

        double value;

        if(!double.TryParse(operation[1], out value))
        {
            value = -1;
        }

        monkey.Operation = (double worryLevel, double totalMonkeysDividers) =>
        {
            var targetValue = value > 0 ? value: worryLevel;
            double newValue = 0;
            switch(mathOperation)
            {
                case "+":
                    newValue = worryLevel + targetValue;
                    break;
                case "*":
                    newValue = worryLevel * targetValue;
                    break;
            }

            return divider == 3 ? Math.Floor(newValue / divider) : newValue % totalMonkeysDividers;
        };

        var divisibleBy = int.Parse(lines[3].Replace("  Test: divisible by ", ""));
        monkey.Divisor = divisibleBy;

        var ifTrue = int.Parse(lines[4].Replace("   If true: throw to monkey ", ""));
        var ifFalse = int.Parse(lines[5].Replace("    If false: throw to monkey ", ""));

        monkey.Test = (double operationResult) =>
        {
            return operationResult % divisibleBy == 0 ? ifTrue:ifFalse;
        };
        return monkey;
    }
}
//Console.WriteLine("Puzzle two: " + puzzleTwo(false));