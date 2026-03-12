using System;

namespace Observer.Observers;

/// <summary>
/// Concrete Observers react to the updates issued by the Subject they had
/// been attached to.
/// </summary>
public class JobSeeker : IObserver
{
    private string _name;

    public JobSeeker(string name)
    {
        _name = name;
    }

    public void Update(string jobTitle)
    {
        Console.WriteLine($"{_name}: I'm interested in the '{jobTitle}' position!");
    }
}
