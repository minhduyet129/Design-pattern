using AbstractFactory.Client;
using AbstractFactory.Factories;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Client: Testing client code with the first factory type...");
        ClientMethod(new WinFactory());
        Console.WriteLine();

        Console.WriteLine("Client: Testing the same client code with the second factory type...");
        ClientMethod(new MacFactory());
    }

    public static void ClientMethod(IGUIFactory factory)
    {
        var app = new Application(factory);
        app.Paint();
    }
}
