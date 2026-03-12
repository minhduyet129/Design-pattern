using System.Collections.Generic;

namespace Interpreter.Context;

/// <summary>
/// The Context contains information that's global to the interpreter.
/// In this case, it might store variables and their values.
/// </summary>
public class Context
{
    private Dictionary<string, int> _variables = new Dictionary<string, int>();

    public void SetVariable(string name, int value)
    {
        _variables[name] = value;
    }

    public int GetVariable(string name)
    {
        if (_variables.TryGetValue(name, out int value))
        {
            return value;
        }
        return 0; // Default or throw error
    }
}
