




public class OS
{
    public ElfDirectory CurrentDirectory { get; set; }
    public List<ElfDirectory> Directories { get; set; } = new List<ElfDirectory>
    {
        new ElfDirectory("/", null)
    };

    public readonly double DiskSize = 70000000;
    public double UsedDiskSpace { get => Directories.First().Size; }

    public OS()
    {
        CurrentDirectory = Directories.First();
    }

    public void ProcessLine(string line)
    {
        var commands = line.Split(" ");
        if (commands[0] == "$")
        {
            if(commands[1] == "cd")
            {
                if (commands[2] == "/")
                {
                    CurrentDirectory = Directories.First();
                } else if (commands[2] == "..")
                {
                    CurrentDirectory = CurrentDirectory.ParentDirectory ?? Directories.First();
                }
                else
                {
                    CurrentDirectory = CurrentDirectory.AddOrGetDirectory(commands[2], CurrentDirectory);
                }
            } 
            
        } else if (commands[0] == "dir")
        {
            CurrentDirectory.AddOrGetDirectory(commands[1], CurrentDirectory);
        } else
        {
            var fileSize = double.Parse(commands[0]);
            CurrentDirectory.AddOrGetFile(commands[1], fileSize);
        }
    }

    //public List<ElfDirectory> GetDirectoriesWithSize(ElfDirectory directory, double maxSize)
    //{
    //    var directories = new List<ElfDirectory>();
    //    if (directory.Size <= maxSize)
    //    {            
    //        directories.Add(directory);
    //    }
    //    foreach (var subDirectory in directory.SubDirectories)
    //    {
    //        directories.AddRange(GetDirectoriesWithSize(subDirectory, maxSize));
    //    }

    //    return directories;
    //}
    public List<double> GetAllDirectoriesSize(ElfDirectory directory)
    {
        var directoriesSize = new List<double> { directory.Size };

        foreach (var subDirectory in directory.SubDirectories)
        {
            directoriesSize.AddRange(GetAllDirectoriesSize(subDirectory));
        }

        return directoriesSize;
    }

}
//Console.WriteLine("Puzzle two: " + puzzleTwo(false));