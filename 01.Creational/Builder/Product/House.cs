namespace Builder.Product;

public class House
{
    public int Walls { get; set; }
    public int Doors { get; set; }
    public int Windows { get; set; }
    public bool HasRoof { get; set; }
    public bool HasGarage { get; set; }
    public bool HasSwimmingPool { get; set; }
    public bool HasGarden { get; set; }

    public override string ToString()
    {
        return $"House with:\n" +
               $"- Walls: {Walls}\n" +
               $"- Doors: {Doors}\n" +
               $"- Windows: {Windows}\n" +
               $"- Has Roof: {HasRoof}\n" +
               $"- Has Garage: {HasGarage}\n" +
               $"- Has Swimming Pool: {HasSwimmingPool}\n" +
               $"- Has Garden: {HasGarden}";
    }
}
