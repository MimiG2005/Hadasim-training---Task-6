namespace Operations
{
    public class Multiplication : IOperation
    {
        public string Symbol => "*";  // הסימן שמזהה את הפעולה

        public double Compute(params double[] numbers)
        {
            if (numbers.Length == 0)
                return 0;

            double result = 1;
            foreach (var n in numbers)
                result *= n;

            return result;
        }
    }
}

