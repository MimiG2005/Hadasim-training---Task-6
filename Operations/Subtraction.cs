namespace Operations
{
    public class Subtraction : IOperation
    {
        public string Symbol => "-";

        public double Compute(params double[] numbers)
        {
            if (numbers.Length == 0)
                return 0;

            double result = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                result -= numbers[i];
            }

            return result;
        }
    }
}
