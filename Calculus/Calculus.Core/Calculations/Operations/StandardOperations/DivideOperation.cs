using Calculus.Core.Tools;

namespace Calculus.Core.Calculations.Operations.StandardOperations;

public class DivideOperation : BinaryArithmeticOperation
{
    private static int _delay;

    public DivideOperation(double left, double right) : base(left, right)
    {
    }
    
    public static int DelayMs
    {
        get => _delay;
        set
        {
            if (value < 0)
                throw new CalculusException("Impossible to set delay < 0 ms");

            _delay = value;
        }
    }

    public override double Calculate()
    {
        Thread.Sleep(DelayMs);
        var result = LeftNumber / RightNumber;
        
        if (double.IsInfinity(result) || 
            double.IsPositiveInfinity(result) || 
            double.IsNegativeInfinity(result) ||
            double.IsNaN(result))
        {
            throw new DivideByZeroException("Attempt to divide by 0");
        }

        CheckResult(result);

        return result;
    }
}