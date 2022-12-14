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

        /// <response code="200">Registered new user</response>
        /// <response code="400">Invalid register request</response>
        /// <response code="409">User with those credentials exists</response>
        [SwaggerOperation(Summary = "Register New User")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto user)
        {
            if (ModelState.IsValid)
            {
                await _service.Register(user);
                return Ok($"Registered new user with email: {user.Email}");
            }
            return BadRequest("Invalid payload");
        }


        /// <response code="200">Login succesful</response>
        /// <response code="400">Invalid login request</response>
        /// <response code="403">Credentials doesn't match</response>
        [SwaggerOperation(Summary = "Login with Email and Password")]
        [HttpPost("login")]
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
