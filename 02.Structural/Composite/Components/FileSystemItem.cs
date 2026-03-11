namespace Composite.Components;

/// <summary>
/// The base Component class declares common operations for both simple and
/// complex objects of a composition.
/// </summary>
public abstract class FileSystemItem
{
    protected string _name;

    public FileSystemItem(string name)
    {
        _name = name;
    }

    public abstract void Display(int depth);
    public abstract long GetSize();

    // Some components may implement methods for managing children.
    public virtual void Add(FileSystemItem component)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(FileSystemItem component)
    {
        throw new NotImplementedException();
    }

    public virtual bool IsComposite()
    {
        return false;
    }
}
