using System.Collections.Generic;
using System.Threading;

namespace Proxy.Services;

/// <summary>
/// The RealSubject contains some core business logic. 
/// Usually, RealSubjects are capable of doing some useful work 
/// which may also be very slow or sensitive - e.g. correcting input data. 
/// A Proxy can solve these issues without any changes to the RealSubject's code.
/// </summary>
public class YouTubeService : IVideoService
{
    public Dictionary<string, string> GetVideoList()
    {
        ConnectToServer("https://www.youtube.com");
        Console.WriteLine("YouTube: Fetching video list...");
        SimulateNetworkLatency();
        
        return new Dictionary<string, string>
        {
            { "vid1", "Introduction to Design Patterns" },
            { "vid2", "Advanced C# Tips" },
            { "vid3", "Clean Code Principles" }
        };
    }

    public string GetVideoInfo(string id)
    {
        ConnectToServer("https://www.youtube.com/watch?v=" + id);
        Console.WriteLine($"YouTube: Fetching info for video {id}...");
        SimulateNetworkLatency();
        
        return $"Video Metadata for {id}";
    }

    public void DownloadVideo(string id)
    {
        Console.WriteLine($"YouTube: Downloading video {id}...");
        SimulateNetworkLatency();
        Console.WriteLine($"YouTube: Video {id} downloaded.");
    }

    private void ConnectToServer(string url)
    {
        Console.Write($"YouTube: Connecting to {url}... ");
        SimulateNetworkLatency();
        Console.WriteLine("Connected!");
    }

    private void SimulateNetworkLatency()
    {
        // Simulate a slow network connection
        Thread.Sleep(1000);
    }
}
