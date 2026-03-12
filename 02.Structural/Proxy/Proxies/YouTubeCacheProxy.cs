using Proxy.Services;
using System.Collections.Generic;

namespace Proxy.Proxies;

/// <summary>
/// The Proxy has an interface identical to the RealSubject.
/// </summary>
public class YouTubeCacheProxy : IVideoService
{
    private IVideoService _service;
    private Dictionary<string, string> _cacheList = null;
    private Dictionary<string, string> _cacheAll = new Dictionary<string, string>();

    public YouTubeCacheProxy(IVideoService service)
    {
        _service = service;
    }

    public Dictionary<string, string> GetVideoList()
    {
        if (_cacheList == null)
        {
            Console.WriteLine("Proxy: Cache is empty. Fetching list from service...");
            _cacheList = _service.GetVideoList();
        }
        else
        {
            Console.WriteLine("Proxy: Returning list from cache.");
        }
        return _cacheList;
    }

    public string GetVideoInfo(string id)
    {
        if (!_cacheAll.ContainsKey(id))
        {
            Console.WriteLine($"Proxy: Info for {id} not in cache. Fetching from service...");
            string info = _service.GetVideoInfo(id);
            _cacheAll[id] = info;
        }
        else
        {
            Console.WriteLine($"Proxy: Returning info for {id} from cache.");
        }
        return _cacheAll[id];
    }

    public void DownloadVideo(string id)
    {
        // Proxy can also control access or log actions
        Console.WriteLine($"Proxy: Checking permissions for download {id}...");
        _service.DownloadVideo(id);
    }

    public void Reset()
    {
        _cacheList = null;
        _cacheAll.Clear();
        Console.WriteLine("Proxy: Cache cleared.");
    }
}
