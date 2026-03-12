using System.Collections.Generic;

namespace Flyweight.Flyweights;

/// <summary>
/// Flyweight Factory decides whether to re-use existing flyweight or to
/// create a new object.
/// </summary>
public class TreeFactory
{
    private static Dictionary<string, TreeType> _treeTypes = new Dictionary<string, TreeType>();

    public static TreeType GetTreeType(string name, string color, string texture)
    {
        string key = $"{name}_{color}_{texture}";
        if (!_treeTypes.ContainsKey(key))
        {
            _treeTypes[key] = new TreeType(name, color, texture);
        }
        return _treeTypes[key];
    }

    public static int GetTreeTypesCount() => _treeTypes.Count;
}
