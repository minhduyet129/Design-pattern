using Builder.Builders;
using Builder.Director;
using Builder.Product;
using System;

class Program
{
    static void Main(string[] args)
    {
        // The client code creates a builder object, passes it to the director and then initiates the construction process.
        // The end result is retrieved from the builder object.
        var director = new HouseDirector();
        var builder = new ConcreteHouseBuilder();
        director.Builder = builder;

        Console.WriteLine("Standard basic house:");
        director.BuildSimpleHouse();
        Console.WriteLine(builder.GetResult().ToString());

        Console.WriteLine("Standard full featured house:");
        director.BuildLuxuryHouse();
        Console.WriteLine(builder.GetResult().ToString());

        // Remember, the Builder pattern can be used without a Director class.
        Console.WriteLine("Custom house:");
        builder.BuildWalls(4);
        builder.BuildDoors(2);
        builder.BuildWindows(2);
        builder.BuildRoof();
        Console.WriteLine(builder.GetResult().ToString());
    }
}
