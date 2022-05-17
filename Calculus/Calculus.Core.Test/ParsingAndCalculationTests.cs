using System;
using Calculus.Core.Calculations.Parsing;
using Calculus.Core.Tools;
using NUnit.Framework;

namespace Calculus.Core.Test;

[TestFixture]
public class ParsingAndCalculationTests
{
    private IArithmeticParser _parser;
    
    [SetUp]
    public void Setup()
    {
        _parser = new CommonArithmeticParser();
    }

    [TestCase("3+2=", 5.0)]
    public void CalculateOkExpression_GetResult(string expression, double result)
    {
        var operation = _parser.ParseFromString(expression);
        Assert.AreEqual(result, operation.Calculate());
    }
    
    [TestCase("3+2")]
    public void TryCalculateBadSyntaxExpression_GetExpressionSyntaxException(string expression)
    {
        Assert.Throws<ExpressionSyntaxException>(() =>
        {
            var operation = _parser.ParseFromString(expression);
            operation.Calculate();
        });
    }
    
    [TestCase("5/0=")]
    public void TryCalculateBadMathExpression_GetArithmeticException(string expression)
    {
        var operation = _parser.ParseFromString(expression);
        Assert.Throws(Is.InstanceOf<ArithmeticException>(), () => operation.Calculate());
    }
}