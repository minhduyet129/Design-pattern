using Flyweight.Flyweights;

namespace Flyweight.Context;

/// <summary>
/// The Context object contains the unique part of the tree state.
/// This includes the coordinates (unique to each tree) and a reference
/// to the flyweight object (shared by multiple trees).
/// </summary>
public class Tree
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public TreeType Type { get; private set; }

    public Tree(int x, int y, TreeType type)
    {
        X = x;
        Y = y;
        Type = type;
    }

    public void Draw()
    {
        Type.Draw(X, Y);
    }
}
