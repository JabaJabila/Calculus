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
    [TestCase("-3+2=", -1.0)]
    [TestCase("-3+-2=", -5.0)]
    [TestCase("-3+(-2)=", -5.0)]
    [TestCase("(-3)+(-2)=", -5.0)]
    [TestCase("-3--2=", -1.0)]
    [TestCase("-3*4=", -12.0)]
    [TestCase("-3*0.5=", -1.5)]
    [TestCase("-3.0/0.5=", -6.0)]
    [TestCase("0/(1)=", 0)]
    public void CalculateOkExpression_GetResult(string expression, double result)
    {
        var operation = _parser.ParseFromString(expression);
        Assert.AreEqual(result, operation.Calculate());
    }
    
    [TestCase("3+2")]
    [TestCase("3+(2=")]
    [TestCase("3+2)=")]
    [TestCase("3++(2=")]
    [TestCase("3..3+2=")]
    [TestCase("3*+3=")]
    [TestCase("3++1=")]
    [TestCase(".1+1=")]
    [TestCase("+1=")]
    [TestCase("12-=")]
    [TestCase("(12)-(3=")]
    [TestCase("1,2+1=")]
    [TestCase("1+1+1=")]
    public void TryCalculateBadSyntaxExpression_GetExpressionSyntaxException(string expression)
    {
        Assert.Throws<ExpressionSyntaxException>(() =>
        {
            var operation = _parser.ParseFromString(expression);
            operation.Calculate();
        });
    }
    
    [TestCase("5/0=")]
    [TestCase("-5/0=")]
    [TestCase("0/0=")]
    [TestCase("1/-0=")]
    [TestCase("9999999999999999999999999999999*9999999999999999999999999999999999=")]
    [TestCase("9999999999999999999999999999999*-9999999999999999999999999999999999=")]
    [TestCase("99999999999999999999/-0.00000000000000000000000000001=")]
    public void TryCalculateBadMathExpression_GetArithmeticException(string expression)
    {
        var operation = _parser.ParseFromString(expression);
        Assert.Throws(Is.InstanceOf<ArithmeticException>(), () => operation.Calculate());
    }
}