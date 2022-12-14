



public class ElfFile
{
    public double Size { get; set; }
    public string Name { get; set; }
    public ElfFile(string name, double size)
    {
        Size = size;
        Name = name;
    }
}
//Console.WriteLine("Puzzle two: " + puzzleTwo(false));