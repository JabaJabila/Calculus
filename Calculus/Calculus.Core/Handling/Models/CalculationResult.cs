namespace Calculus.Core.Handling.Models;

public class CalculationResult
{
    public CalculationResult(string expression, double result)
    {
        Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        Result = result;
        IsSuccessful = true;
        CaughtException = null;
    }

    public CalculationResult(string expression, Exception exception)
    {
        Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        CaughtException = exception ?? throw new ArgumentNullException(nameof(exception));
        IsSuccessful = false;
    }
    
    public bool IsSuccessful { get; }
    public Exception? CaughtException { get; }
    public string Expression { get; }
    public double Result { get; }
}