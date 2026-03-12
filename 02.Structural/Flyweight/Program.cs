using Flyweight.Context;
using Flyweight.Flyweights;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Flyweight Pattern Example (Forest Simulator) ===\n");

        var forest = new Forest();

        // 1. Plant trees with shared types
        Console.WriteLine("Planting 1,000,000 trees...");
        for (int i = 0; i < 1_000_000; i++)
        {
            // Even with millions of trees, there are only 2 types.
            if (i % 2 == 0)
            {
                forest.PlantTree(i, i, "Summer Oak", "Green", "OakTexture.png");
            }
            else
            {
                forest.PlantTree(i, i, "Autumn Maple", "Orange", "MapleTexture.png");
            }
        }

        // 2. Statistics
        Console.WriteLine($"\nTotal trees planted: {forest.GetTreesCount():N0}");
        Console.WriteLine($"Total TreeType objects created: {TreeFactory.GetTreeTypesCount()}");

        // 3. Explain memory saving
        Console.WriteLine("\nMemory saving logic:");
        Console.WriteLine("- Each 'Tree' object (Context) stores only 2 ints (X, Y) and 1 reference (Type).");
        Console.WriteLine("- The heavy data (Name, Color, Texture) is shared across all trees of the same type.");
        Console.WriteLine("- This pattern significantly reduces RAM usage when dealing with massive numbers of objects.");

        Console.WriteLine("\nForest simulation completed.");
    }
}
