namespace MathExpressionsService.Models.Operations
{
    public interface IMathOperation
    {
        public string Expression { get; set; }

        public decimal Eval(decimal operand1, decimal operand2);
    }
}
