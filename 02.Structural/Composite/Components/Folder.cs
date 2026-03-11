using System.Collections.Generic;
using System.Linq;

namespace Composite.Components;

/// <summary>
/// The Composite class represents the complex components that may have
/// children. Usually, the Composite objects delegate the actual work to
/// their children and then "sum up" the result.
/// </summary>
public class Folder : FileSystemItem
{
    private List<FileSystemItem> _children = new List<FileSystemItem>();

    public Folder(string name) : base(name)
    {
    }

    public override void Add(FileSystemItem component)
    {
        _children.Add(component);
    }

    public override void Remove(FileSystemItem component)
    {
        _children.Remove(component);
    }

    public override bool IsComposite()
    {
        return true;
    }

    /// <summary>
    /// The Composite executes its primary logic in a specific way. It
    /// traverses recursively through all its children, collecting and
    /// summing their results.
    /// </summary>
    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + " Folder: " + _name + " (Total: " + GetSize() + " bytes)");

        foreach (var child in _children)
        {
            child.Display(depth + 2);
        }
    }

    public override long GetSize()
    {
        return _children.Sum(child => child.GetSize());
    }
}
