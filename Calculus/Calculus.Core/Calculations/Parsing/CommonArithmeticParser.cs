using System.Text;
using System.Text.RegularExpressions;
using Calculus.Core.Calculations.Operations;
using Calculus.Core.Calculations.Operations.StandardOperations;
using Calculus.Core.Tools;

namespace Calculus.Core.Calculations.Parsing;

public class CommonArithmeticParser : IArithmeticParser
{
    private const char PlusChar = '+';
    private const char MinusChar = '-';
    private const char MultiplyChar = '*';
    private const char DivideChar = '/';
    private const char OpenBracket = '(';
    private const char CloseBracket = ')';

    private readonly char[] _operationChars = { PlusChar, MinusChar, MultiplyChar, DivideChar };
    
    private readonly Regex _regex = new (@"^(-?\d+(\.\d+)?){1}[\+\-\*\/]{1}(-?\d+(\.\d+)?){1}=$"); 
    
    public IArithmeticOperation ParseFromString(string expression)
    {
        expression = PrepareExpression(expression);

        var operationCharPosition = expression[1..].IndexOfAny(_operationChars);
        var leftPart = expression[..operationCharPosition];
        var rightPart = expression[(operationCharPosition + 1)..];
        var operationChar = expression[operationCharPosition];
        
        return CreateOperation(leftPart, operationChar, rightPart);
    }

    private IArithmeticOperation CreateOperation(string leftPart, char operationChar, string rightPart)
    {
        if (!double.TryParse(leftPart, out var left))
            throw new ExpressionSyntaxException("Left part of expression can't be parsed as number");
        
        if (!double.TryParse(rightPart, out var right))
            throw new ExpressionSyntaxException("Right part of expression can't be parsed as number");

        return operationChar switch
        {
            PlusChar => new PlusOperation(left, right),
            MinusChar => new MinusOperation(left, right),
            MultiplyChar => new MultiplyOperation(left, right),
            DivideChar => new DivideOperation(left, right),
            _ => throw new ExpressionSyntaxException($"Unknown operator {operationChar}")
        };
    }

    private string PrepareExpression(string expression)
    {
        var openedBrackets = 0;

        var newExpression = new StringBuilder();
        
        foreach (var symbol in expression)
        {
            switch (symbol)
            {
                case ' ':
                    continue;
                
                case OpenBracket:
                    openedBrackets++; continue;
                
                case CloseBracket:
                    openedBrackets--;
                    break;
                
                default:
                    newExpression.Append(symbol);
                    break;
            }
        }

        if (openedBrackets != 0)
            throw new ExpressionSyntaxException("Parenthesis count doesn't match");

        var result = newExpression.ToString();

        if (!_regex.IsMatch(result))
            throw new ExpressionSyntaxException("Invalid expression syntax");

        return result[..^1];
    }
}