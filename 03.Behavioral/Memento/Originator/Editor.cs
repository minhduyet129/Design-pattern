using Memento.Mementos;
using System;
using System.Threading;

namespace Memento.Originator;

/// <summary>
/// The Originator holds some important state that may change over time. 
/// It also defines a method for saving the state inside a memento and 
/// another method for restoring the state from it.
/// </summary>
public class Editor
{
    // For the sake of simplicity, the state is stored in a single variable.
    private string _state;

    public Editor(string state)
    {
        this._state = state;
        Console.WriteLine($"Editor: Initial state is: {_state}");
    }

    /// <summary>
    /// The Originator's business logic may affect its internal state. 
    /// Therefore, the client should backup the state before launching 
    /// methods of the business logic via the save() method.
    /// </summary>
    public void Type(string words)
    {
        Console.WriteLine("Editor: I'm typing...");
        this._state += words;
        Console.WriteLine($"Editor: State has changed to: {_state}");
    }

    /// <summary>
    /// Saves the current state inside a memento.
    /// </summary>
    public IMemento Save()
    {
        return new ConcreteMemento(this._state);
    }

    /// <summary>
    /// Restores the Originator's state from a memento object.
    /// </summary>
    public void Restore(IMemento memento)
    {
        if (!(memento is ConcreteMemento))
        {
            throw new Exception("Unknown memento class " + memento.ToString());
        }

        this._state = ((ConcreteMemento)memento).GetState();
        Console.Write($"Editor: My state has changed to: {_state}\n");
    }

    public string GetContent() => _state;
}
