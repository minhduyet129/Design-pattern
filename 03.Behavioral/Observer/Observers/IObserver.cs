namespace Observer.Observers;

/// <summary>
/// The Observer interface declares the update method, used by subjects.
/// </summary>
public interface IObserver
{
    // Receive update from subject
    void Update(string jobTitle);
}
