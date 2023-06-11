namespace MathExpressionsService.Models.Exceptions
{
    public class MathExpressionException : Exception
    {
        public MathExpressionException() : base()
        {
        }

        public MathExpressionException(string message) : base(message)
        {
        }

        public MathExpressionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
