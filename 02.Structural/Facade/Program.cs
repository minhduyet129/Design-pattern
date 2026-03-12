using Facade.Facade;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Facade Pattern Example (Video Conversion) ===\n");

        // The client code doesn't need to know anything about the complex 
        // subsystem classes. Instead, it uses a simple Facade interface.
        var converter = new VideoConverter();
        
        string mp4Video = converter.ConvertVideo("funny-cats-video.ogg", "mp4");
        Console.WriteLine($"\nResult: {mp4Video} is ready for use.");

        Console.WriteLine("\n------------------------------------------------\n");

        string oggVideo = converter.ConvertVideo("presentation.mp4", "ogg");
        Console.WriteLine($"\nResult: {oggVideo} is ready for use.");
    }
}
