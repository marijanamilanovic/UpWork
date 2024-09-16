using API.Core;
using API.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenCreator _creator;

        public AuthController(JwtTokenCreator creator)
        {
            _creator = creator;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request)
        {
            string token = _creator.Create(request.Email, request.Password);

            return Ok(new AuthResponse { Token = token });
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromServices] ITokenStorage storage)
        {
            storage.Remove(this.Request.GetTokenId().Value);

            return NoContent();
        }
    }
}
