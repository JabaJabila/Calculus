namespace Calculus.Core.Calculations.Operations.StandardOperations;

public class DivideOperation : BinaryArithmeticOperation
{
    public DivideOperation(double left, double right, int delayMs = 0) : base(left, right, delayMs)
    {
    }

    public override double Calculate()
    {
        Thread.Sleep(DelayMs);
        return LeftNumber / RightNumber;
    }
}