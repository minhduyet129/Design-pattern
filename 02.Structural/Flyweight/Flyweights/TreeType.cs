namespace Flyweight.Flyweights;

/// <summary>
/// The Flyweight class contains a portion of the state of a tree.
/// These fields store values that are unique for each particular tree.
/// For instance, you won't find tree coordinates here.
/// But the texture and color shared by many trees are here.
/// Since this data is usually BIG, you'd waste a lot of memory by
/// keeping it in each tree object. Instead, we can extract it into
/// a separate object which multiple individual tree objects can reference.
/// </summary>
public class TreeType
{
    public string Name { get; private set; }
    public string Color { get; private set; }
    public string Texture { get; private set; }

    public TreeType(string name, string color, string texture)
    {
        Name = name;
        Color = color;
        Texture = texture;
    }

    public void Draw(int x, int y)
    {
        // In a real application, we would use coordinates and the shared
        // texture and color to render the tree on the screen.
        // For demo purposes, we'll just print it.
        // Console.WriteLine($"Drawing tree of type {Name} at ({x}, {y})");
    }
}
