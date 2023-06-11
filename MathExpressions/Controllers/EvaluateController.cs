using MathExpressions.Models;
using MathExpressionsService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;

namespace MathExpressions.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EvaluateController : ControllerBase
    {
        private readonly MathExpressionLogger _mathExpressionLogger;
        public EvaluateController(MathExpressionLogger mathExpressionLogger)
        {
            _mathExpressionLogger = mathExpressionLogger;
        }

        [HttpPost]
        public IActionResult Eval([FromBody] MathExpression simpleExpression)
        {
            try
            {
                decimal result = simpleExpression.Evaluate();

                return Ok(new { result = result.ToString() });
            }
            catch (Exception ex)
            {
                _mathExpressionLogger.Error(simpleExpression.Expression, ex, ControllerContext.ActionDescriptor.ControllerName);

                return StatusCode((int)HttpStatusCode.BadRequest, new { result = ex.Message });
            }
        }


    }
}
