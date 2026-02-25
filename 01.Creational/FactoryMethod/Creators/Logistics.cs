using FactoryMethod.Products;

namespace FactoryMethod.Creators
{
    /// <summary>
    /// The Creator class declares the factory method that returns a Product object.
    /// The Creator's subclass usually provides the implementation of this method.
    /// </summary>
    public abstract class Logistics
    {
        // THE FACTORY METHOD
        // Note that the creator may also provide some default implementation of the factory method.
        public abstract ITransport CreateTransport();

        // Also note that, despite its name, the Creator's primary responsibility is not creating products.
        // Usually, it contains some core business logic that relies on Product objects, returned by the factory method.
        public void PlanDelivery()
        {
            // Call the factory method to create a Product object.
            var transport = CreateTransport();

            // Now, use the product.
            Console.WriteLine($"Logistics: Calling Deliver() on {transport.GetType().Name}");
            transport.Deliver();
        }
    }
}
