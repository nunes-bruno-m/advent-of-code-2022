public class ElfGraphicCPU
{
    public Dictionary<int, bool> CycleResults { get; set; } = new Dictionary<int, bool>();
    public int CurrentCycle { get; set; } = 0;
    public int CurrentValue { get; set; } = 1;

    public ElfGraphicCPU()
    {
        DrawSprite();
    }
    public void Process(string line)
    {
        if (line.StartsWith("noop"))
        {
            CurrentCycle++;
            PrintStartCycle(line);
            CycleResults.Add(CurrentCycle, IsVisible());
            PrintDuringCycle();
            PrintEndOfCycle(line);
            
        }
        else
        {
            var value = int.Parse(line.Split(' ')[1]);
            CurrentCycle++;
            PrintStartCycle(line);
            CycleResults.Add(CurrentCycle, IsVisible());
            PrintDuringCycle();

            CurrentCycle++;

            PrintStartCycle(line);
            CycleResults.Add(CurrentCycle, IsVisible());
            PrintDuringCycle();

            CurrentValue += value;
            PrintEndOfCycle(line);
            DrawSprite();
        }
    }

    private void DrawCurrentCRT()
    {
        var list = CycleResults.Values.ToList();
        Console.WriteLine("------------------------------------------------");
        for (var i = 0; i < list.Count; i++)
        {
            if (i > 39 && i % 40 == 0)
            {
                Console.WriteLine();
            }
            Console.Write(list[i] ? "#" : ".");
        }
        Console.WriteLine("\n------------------------------------------------");
    }

    private void DrawSprite()
    {
        string line = "Sprite position: ";
        for (var i = 0; i < 40; i++)
        {
            line +=CurrentValue - 1 <= i && i <= CurrentValue + 1 ? "#" : ".";
        }
        Console.WriteLine(line);
    }
    private void PrintStartCycle(string line)
    {
        Console.WriteLine();
        Console.WriteLine($"Start cycle {CurrentCycle}: begin executing {line}");
    }
    private void PrintDuringCycle()
    {
        Console.WriteLine($"During cycle {CurrentCycle}: CRT drawing at {CurrentCycle -1}");
        DrawCurrentCRT();
    }
    private void PrintEndOfCycle(string line)
    {
        Console.WriteLine($"End of cycle {CurrentCycle}: finish executing {line} (Register X is now {CurrentValue})");
        Console.WriteLine();
    }

    private bool IsVisible()
    {
        var position = (CurrentCycle - 1) % 40;
        return CurrentValue - 1 <= position && position <= CurrentValue + 1;
    }
}