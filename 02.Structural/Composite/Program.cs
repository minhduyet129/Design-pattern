using Composite.Components;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Composite Pattern Example (File System) ===\n");

        // 1. Create files
        var file1 = new Composite.Components.File("README.md", 1024);
        var file2 = new Composite.Components.File("Program.cs", 2048);
        var file3 = new Composite.Components.File("Solution.sln", 512);
        var file4 = new Composite.Components.File("Logo.png", 1024 * 50); // 50KB

        // 2. Create folders and build a tree structure
        var root = new Folder("RootProject");
        var src = new Folder("src");
        var assets = new Folder("assets");
        var docs = new Folder("docs");

        root.Add(file3); // Solution in root
        root.Add(src);
        root.Add(assets);
        root.Add(docs);

        src.Add(file2); // Program.cs in src
        assets.Add(file4); // Logo in assets
        docs.Add(file1); // README in docs

        // 3. Demonstrate recursive operations
        Console.WriteLine("Displaying full structure:");
        root.Display(0);

        Console.WriteLine("\nCalculating total size of specific folders:");
        Console.WriteLine($"Total size of 'src' folder: {src.GetSize()} bytes");
        Console.WriteLine($"Total size of 'assets' folder: {assets.GetSize()} bytes");
        Console.WriteLine($"Total size of 'Root' project: {root.GetSize()} bytes");

        // 4. Client code doesn't need to know if it's a file or a folder
        Console.WriteLine("\nClient processing items uniformly:");
        ProcessItem(file1);
        ProcessItem(root);
    }

    static void ProcessItem(FileSystemItem item)
    {
        Console.WriteLine($"Processing {(item.IsComposite() ? "a folder" : "a file")}: {item.GetSize()} bytes total.");
    }
}
