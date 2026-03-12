using State.Context;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== State Pattern Example (Gumball Vending Machine) ===\n");

        // 1. Initialize machine with 2 gumballs
        var machine = new VendingMachine(2);

        // 2. Normal flow
        Console.WriteLine("\n--- Round 1 ---");
        machine.InsertCoin();
        machine.TurnCrank();

        // 3. Trying to eject after turning
        Console.WriteLine("\n--- Round 2 ---");
        machine.InsertCoin();
        machine.EjectCoin();
        machine.TurnCrank();

        // 4. Buying the last gumball
        Console.WriteLine("\n--- Round 3 ---");
        machine.InsertCoin();
        machine.TurnCrank();

        // 5. Trying to buy when sold out
        Console.WriteLine("\n--- Round 4 (Sold Out) ---");
        machine.InsertCoin();
        machine.TurnCrank();
    }
}
