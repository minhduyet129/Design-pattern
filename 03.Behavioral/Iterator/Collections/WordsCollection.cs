using Iterator.Iterators;
using System.Collections;
using System.Collections.Generic;

namespace Iterator.Collections;

/// <summary>
/// Concrete Collections provide one or several methods for acquiring fresh
/// iterator instances, compatible with the collection class.
/// </summary>
public class WordsCollection : IteratorAggregate
{
    private List<string> _collection = new List<string>();

    private bool _direction = false;

    public void ReverseDirection()
    {
        _direction = !_direction;
    }

    public List<string> getItems()
    {
        return _collection;
    }

    public void AddItem(string item)
    {
        this._collection.Add(item);
    }

    public override IEnumerator GetEnumerator()
    {
        return new AlphabeticalOrderIterator(this, _direction);
    }
}
