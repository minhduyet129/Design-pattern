using Command.Receiver;

namespace Command.Commands;

/// <summary>
/// Some commands can implement simple operations on their own.
/// </summary>
public class SimpleCommand : ICommand
{
    private string _payload = string.Empty;

    public SimpleCommand(string payload)
    {
        this._payload = payload;
    }

    public void Execute()
    {
        Console.WriteLine($"SimpleCommand: See, I can do simple things like printing ({this._payload})");
    }
}

/// <summary>
/// However, some commands can delegate more complex operations to other
/// objects, called "receivers."
/// </summary>
public class ComplexCommand : ICommand
{
    private Receiver.Receiver _receiver;

    // Context data, required for launching the receiver's methods.
    private string _a;
    private string _b;

    // Complex commands can accept one or several receiver objects along with
    // any context data via the constructor.
    public ComplexCommand(Receiver.Receiver receiver, string a, string b)
    {
        this._receiver = receiver;
        this._a = a;
        this._b = b;
    }

    // Commands can delegate to any methods of a receiver.
    public void Execute()
    {
        Console.WriteLine("ComplexCommand: Complex stuff should be handled by a receiver object.");
        this._receiver.DoSomething(this._a);
        this._receiver.DoSomethingElse(this._b);
    }
}
