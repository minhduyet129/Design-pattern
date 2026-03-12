using Strategy.Context;
using Strategy.Strategies;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Strategy Pattern Example (Sorting) ===\n");

        // The client code picks a concrete strategy and passes it to the
        // context. The client should be aware of the differences between
        // strategies in order to make the right choice.
        var context = new Strategy.Context.Context();

        Console.WriteLine("Client: Strategy is set to normal sorting.");
        context.SetStrategy(new ConcreteStrategySortAscending());
        context.DoSomeBusinessLogic();

        Console.WriteLine();

        Console.WriteLine("Client: Strategy is set to reverse sorting.");
        context.SetStrategy(new ConcreteStrategySortDescending());
        context.DoSomeBusinessLogic();
    }
}
