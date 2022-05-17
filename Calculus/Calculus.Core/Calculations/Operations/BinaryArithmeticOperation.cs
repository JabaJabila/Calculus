namespace Calculus.Core.Calculations.Operations;

public abstract class BinaryArithmeticOperation : IArithmeticOperation
{
    public const double MaxDouble = 1e15;
    
    protected BinaryArithmeticOperation(double left, double right)
    {
        LeftNumber = left;
        RightNumber = right;
    }
    
    public double LeftNumber { get; set; }
    public double RightNumber { get; set; }
    
    
    public virtual double Calculate()
    {
        return LeftNumber;
    }

    protected void CheckResult(double result)
    {
        if (result is > MaxDouble or < -MaxDouble)
            throw new OverflowException("Absolute values are too large");
    }
}