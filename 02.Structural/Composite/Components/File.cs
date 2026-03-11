namespace Composite.Components;

/// <summary>
/// The Leaf class represents the end objects of a composition. A leaf can't
/// have any children.
/// Usually, it's the Leaf objects that do the actual work, whereas Composite
/// objects only delegate to their sub-components.
/// </summary>
public class File : FileSystemItem
{
    private long _size;

    public File(string name, long size) : base(name)
    {
        _size = size;
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + " File: " + _name + " (" + GetSize() + " bytes)");
    }

    public override long GetSize()
    {
        return _size;
    }
}
