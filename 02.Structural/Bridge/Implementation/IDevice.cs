namespace Bridge.Implementation;

/// <summary>
/// The Implementation interface declares methods common to all concrete implementation classes.
/// It doesn't have to match the Abstraction's interface. In fact, the two interfaces can be entirely different.
/// </summary>
public interface IDevice
{
    bool IsEnabled();
    void Enable();
    void Disable();
    int GetVolume();
    void SetVolume(int percent);
    int GetChannel();
    void SetChannel(int channel);
    string GetName();
}
