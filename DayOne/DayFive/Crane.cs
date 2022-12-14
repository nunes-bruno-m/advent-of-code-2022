public class Crane
{
    public Dictionary<int, List<string>> Piles { get; set; } = new Dictionary<int, List<string>>();
    public Queue<(int quantity, int from, int to)> Moves { get; set; } = new Queue<(int quantity, int from, int to)>();

    public void ProcessLine(string line)
    {
        if (line.StartsWith("move"))
        {
            var splitted = line.Split(new List<string>{ "move ", "from ", "to "}.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            Moves.Enqueue((Int32.Parse(splitted[0]), Int32.Parse(splitted[1]), Int32.Parse(splitted[2])));
        } else if (line.Contains("["))
        {
            for(var i = 0; i < line.Length; i+=4)
            {
                if (line[i] == '[')
                {
                    AddToPiles(i / 4 + 1, line[i + 1]);
                }
            }
        }
    }

    private void AddToPiles(int position, char box)
    {
        if(Piles.ContainsKey(position))
        {
            Piles[position].Add(box.ToString());
        } else
        {
            Piles.Add(position, new List<string> { box.ToString() });
        }
    }

    public void Reorganize(bool is9001)
    {
        foreach (var item in Piles)
        {
            item.Value.Reverse();
        }

        while(Moves.Any())
        {
            ProcessMove(is9001);
        }
    }

    private void ProcessMove(bool is9001) 
    { 
        var instruction = Moves.Dequeue();

        var toMove = Piles[instruction.from].TakeLast(instruction.quantity);

        if(!is9001)
        {
            toMove = toMove.Reverse();
        }

        Piles[instruction.to].AddRange(toMove);
        Console.WriteLine($"Moving {string.Join(", ", toMove)} to {instruction.to}");

        Piles[instruction.from].RemoveRange(Piles[instruction.from].Count - instruction.quantity, instruction.quantity);        
    }

    public string GetTops()
    {
        var result = "";
        for(var i=1; i <= Piles.Count; i++)
        {
            result += Piles[i].Last();
        }

        return result;
    }

    public string GetState()
    {
        var result = "";
        for (var i = 1; i <= Piles.Count; i++)
        {
            result += $"State of {i} {string.Join(" ", Piles[i])}\n";
        }

        return result;
    }
}
//Console.WriteLine("Puzzle two: " + puzzleTwo(false));