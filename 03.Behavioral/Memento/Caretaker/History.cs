using Memento.Mementos;
using Memento.Originator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Memento.Caretaker;

/// <summary>
/// The Caretaker doesn't depend on the Concrete Memento class. 
/// Therefore, it doesn't have access to the originator's state, 
/// stored inside the memento. It works with all mementos via the 
/// base Memento interface.
/// </summary>
public class History
{
    private List<IMemento> _mementos = new List<IMemento>();
    private Editor _originator;

    public History(Editor originator)
    {
        this._originator = originator;
    }

    public void Backup()
    {
        Console.WriteLine("\nHistory: Saving Editor's state...");
        this._mementos.Add(this._originator.Save());
    }

    public void Undo()
    {
        if (this._mementos.Count == 0)
        {
            return;
        }

        var memento = this._mementos.Last();
        this._mementos.Remove(memento);

        Console.WriteLine("History: Restoring state to: " + memento.GetName());

        try
        {
            this._originator.Restore(memento);
        }
        catch (Exception)
        {
            this.Undo();
        }
    }

    public void ShowHistory()
    {
        Console.WriteLine("History: Here's the list of mementos:");

        foreach (var memento in this._mementos)
        {
            Console.WriteLine(memento.GetName());
        }
    }
}
