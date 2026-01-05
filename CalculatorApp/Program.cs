
using src;
using Operations;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var operations = new List<IOperation> { new Addition(), new Subtraction(), new Multiplication(), new Division() };
        var calc = new Calculator(operations);

        Console.WriteLine("Enter expression:");
        string expr = Console.ReadLine();
        try
        {
            double result = calc.Calculate(expr);
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }
}
