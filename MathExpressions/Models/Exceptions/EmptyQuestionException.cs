namespace MathExpressionsService.Models.Exceptions
{
    public class EmptyQuestionException : MathExpressionException
    {
        public EmptyQuestionException() : base("Expression is empty")
        {
        }

        public EmptyQuestionException(string message) : base(message)
        {
        }

        public EmptyQuestionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
