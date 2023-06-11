using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionsClient.Responses
{
    public class ErrorJson
    {
        public string Expression { get; set; } = string.Empty;
        public string Endpoint { get; set; } = string.Empty;
        public uint Frequency { get; set; }
        public string ErrorType { get; set; } = string.Empty;
        public override string? ToString()
        {
            return string.Format("Expression: {0}, Endpoint: {1}, Frequency: {2}, Type: {3}", Expression, Endpoint, Frequency, ErrorType);
        }
    }
}
