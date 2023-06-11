using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace MathExpressionsService.Models.Errors
{
    public class ErrorKey
    {
        public string Expression { get; set; } = string.Empty;
        public string Endpoint { get; set; } = string.Empty;

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var other = (ErrorKey)obj;
            return Expression == other.Expression && Endpoint == other.Endpoint;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = (hash * 23) + Expression.GetHashCode();
            hash = (hash * 23) + Endpoint.GetHashCode();
            return hash;
        }
    }
}
