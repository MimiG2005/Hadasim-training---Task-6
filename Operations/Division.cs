using System;

namespace Operations
{
    public class Division : IOperation
    {
        public string Symbol => "/";   // הסימן שמייצג חילוק

        public double Compute(params double[] numbers)
        {
            if (numbers.Length == 0)
                throw new ArgumentException("No numbers provided");

            double result = numbers[0];

            // אם יש יותר ממספר אחד, מחלקים בזה אחר זה
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                    throw new DivideByZeroException("Cannot divide by zero");
                result /= numbers[i];
            }

            return result;
        }
    }
}
