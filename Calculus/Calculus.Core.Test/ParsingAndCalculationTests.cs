using Calculus.Core.Calculations.Parsing;
using NUnit.Framework;

namespace Calculus.Core.Test;

public class ParsingAndCalculationTests
{
    private IArithmeticParser _parser;
    
    [SetUp]
    public void Setup()
    {
        _parser = new CommonArithmeticParser();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}