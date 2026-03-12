using Decorator.Components;

namespace Decorator.Decorators;

public class SlackDecorator : BaseDecorator
{
    public SlackDecorator(INotifier notifier) : base(notifier)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        SendSlack(message);
    }

    private void SendSlack(string message)
    {
        Console.WriteLine($"Sending Slack message: {message}");
    }
}
