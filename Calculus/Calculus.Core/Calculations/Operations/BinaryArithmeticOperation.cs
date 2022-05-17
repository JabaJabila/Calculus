using Calculus.Core.Tools;

namespace Calculus.Core.Calculations.Operations;

public abstract class BinaryArithmeticOperation : IArithmeticOperation
{
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
}