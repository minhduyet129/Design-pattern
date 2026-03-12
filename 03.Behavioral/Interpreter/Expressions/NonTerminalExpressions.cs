using Interpreter.Context;

namespace Interpreter.Expressions;

/// <summary>
/// Non-terminal Expressions represent the rules of the grammar.
/// They contain references to other expressions (terminal or non-terminal).
/// </summary>
public class AddExpression : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public AddExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret(Context.Context context)
    {
        return _left.Interpret(context) + _right.Interpret(context);
    }
}

public class SubtractExpression : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public SubtractExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret(Context.Context context)
    {
        return _left.Interpret(context) - _right.Interpret(context);
    }
}
