using Microsoft.AspNetCore.Mvc;
using VVSecurity.Application.UseCases;

namespace VVSecurity.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenerateSecurityPassController : ControllerBase
    {
        [HttpGet("generateSecurityPass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Generate(
            [FromServices] IGenerateSecurityPassUseCase useCase)
        {
            var response = await useCase.Execute();

            return Ok(response);
        }
    }
}
