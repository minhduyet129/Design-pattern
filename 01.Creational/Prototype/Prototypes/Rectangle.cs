namespace Prototype.Prototypes;

public class Rectangle : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle()
    {
    }

    public Rectangle(Rectangle source) : base(source)
    {
        this.Width = source.Width;
        this.Height = source.Height;
    }

    public override Shape Clone()
    {
        return new Rectangle(this);
    }

    public override string ToString()
    {
        return $"Rectangle [X={X}, Y={Y}, Color={Color}, Width={Width}, Height={Height}]";
    }
}
