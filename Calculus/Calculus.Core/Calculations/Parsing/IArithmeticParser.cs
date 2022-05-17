using Calculus.Core.Calculations.Operations;

namespace Calculus.Core.Calculations.Parsing;

public interface IArithmeticParser
{
    IArithmeticOperation ParseFromString(string expression);
}