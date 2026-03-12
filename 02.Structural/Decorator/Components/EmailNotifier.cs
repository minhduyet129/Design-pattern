namespace Decorator.Components;

/// <summary>
/// Concrete Components provide default implementations for the operations.
/// </summary>
public class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}
