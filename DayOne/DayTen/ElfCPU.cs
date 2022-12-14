using System.Diagnostics;

public class ElfCPU
{
    public Dictionary<int, double> CycleResults { get; set; } = new Dictionary<int, double>() { { 1, 1} };
    public int CurrentCycle { get; set; } = 1;
    public double CurrentValue { get; set; } = 1;

    public void Process(string line)
    {
        if(line.StartsWith("noop"))
        {
            CurrentCycle++;
            CycleResults.Add(CurrentCycle, CurrentValue);
        } else
        {
            var value = int.Parse(line.Split(' ')[1]);

            CurrentCycle++;
            CycleResults.Add(CurrentCycle, CurrentValue);

            CurrentValue += value;
            CurrentCycle++;
            CycleResults.Add(CurrentCycle, CurrentValue);
        }
    }

    public double GetCycleStrength(int cycle)
    {
        return CycleResults[cycle] * cycle;
    }
}
