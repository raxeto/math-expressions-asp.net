using MathExpressions.Models;
using MathExpressionsService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace MathExpressions.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly MathExpressionLogger _mathExpressionLogger;
        public ValidateController(MathExpressionLogger mathExpressionLogger)
        {
            _mathExpressionLogger = mathExpressionLogger;
        }

        [HttpPost]
        public IActionResult Eval([FromBody] MathExpression simpleExpression)
        {
            var result = simpleExpression.Validate();

            if (result.isValid)
            {
                return Ok(new { valid = true });
            }
            else
            {
                if (result.exception != null)
                {
                    _mathExpressionLogger.Error(simpleExpression.Expression, result.exception, ControllerContext.ActionDescriptor.ControllerName);
                }

                return Ok(new { valid = false, reason = result.exception?.Message });
            }
        }
    }
}
