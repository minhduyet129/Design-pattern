using Interpreter.Context;

namespace Interpreter.Expressions;

/// <summary>
/// The Abstract Expression declares an interface for executing an operation.
/// </summary>
public interface IExpression
{
    int Interpret(Context.Context context);
}
