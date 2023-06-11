namespace MathExpressionsService.Models.Errors
{
    public class ErrorJson
    {
        public string Expression { get; set; }
        public string Endpoint { get; set; }
        public uint Frequency { get; set; }
        public string ErrorType { get; set; }
        public ErrorJson(ErrorKey key, ErrorValue val)
        { 
            Expression = key.Expression;
            Endpoint = key.Endpoint;

            Frequency = val.Frequency;
            ErrorType = val.ErrorType;
        }
    }
}
