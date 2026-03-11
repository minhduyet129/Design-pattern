namespace Prototype.Prototypes;

public abstract class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public string? Color { get; set; }

    // A standard constructor
    public Shape()
    {
    }

    // The prototype constructor. A fresh object is initialized
    // with values from the existing object.
    public Shape(Shape source)
    {
        this.X = source.X;
        this.Y = source.Y;
        this.Color = source.Color;
    }

    // The clone operation returns one of the Shape subclasses.
    public abstract Shape Clone();

    public override string ToString()
    {
        return $"Shape [X={X}, Y={Y}, Color={Color}]";
    }
}
