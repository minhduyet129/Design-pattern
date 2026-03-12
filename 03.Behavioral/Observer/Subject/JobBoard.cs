using Observer.Observers;
using System;
using System.Collections.Generic;

namespace Observer.Subject;

/// <summary>
/// The Subject owns some important state and notifies observers when the
/// state changes.
/// </summary>
public class JobBoard : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        Console.WriteLine("Subject: Attached an observer.");
        this._observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this._observers.Remove(observer);
        Console.WriteLine("Subject: Detached an observer.");
    }

    public void Notify(string jobTitle)
    {
        Console.WriteLine($"Subject: Notifying observers about the new job: {jobTitle}...");

        foreach (var observer in _observers)
        {
            observer.Update(jobTitle);
        }
    }

    /// <summary>
    /// Usually, the subscription logic is only a fraction of what a Subject
    /// can really do. Subjects commonly hold some important business logic,
    /// that triggers a notification method whenever something important is
    /// about to happen (or after it).
    /// </summary>
    public void AddJob(string jobTitle)
    {
        Console.WriteLine($"\nJobBoard: Adding a new job: {jobTitle}");
        this.Notify(jobTitle);
    }
}
