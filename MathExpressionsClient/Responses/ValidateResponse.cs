using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionsClient.Responses
{
    public class ValidateResponse
    {
        public bool Valid { get; set; }
        public string? Reason { get; set; }
        public override string ToString()
        {
            if (Valid)
            {
                return "Valid";
            }
            else
            {
                return string.Format("Not valid. Reason {0}", Reason);
            }
        }
    }
}
