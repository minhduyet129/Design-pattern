using Bridge.Implementation;

namespace Bridge.Abstraction;

/// <summary>
/// The Abstraction defines the interface for the "control" part of the two class hierarchies.
/// It maintains a reference to an object of the Implementation hierarchy and delegates
/// all of the real work to this object.
/// </summary>
public class RemoteControl
{
    protected IDevice _device;

    public RemoteControl(IDevice device)
    {
        _device = device;
    }

    public virtual void TogglePower()
    {
        if (_device.IsEnabled()) _device.Disable();
        else _device.Enable();
    }

    public virtual void VolumeDown()
    {
        _device.SetVolume(_device.GetVolume() - 10);
    }

    public virtual void VolumeUp()
    {
        _device.SetVolume(_device.GetVolume() + 10);
    }

    public virtual void ChannelDown()
    {
        _device.SetChannel(_device.GetChannel() - 1);
    }

    public virtual void ChannelUp()
    {
        _device.SetChannel(_device.GetChannel() + 1);
    }

    public virtual void ShowStatus()
    {
        Console.WriteLine($"------------------------------------");
        Console.WriteLine($"| Remote control for: {_device.GetName()}");
        Console.WriteLine($"| Status: {(_device.IsEnabled() ? "ON" : "OFF")}");
        Console.WriteLine($"| Current volume: {_device.GetVolume()}%");
        Console.WriteLine($"| Current channel: {_device.GetChannel()}");
        Console.WriteLine($"------------------------------------\n");
    }
}
