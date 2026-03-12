using Observer.Observers;
using Observer.Subject;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Observer Pattern Example (Job Board) ===\n");

        // 1. Create Subject
        var jobBoard = new JobBoard();

        // 2. Create Observers
        var alice = new JobSeeker("Alice");
        var bob = new JobSeeker("Bob");
        var charlie = new JobSeeker("Charlie");

        // 3. Attach Observers
        jobBoard.Attach(alice);
        jobBoard.Attach(bob);

        // 4. Trigger events
        jobBoard.AddJob("Senior .NET Developer");

        // 5. Change subscriptions
        Console.WriteLine("\n--- Updating subscriptions ---");
        jobBoard.Attach(charlie);
        jobBoard.Detach(alice);

        // 6. Trigger another event
        jobBoard.AddJob("Software Architect");
    }
}
