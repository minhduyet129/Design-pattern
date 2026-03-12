using Decorator.Components;

namespace Decorator.Decorators;

/// <summary>
/// The base Decorator class follows the same interface as the other components.
/// The primary purpose of this class is to define the wrapping interface for
/// all concrete decorators.
/// </summary>
public abstract class BaseDecorator : INotifier
{
    protected INotifier _wrappee;

    public BaseDecorator(INotifier notifier)
    {
        _wrappee = notifier;
    }

    /// <summary>
    /// The Decorator delegates all work to the wrapped component.
    /// </summary>
    public virtual void Send(string message)
    {
        _wrappee.Send(message);
    }
}
