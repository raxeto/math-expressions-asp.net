namespace MathExpressionsService.Models.Exceptions
{
    public class InvalidSyntaxException : MathExpressionException
    {
        public InvalidSyntaxException() : base("Expression with invalid syntax")
        {
        }

        public InvalidSyntaxException(string message) : base(message)
        {
        }

        public InvalidSyntaxException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
