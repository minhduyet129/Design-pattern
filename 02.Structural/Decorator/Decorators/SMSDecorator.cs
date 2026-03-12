using Decorator.Components;

namespace Decorator.Decorators;

/// <summary>
/// Concrete Decorators call the wrapped object and alter its result in some way.
/// </summary>
public class SMSDecorator : BaseDecorator
{
    public SMSDecorator(INotifier notifier) : base(notifier)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        SendSMS(message);
    }

    private void SendSMS(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}
