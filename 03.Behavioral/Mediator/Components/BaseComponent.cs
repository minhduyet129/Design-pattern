using Mediator.Mediators;

namespace Mediator.Components;

/// <summary>
/// The Base Component provides the basic functionality of storing a
/// mediator's instance inside component objects.
/// </summary>
public class BaseComponent
{
    protected IMediator _mediator;

    public BaseComponent(IMediator mediator = null)
    {
        this._mediator = mediator;
    }

    public void SetMediator(IMediator mediator)
    {
        this._mediator = mediator;
    }
}
