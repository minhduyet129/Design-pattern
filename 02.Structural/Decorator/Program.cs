using Decorator.Components;
using Decorator.Decorators;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Decorator Pattern Example (Notification System) ===\n");

        // 1. Simple Email Notifier
        Console.WriteLine("--- 1. Simple Email ---");
        INotifier notifier = new EmailNotifier();
        notifier.Send("System alert!");

        // 2. Email + SMS
        Console.WriteLine("\n--- 2. Email + SMS ---");
        INotifier smsEnabled = new SMSDecorator(notifier);
        smsEnabled.Send("System alert!");

        // 3. Email + SMS + Slack
        Console.WriteLine("\n--- 3. Email + SMS + Slack ---");
        INotifier fullStack = new SlackDecorator(smsEnabled);
        fullStack.Send("Critical system error!");

        // 4. We can also change the order or composition
        Console.WriteLine("\n--- 4. Just Email + Slack ---");
        INotifier slackOnly = new SlackDecorator(new EmailNotifier());
        slackOnly.Send("Low priority message.");
    }
}
