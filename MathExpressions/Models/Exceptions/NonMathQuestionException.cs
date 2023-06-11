namespace MathExpressionsService.Models.Exceptions
{
    public class NonMathQuestionException : MathExpressionException
    {
        public NonMathQuestionException() : base("Non-math question")
        {
        }

        public NonMathQuestionException(string message) : base(message)
        {
        }

        public NonMathQuestionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
