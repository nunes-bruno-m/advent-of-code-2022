

public class Pair
{
    public (int, int) LeftPair { get; set; }
    public (int, int) RightPair { get; set; }
    public Pair(string pairDefinition)
    {
        var pairSplit = pairDefinition.Split(",");
        LeftPair = GetRange(pairSplit[0]);
        RightPair = GetRange(pairSplit[1]);

    }

    private static (int, int) GetRange(string rangeDefinition)
    {
        var range = rangeDefinition.Split('-').Select(x => Int32.Parse(x)).ToList();
        return (range[0], range[1]);
    }

    public bool AreFullyOverlapping()
    {
        return AreRangesFullyOverlapping(LeftPair, RightPair) || AreRangesFullyOverlapping(RightPair, LeftPair);
    }
    public bool ArePartiallyOrFullyOverlapping()
    {
        return AreRangesOverlapping(LeftPair, RightPair) || AreRangesOverlapping(RightPair, LeftPair);
    }

    private bool AreRangesFullyOverlapping((int, int) leftRange, (int, int) rightRange)
    {
        return leftRange.Item1 <= rightRange.Item1 && leftRange.Item2 >= rightRange.Item2;
    }

    private bool AreRangesOverlapping((int, int) leftRange, (int, int) rightRange)
    {
        return IsInRange(leftRange.Item1, leftRange.Item2, rightRange.Item1) || IsInRange(leftRange.Item1, leftRange.Item2, rightRange.Item2);
    }

    private bool IsInRange(int left, int right, int target) { 
        return left <= target && right >= target;
    }

}
//Console.WriteLine("Puzzle two: " + puzzleTwo(false));