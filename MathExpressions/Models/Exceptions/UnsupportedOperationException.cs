namespace MathExpressionsService.Models.Exceptions
{
    public class UnsupportedOperationException : MathExpressionException
    {
        public UnsupportedOperationException() : base("Unsupported operation")
        {
        }

        public UnsupportedOperationException(string message) : base(message)
        {
        }

        public UnsupportedOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
