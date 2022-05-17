namespace Calculus.Core.Tools;

public class CalculusException : Exception
{
    public CalculusException() : base() {}
    
    public CalculusException(string message) : base(message) {}
}