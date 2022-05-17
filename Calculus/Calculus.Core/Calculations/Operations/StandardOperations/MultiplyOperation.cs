using Calculus.Core.Tools;

namespace Calculus.Core.Calculations.Operations.StandardOperations;

public class MultiplyOperation : BinaryArithmeticOperation
{
    private static int _delay;
    
    public MultiplyOperation(double left, double right) : base(left, right)
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
        var result = LeftNumber * RightNumber;
        CheckResult(result);
        return result;
    }
}