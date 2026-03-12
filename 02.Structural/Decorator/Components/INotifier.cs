namespace Decorator.Components;

/// <summary>
/// The Component interface defines operations that can be altered by decorators.
/// </summary>
public interface INotifier
{
    void Send(string message);
}
