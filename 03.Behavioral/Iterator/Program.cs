using Iterator.Collections;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Iterator Pattern Example ===\n");

        // The client code may or may not know about the Concrete Iterator
        // or Collection classes, depending on the level of indirectness you
        // want to keep in your program.
        var collection = new WordsCollection();
        collection.AddItem("First");
        collection.AddItem("Second");
        collection.AddItem("Third");

        Console.WriteLine("Straight traversal:");

        foreach (var element in collection)
        {
            Console.WriteLine(element);
        }

        Console.WriteLine("\nReverse traversal:");

        collection.ReverseDirection();

        foreach (var element in collection)
        {
            Console.WriteLine(element);
        }
    }
}
