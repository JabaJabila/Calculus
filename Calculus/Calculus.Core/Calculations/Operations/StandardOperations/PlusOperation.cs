using System.Xml.Xsl;

namespace Calculus.Core.Calculations.Operations.StandardOperations;

public class PlusOperation : BinaryArithmeticOperation
{
    public PlusOperation(double left, double right, int delayMs = 0) : base(left, right, delayMs)
    {
    }

    public override double Execute()
    {
        Thread.Sleep(DelayMs);
        return LeftNumber + RightNumber;
    }
}