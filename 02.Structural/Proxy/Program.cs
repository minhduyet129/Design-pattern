using Proxy.Proxies;
using Proxy.Services;
using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Proxy Pattern Example (YouTube Cache) ===\n");

        YouTubeService realService = new YouTubeService();
        YouTubeCacheProxy proxy = new YouTubeCacheProxy(realService);

        Console.WriteLine("--- 1. First time access (No Cache) ---");
        Stopwatch sw = Stopwatch.StartNew();
        TestService(proxy);
        sw.Stop();
        Console.WriteLine($"Total time taken: {sw.ElapsedMilliseconds}ms\n");

        Console.WriteLine("--- 2. Second time access (With Cache) ---");
        sw.Restart();
        TestService(proxy);
        sw.Stop();
        Console.WriteLine($"Total time taken: {sw.ElapsedMilliseconds}ms\n");

        Console.WriteLine("--- 3. Direct access (Always Slow) ---");
        sw.Restart();
        TestService(realService);
        sw.Stop();
        Console.WriteLine($"Total time taken: {sw.ElapsedMilliseconds}ms\n");
    }

    static void TestService(IVideoService service)
    {
        // 1. Get video list
        var list = service.GetVideoList();
        
        // 2. Get info for some videos
        service.GetVideoInfo("vid1");
        service.GetVideoInfo("vid2");
    }
}
