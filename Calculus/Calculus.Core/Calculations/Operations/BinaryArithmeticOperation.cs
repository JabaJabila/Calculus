using Calculus.Core.Tools;

namespace Calculus.Core.Calculations.Operations;

public abstract class BinaryArithmeticOperation : IArithmeticOperation
{
    protected BinaryArithmeticOperation(double left, double right, int delayMs = 0)
    {
        LeftNumber = left;
        RightNumber = right;

        if (delayMs < 0)
            throw new CalculusException("Impossible to set delay < 0 ms");

        DelayMs = delayMs;
    }
    
    public double LeftNumber { get; set; }
    public double RightNumber { get; set; }
    
    public int DelayMs { get; set; }
    
    public virtual double Execute()
    {
        return LeftNumber;
    }
}