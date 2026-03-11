namespace AbstractFactory.Products;

public class WinButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Rendering a button in Windows style.");
    }
}
