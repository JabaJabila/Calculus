namespace Calculus.Core.Calculations.Operations.StandardOperations;

public class MultiplyOperation : BinaryArithmeticOperation
{
    public MultiplyOperation(double left, double right, int delayMs = 0) : base(left, right, delayMs)
    {
    }

    public override double Calculate()
    {
        Thread.Sleep(DelayMs);
        return LeftNumber * RightNumber;
    }
}