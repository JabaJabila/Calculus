namespace Calculus.Core.Tools;

public class ExpressionSyntaxException : CalculusException
{
    public ExpressionSyntaxException() {}
    
    public ExpressionSyntaxException(string message) : base(message) {}
}