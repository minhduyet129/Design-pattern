namespace AbstractFactory.Products;

public class MacCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("Rendering a checkbox in macOS style.");
    }
}
