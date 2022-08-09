using CodecoolApi.Identity.Context;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CodecoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        /// <response code="400">Invalid register request</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Register New User")]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto user)
        {
            if (ModelState.IsValid)
            {
                await _service.Register(user);
                return Ok($"Registered new user with email: {user.Email}");
            }
            return BadRequest("Invalid payload");
        }


        /// <response code="400">Invalid login request</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Login with Email and Password")]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto user)
        {
            if (ModelState.IsValid)
            {
                var token = await _service.Login(user);
                return Ok(token);
            }

            return BadRequest("Invalid payload");
        }


    }
}
