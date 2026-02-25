using System;

namespace FactoryMethod.Products
{
    /// <summary>
    /// Concrete Product 2
    /// </summary>
    public class Ship : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Ship: Delivering cargo by sea (in a container).");
        }
    }
}
