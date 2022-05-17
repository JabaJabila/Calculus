namespace Calculus.Core.Calculations.Operations;

public interface IArithmeticOperation
{
    int DelayMs { get; set; }
    double Calculate();
}