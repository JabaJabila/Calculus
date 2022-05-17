using Calculus.Core.Calculations.Operations;

namespace Calculus.Core.Handling.Models;

public class CalculationRequest
{
    public CalculationRequest(string expression, IArithmeticOperation operation)
    {
        Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        Operation = operation ?? throw new ArgumentNullException(nameof(operation));
    }
    
    public string Expression { get; }
    public IArithmeticOperation Operation { get; }
}