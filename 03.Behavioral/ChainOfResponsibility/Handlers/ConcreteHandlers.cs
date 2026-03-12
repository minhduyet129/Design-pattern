namespace ChainOfResponsibility.Handlers;

class MonkeyHandler : BaseHandler
{
    public override object? Handle(object request)
    {
        if ((request as string) == "Banana")
        {
            return $"Monkey: I'll eat the {request}.\n";
        }
        else
        {
            return base.Handle(request);
        }
    }
}

class SquirrelHandler : BaseHandler
{
    public override object? Handle(object request)
    {
        if ((request as string) == "Nut")
        {
            return $"Squirrel: I'll eat the {request}.\n";
        }
        else
        {
            return base.Handle(request);
        }
    }
}

class DogHandler : BaseHandler
{
    public override object? Handle(object request)
    {
        if ((request as string) == "MeatBall")
        {
            return $"Dog: I'll eat the {request}.\n";
        }
        else
        {
            return base.Handle(request);
        }
    }
}
