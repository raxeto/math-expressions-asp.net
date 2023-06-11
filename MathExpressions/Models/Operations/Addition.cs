namespace MathExpressionsService.Models.Operations
{
    public class Addition : IMathOperation
    {
        string IMathOperation.Expression { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        decimal IMathOperation.Eval(decimal operand1, decimal operand2)
        {
            return operand1 + operand2;
        }
    }
}
