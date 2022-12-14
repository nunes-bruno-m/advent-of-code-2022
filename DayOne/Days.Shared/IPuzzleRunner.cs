namespace Days.Shared
{
    public interface IPuzzleRunner
    {
        string RunPartOne(IEnumerable<string> lines);
        string RunPartTwo(IEnumerable<string> lines);
    }
}