using FactoryMethod.Products;

namespace FactoryMethod.Creators
{
    /// <summary>
    /// Concrete Creators override the factory method in order to change the resulting product's type.
    /// </summary>
    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Truck();
        }
    }
}
