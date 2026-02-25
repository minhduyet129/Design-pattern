using System;

namespace FactoryMethod.Products
{
    /// <summary>
    /// Concrete Product 1
    /// </summary>
    public class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Truck: Delivering cargo by land (in a box).");
        }
    }
}
