using System;

namespace Memento.Mementos;

/// <summary>
/// The Memento interface provides a way to retrieve the memento's metadata, 
/// such as creation date or name. However, it doesn't expose the 
/// Originator's state.
/// </summary>
public interface IMemento
{
    string GetName();
    DateTime GetDate();
}

/// <summary>
/// The Concrete Memento contains the infrastructure for storing the 
/// Originator's state.
/// </summary>
public class ConcreteMemento : IMemento
{
    private string _state;
    private DateTime _date;

    public ConcreteMemento(string state)
    {
        this._state = state;
        this._date = DateTime.Now;
    }

    /// <summary>
    /// The Originator uses this method when restoring its state.
    /// </summary>
    public string GetState()
    {
        return this._state;
    }

    public string GetName()
    {
        return $"{this._date} / ({this._state.Substring(0, Math.Min(this._state.Length, 9))}...)";
    }

    public DateTime GetDate()
    {
        return this._date;
    }
}
