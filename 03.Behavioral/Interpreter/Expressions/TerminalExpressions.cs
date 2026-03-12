using Interpreter.Context;

namespace Interpreter.Expressions;

/// <summary>
/// Terminal Expression represents the terminal symbols in the grammar.
/// In this case, a number or a variable name.
/// </summary>
public class NumberExpression : IExpression
{
    private int _number;

    public NumberExpression(int number)
    {
        _number = number;
    }

    public int Interpret(Context.Context context)
    {
        return _number;
    }
}

public class VariableExpression : IExpression
{
    private string _name;

    public VariableExpression(string name)
    {
        _name = name;
    }

    public int Interpret(Context.Context context)
    {
        return context.GetVariable(_name);
    }
}
