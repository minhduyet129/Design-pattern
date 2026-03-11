using Adapter.Adaptee;
using Adapter.Target;

namespace Adapter.Adapter;

/// <summary>
/// The Adapter makes the Adaptee's interface compatible with the Target's interface.
/// </summary>
public class SystemAdapter : ITarget
{
    private readonly LegacySystem _legacySystem;

    public SystemAdapter(LegacySystem legacySystem)
    {
        _legacySystem = legacySystem;
    }

    public string GetRequest()
    {
        return $"This is '{_legacySystem.GetSpecificRequest()}' adapted.";
    }
}
