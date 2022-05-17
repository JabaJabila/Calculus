using Calculus.Core.Calculations.Parsing;

var parser = new CommonArithmeticParser();
Console.WriteLine($"{parser.ParseFromString("2 + 2 =").Calculate()}");