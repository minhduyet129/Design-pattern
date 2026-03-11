using Adapter.Adaptee;
using Adapter.Adapter;
using Adapter.Target;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Adapter Pattern Example ===\n");

        // 1. Using a direct implementation of the target (Modern system)
        ITarget target = new ModernSystem();
        Console.WriteLine("Client: I can work just fine with Target objects:");
        Console.WriteLine(target.GetRequest());
        Console.WriteLine();

        // 2. The legacy system has an incompatible interface
        LegacySystem adaptee = new LegacySystem();
        Console.WriteLine("Client: The Adaptee class has a weird interface. See, I don't understand it:");
        Console.WriteLine($"Adaptee: {adaptee.GetSpecificRequest()}");
        Console.WriteLine();

        // 3. Now we use the Adapter to make it compatible
        ITarget adapter = new SystemAdapter(adaptee);
        Console.WriteLine("Client: But I can work with it via the Adapter:");
        Console.WriteLine(adapter.GetRequest());
    }
}

public class ModernSystem : ITarget
{
    public string GetRequest()
    {
        return "Modern system request.";
    }
}
