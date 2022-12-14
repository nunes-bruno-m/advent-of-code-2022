public class ElfMap
{
    public string[] Lines { get; set; }
    public ElfMap(string[] lines)
    {
        Lines = lines;
    }

    public int ScenicDistanceLeft(int x, int y)
    {
        var scenicDistance = 0;
        for (var left = x - 1; left >= 0; left--)
        {
            scenicDistance++;
            if (Lines[y][x] <= Lines[y][left])
            {
                break;
            }
        }
        return scenicDistance;
    }

    public int ScenicDistanceRight(int x, int y)
    {
        var scenicDistance = 0;
        for (var right = x + 1; right < Lines[y].Length; right++)
        {
            scenicDistance++;
            if (Lines[y][x] <= Lines[y][right])
            {
                break;
            }
        }
        return scenicDistance;
    }

    public int ScenicDistanceBottom(int x, int y)
    {
        var scenicDistance = 0;
        for (var bottom = y + 1; bottom < Lines.Length; bottom++)
        {
            scenicDistance++;
            if (Lines[y][x] <= Lines[bottom][x])
            {
                break;
            }
        }
        return scenicDistance;
    }
    public int ScenicDistanceTop(int x, int y)
    {
        var scenicDistance = 0;
        for (var top = y - 1; top >= 0 ; top--)
        {
            scenicDistance++;
            if (Lines[y][x] <= Lines[top][x])
            {
                break;
            }
        }
        return scenicDistance;
    }

    public double Process()
    {
        double highestScore = 0;
        for (var y = 0; y < Lines.Length; y++)
        {
            for (var x = 0; x < Lines[y].Length; x++)
            {
                double score = ScenicDistanceLeft(x, y) * ScenicDistanceRight(x, y) * ScenicDistanceTop(x, y) * ScenicDistanceBottom(x, y);
                Console.WriteLine($"{y}:{x} {score} {ScenicDistanceTop(x, y)} * {ScenicDistanceLeft(x, y)} * {ScenicDistanceBottom(x, y)} * {ScenicDistanceRight(x, y)}");
                if(score > highestScore)
                {
                    highestScore = score;
                }
            }
        }

        return highestScore;
    }
}
//Console.WriteLine("Puzzle two: " + puzzleTwo(false));