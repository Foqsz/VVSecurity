using Microsoft.AspNetCore.Mvc;
using VVSecurity.Application.UseCases;
using VVSecurity.Communication.Request;
using VVSecurity.Exceptions;

namespace VVSecurity.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenerateSecurityPassController : ControllerBase
    {
        [HttpPost("generateSecurityPass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorOnValidationException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Generate(
            [FromServices] IGenerateSecurityPassUseCase useCase,
            [FromBody] GenerateSecurityPassRequest request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
