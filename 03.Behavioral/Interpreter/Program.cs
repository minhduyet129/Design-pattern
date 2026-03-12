using Interpreter.Context;
using Interpreter.Expressions;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Interpreter Pattern Example (Math Expression) ===\n");

        // The Context might store variable values
        var context = new Context();
        context.SetVariable("a", 10);
        context.SetVariable("b", 20);
        context.SetVariable("c", 5);

        // Representing the expression: (a + b) - c
        // The tree structure of the expression:
        //        -
        //       / \
        //      +   c
        //     / \
        //    a   b
        
        IExpression expression = new SubtractExpression(
            new AddExpression(
                new VariableExpression("a"),
                new VariableExpression("b")
            ),
            new VariableExpression("c")
        );

        // Interpret the expression
        int result = expression.Interpret(context);

        Console.WriteLine("Variables:");
        Console.WriteLine("a = 10, b = 20, c = 5");
        Console.WriteLine("\nExpression: (a + b) - c");
        Console.WriteLine($"Result: {result}");

        // Change variable value and re-interpret
        Console.WriteLine("\nChanging b to 50...");
        context.SetVariable("b", 50);
        result = expression.Interpret(context);
        Console.WriteLine($"New Result: {result}");
    }
}
