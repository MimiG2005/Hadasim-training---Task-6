namespace Operations
{
    public interface IOperation
    {
        string Symbol { get; }
        double Compute(params double[] numbers); // תמיכה במספרים רבים
    }
}
