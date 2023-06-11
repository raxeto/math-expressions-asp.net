namespace MathExpressionsService.Models.Errors
{
    public class ErrorValue
    {
        public string ErrorType { get; set; } = string.Empty;

        public uint Frequency { get; set; }
    }
}
