using State.States;
using System;

namespace State.Context;

/// <summary>
/// The Context defines the interface of interest to clients. It also
/// maintains a reference to an instance of a State subclass, which
/// represents the current state of the Context.
/// </summary>
public class VendingMachine
{
    // A reference to the current state of the Context.
    private StateBase _state = null;
    
    public int Count { get; private set; } = 0;

    public VendingMachine(int numberOfGumballs)
    {
        Count = numberOfGumballs;
        if (Count > 0)
        {
            // Initial state
            TransitionTo(new NoCoinState());
        }
        else
        {
            TransitionTo(new SoldOutState());
        }
    }

    // The Context allows changing the State object at runtime.
    public void TransitionTo(StateBase state)
    {
        Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
        this._state = state;
        this._state.SetVendingMachine(this);
    }

    // The Context delegates part of its behavior to the current State object.
    public void InsertCoin()
    {
        _state.InsertCoin();
    }

    public void EjectCoin()
    {
        _state.EjectCoin();
    }

    public void TurnCrank()
    {
        _state.TurnCrank();
        _state.Dispense();
    }

    public void ReleaseBall()
    {
        Console.WriteLine("A gumball comes rolling out the slot...");
        if (Count > 0)
        {
            Count--;
        }
    }
}
