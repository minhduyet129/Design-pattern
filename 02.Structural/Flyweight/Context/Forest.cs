using Flyweight.Flyweights;
using System.Collections.Generic;

namespace Flyweight.Context;

/// <summary>
/// Forest is the client code that handles a huge number of trees.
/// </summary>
public class Forest
{
    private List<Tree> _trees = new List<Tree>();

    public void PlantTree(int x, int y, string name, string color, string texture)
    {
        TreeType type = TreeFactory.GetTreeType(name, color, texture);
        Tree tree = new Tree(x, y, type);
        _trees.Add(tree);
    }

    public void Draw()
    {
        foreach (var tree in _trees)
        {
            tree.Draw();
        }
    }

    public int GetTreesCount() => _trees.Count;
}
