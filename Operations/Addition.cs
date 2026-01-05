using Operations;

namespace Operations
{
    public class Addition : IOperation
    {
        public string Symbol => "+";    // הסימן שמזהה את הפעולה

        public double Compute(params double[] numbers)
        {
            double sum = 0;
            foreach (var n in numbers)
                sum += n;
            return sum;
        }
    }
}
