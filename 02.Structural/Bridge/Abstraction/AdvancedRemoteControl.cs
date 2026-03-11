using Bridge.Implementation;

namespace Bridge.Abstraction;

/// <summary>
/// You can extend the Abstraction without changing the Implementation classes.
/// </summary>
public class AdvancedRemoteControl : RemoteControl
{
    public AdvancedRemoteControl(IDevice device) : base(device)
    {
    }

    public void Mute()
    {
        Console.WriteLine($"Remote: Muting {_device.GetName()}");
        _device.SetVolume(0);
    }
}
