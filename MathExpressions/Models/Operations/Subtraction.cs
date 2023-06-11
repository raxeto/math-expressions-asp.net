namespace MathExpressionsService.Models.Operations
{
    public class Subtraction : IMathOperation
    {
        public string Expression { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public decimal Eval(decimal operand1, decimal operand2)
        {
            return operand1 - operand2;
        }
    }
}
