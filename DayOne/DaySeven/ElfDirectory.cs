


public class ElfDirectory
{
    public ElfDirectory(string name, ElfDirectory? parentDirectory)
    {
        Name = name;
        ParentDirectory = parentDirectory;
    }
    public string Name { get; set; }
    public List<ElfDirectory> SubDirectories { get; set; } = new List<ElfDirectory>();
    public ElfDirectory? ParentDirectory { get; set; }
    public List<ElfFile> Files { get; set; } = new List<ElfFile>();

    public ElfDirectory AddOrGetDirectory(string name, ElfDirectory parentDirectory) 
    {
        var target = SubDirectories.FirstOrDefault(x => x.Name == name);
        if (target == null)
        {
            target = new ElfDirectory(name, parentDirectory);
            SubDirectories.Add(target);
        }
        return target;
    }

    public ElfFile AddOrGetFile(string name, double size)
    {
        var target = Files.FirstOrDefault(x => x.Name == name);
        if (target == null)
        {
            target = new ElfFile(name, size);
            Files.Add(target);
        }
        return target;
    }

    public double Size { get { return Files.Sum(x => x.Size) + SubDirectories.Sum(x => x.Size); } }
}
//Console.WriteLine("Puzzle two: " + puzzleTwo(false));