using FactoryMethod.Products;

namespace FactoryMethod.Creators
{
    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Ship();
        }
    }
}
