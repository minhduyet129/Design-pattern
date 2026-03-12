using System;

namespace State.States;

public class NoCoinState : StateBase
{
    public override void InsertCoin()
    {
        Console.WriteLine("You inserted a coin.");
        _vendingMachine.TransitionTo(new HasCoinState());
    }

    public override void EjectCoin()
    {
        Console.WriteLine("You haven't inserted a coin.");
    }

    public override void TurnCrank()
    {
        Console.WriteLine("You turned, but there's no coin.");
    }

    public override void Dispense()
    {
        Console.WriteLine("You need to pay first.");
    }
}

public class HasCoinState : StateBase
{
    public override void InsertCoin()
    {
        Console.WriteLine("You can't insert another coin.");
    }

    public override void EjectCoin()
    {
        Console.WriteLine("Coin returned.");
        _vendingMachine.TransitionTo(new NoCoinState());
    }

    public override void TurnCrank()
    {
        Console.WriteLine("You turned...");
        _vendingMachine.TransitionTo(new SoldState());
    }

    public override void Dispense()
    {
        Console.WriteLine("No gumball dispensed.");
    }
}

public class SoldState : StateBase
{
    public override void InsertCoin()
    {
        Console.WriteLine("Please wait, we're already giving you a gumball.");
    }

    public override void EjectCoin()
    {
        Console.WriteLine("Sorry, you already turned the crank.");
    }

    public override void TurnCrank()
    {
        Console.WriteLine("Turning twice doesn't get you another gumball!");
    }

    public override void Dispense()
    {
        _vendingMachine.ReleaseBall();
        if (_vendingMachine.Count > 0)
        {
            _vendingMachine.TransitionTo(new NoCoinState());
        }
        else
        {
            Console.WriteLine("Oops, out of gumballs!");
            _vendingMachine.TransitionTo(new SoldOutState());
        }
    }
}

public class SoldOutState : StateBase
{
    public override void InsertCoin()
    {
        Console.WriteLine("You can't insert a coin, the machine is sold out.");
    }

    public override void EjectCoin()
    {
        Console.WriteLine("You can't eject, you haven't inserted a coin yet.");
    }

    public override void TurnCrank()
    {
        Console.WriteLine("You turned, but there are no gumballs.");
    }

    public override void Dispense()
    {
        Console.WriteLine("No gumball dispensed.");
    }
}
