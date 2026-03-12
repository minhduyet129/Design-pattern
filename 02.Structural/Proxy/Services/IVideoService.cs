using System.Collections.Generic;

namespace Proxy.Services;

/// <summary>
/// The Subject interface declares common operations for both RealSubject and the Proxy. 
/// As long as the client works with RealSubject using this interface, 
/// you'll be able to pass it a proxy instead of a real subject.
/// </summary>
public interface IVideoService
{
    Dictionary<string, string> GetVideoList();
    string GetVideoInfo(string id);
    void DownloadVideo(string id);
}
