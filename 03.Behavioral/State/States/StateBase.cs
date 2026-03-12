using State.Context;

namespace State.States;

/// <summary>
/// The base State class declares methods that all Concrete State should
/// implement and also provides a backreference to the Context object,
/// associated with the State. This backreference can be used by States to
/// transition the Context to another State.
/// </summary>
public abstract class StateBase
{
    protected VendingMachine _vendingMachine;

    public void SetVendingMachine(VendingMachine vendingMachine)
    {
        this._vendingMachine = vendingMachine;
    }

    public abstract void InsertCoin();
    public abstract void EjectCoin();
    public abstract void TurnCrank();
    public abstract void Dispense();
}
