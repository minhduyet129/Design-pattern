using System;
using FactoryMethod.Creators;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Factory Method Pattern Showcase ===\n");

            Console.WriteLine("Client: I want to deliver by land.");
            ClientCode(new RoadLogistics());

            Console.WriteLine("\nClient: I want to deliver by sea.");
            ClientCode(new SeaLogistics());

            Console.WriteLine("\nEnd of Factory Method Demo.");
        }

        // The client code works with an instance of a concrete creator, albeit through its base interface.
        // As long as the client keeps working with the creator via the base interface, you can pass it any creator's subclass.
        static void ClientCode(Logistics creator)
        {
            // The client doesn't know (or care) whether it's creating a truck or a ship.
            // It just calls PlanDelivery(), and the Creator handles the rest.
            creator.PlanDelivery();
        }
    }
}
