using MathExpressionsService.Models.Errors;
using MathExpressionsService.Models.Exceptions;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;

namespace MathExpressionsService.Models
{
    public class MathExpressionLogger
    {
        private readonly ConcurrentDictionary<ErrorKey, ErrorValue> _errors = new ConcurrentDictionary<ErrorKey, ErrorValue>();
        public void Error(string expression, Exception exception, string endpoint)
        {
            var key = new ErrorKey { Expression = expression, Endpoint = endpoint };

            _errors.AddOrUpdate(key,
                // If the key is not present in the dictionary, add a new ErrorValue with a frequency of 1
                k => new ErrorValue { ErrorType = exception.Message, Frequency = 1 },
                // If the key is already present, update the ErrorValue by incrementing the frequency
                (k, oldValue) => new ErrorValue { ErrorType = exception.Message, Frequency = oldValue.Frequency + 1 });
        }
        public ErrorJson[] GetAllErrors()
        {
            var errorsArray = _errors.ToArray();

            ErrorJson[] res = new ErrorJson[errorsArray.Length];

            for (int i = 0; i < errorsArray.Length; ++i)
            {
                res[i] = new ErrorJson(errorsArray[i].Key, errorsArray[i].Value);
            }

            return res;
        }
    }
}
