using Prototype.Prototypes;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Prototype Pattern Example\n");

        List<Shape> shapes = new List<Shape>();
        List<Shape> shapesCopy = new List<Shape>();

        Circle circle = new Circle();
        circle.X = 10;
        circle.Y = 10;
        circle.Radius = 20;
        circle.Color = "Red";
        shapes.Add(circle);

        Circle anotherCircle = (Circle)circle.Clone();
        shapes.Add(anotherCircle);

        Rectangle rectangle = new Rectangle();
        rectangle.Width = 10;
        rectangle.Height = 20;
        rectangle.Color = "Blue";
        shapes.Add(rectangle);

        Console.WriteLine("Cloning shapes...");
        foreach (var shape in shapes)
        {
            shapesCopy.Add(shape.Clone());
        }

        Console.WriteLine("\nComparison:");
        for (int i = 0; i < shapes.Count; i++)
        {
            if (shapes[i] != shapesCopy[i])
            {
                Console.WriteLine($"{i}: Shapes are different objects (Good!)");
                if (shapes[i].Equals(shapesCopy[i])) // This would require overriding Equals, which we haven't done.
                {
                    Console.WriteLine($"{i}: And they are identical (Good!)");
                }
                else
                {
                     // Let's just print their values to show they are clones.
                     Console.WriteLine($"Original: {shapes[i]}");
                     Console.WriteLine($"Clone:    {shapesCopy[i]}");
                }
            }
            else
            {
                Console.WriteLine($"{i}: Shape objects are the same (Bad!)");
            }
        }

        // Demonstrate independence
        Console.WriteLine("\nModifying the clone of the first circle...");
        Circle firstCircleClone = (Circle)shapesCopy[0];
        firstCircleClone.Color = "Green";
        firstCircleClone.Radius = 100;

        Console.WriteLine($"Original Circle: {shapes[0]}");
        Console.WriteLine($"Modified Clone:  {shapesCopy[0]}");
    }
}
