using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;
using System.Net;
using MathExpressionsClient.Responses;

namespace MathExpressionsClient
{
    public class MathExpressionServiceClient
    {
        private Uri _baseUrl;
        public MathExpressionServiceClient(string baseUrl)
        {
            _baseUrl = new Uri(baseUrl);
        }
        public async Task<string> SendPostEvaluate(string mathExpression)
        {
            var values = new Dictionary<string, string>();
            values.Add("expression", mathExpression);

            using (var httpClient = new HttpClient() { BaseAddress = _baseUrl })
            {
                try
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync("/evaluate", values);

                    var evalResponse = await response.Content.ReadFromJsonAsync<EvaluateResponse>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return evalResponse != null ? evalResponse.Result : string.Empty;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public async Task<string> SendPostValidate(string mathExpression)
        {
            var values = new Dictionary<string, string>();
            values.Add("expression", mathExpression);

            using (var httpClient = new HttpClient() { BaseAddress = _baseUrl })
            {
                try
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync("/validate", values);

                    var validateResponse = await response.Content.ReadFromJsonAsync<ValidateResponse>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return validateResponse != null ? validateResponse.ToString() : string.Empty;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        public async Task<ErrorJson[]?> SendGetErrors()
        {
            using (var httpClient = new HttpClient() { BaseAddress = _baseUrl })
            {
                HttpResponseMessage response = await httpClient.GetAsync("/errors");

                var errors = await response.Content.ReadFromJsonAsync<ErrorJson[]>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return errors;
            }
        }
    }
}
