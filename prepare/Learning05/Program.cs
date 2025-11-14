using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 7));
        shapes.Add(new Circle("Green", 3));

        foreach (Shape s in shapes)
        {
            Console.WriteLine($"Color: {s.GetColor()}  | Area: {s.GetArea()}");
        }
    }
}