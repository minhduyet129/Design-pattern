using System.Collections;

namespace Iterator.Collections;

/// <summary>
/// The Iterator Aggregate interface declares a method for acquiring 
/// an iterator compatible with the collection.
/// </summary>
public abstract class IteratorAggregate : IEnumerable
{
    public abstract IEnumerator GetEnumerator();
}
