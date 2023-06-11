using MathExpressionsService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MathExpressionsService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        private readonly MathExpressionLogger _mathExpressionLogger;
        public ErrorsController(MathExpressionLogger mathExpressionLogger)
        {
            _mathExpressionLogger = mathExpressionLogger;
        }

        [HttpGet]
        public IActionResult GetErrors()
        {
            return Ok(_mathExpressionLogger.GetAllErrors());
        }
    }
}
