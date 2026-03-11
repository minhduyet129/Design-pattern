namespace AbstractFactory.Products;

public class MacButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Rendering a button in macOS style.");
    }
}
