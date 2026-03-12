using Command.Commands;
using Command.Invoker;
using Command.Receiver;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Command Pattern Example ===\n");

        // The client code can parameterize an invoker with any commands.
        Invoker invoker = new Invoker();
        
        // Simple command
        invoker.SetOnStart(new SimpleCommand("Say Hi!"));

        // Complex command that uses a receiver
        Receiver receiver = new Receiver();
        invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

        // Trigger the invoker
        invoker.DoSomethingImportant();
    }
}
