namespace Bridge.Implementation;

public class Tv : IDevice
{
    private bool _on = false;
    private int _volume = 30;
    private int _channel = 1;

    public void Disable() => _on = false;
    public void Enable() => _on = true;
    public int GetChannel() => _channel;
    public string GetName() => "Television";
    public int GetVolume() => _volume;
    public bool IsEnabled() => _on;
    public void SetChannel(int channel) => _channel = channel;
    public void SetVolume(int percent)
    {
        if (percent > 100) _volume = 100;
        else if (percent < 0) _volume = 0;
        else _volume = percent;
    }
}
