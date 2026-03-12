using System.Collections;

namespace Iterator.Iterators;

/// <summary>
/// The Iterator interface declares operations for traversing a collection: 
/// fetching the next element, retrieving the current position, 
/// restarting iteration, etc.
/// </summary>
public abstract class Iterator : IEnumerator
{
    object IEnumerator.Current => Current();

    public abstract int Key();
    public abstract object Current();
    public abstract bool MoveNext();
    public abstract void Reset();
}
