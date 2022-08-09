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
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(IConfiguration configuration, IAuthService authService, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, CodecoolApiIdentityContext context)
        {
            _service = authService;
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Register New User")]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser != null)
                {
                    return BadRequest("Email already in use");
                }

                var newUser = new IdentityUser() { Email = user.Email, UserName = user.Username };
                var isCreated = await _userManager.CreateAsync(newUser, user.Password);
                if (isCreated.Succeeded)
                {
                    var jwtToken = await GenerateJwtToken(newUser);

                    return Ok(jwtToken);
                }
                else
                {
                    return BadRequest(isCreated.Errors.Select(x => x.Description).ToList().ToString());
                }
            }

            return BadRequest("Invalid payload");
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Login with Email and Password")]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser == null)
                {
                    return BadRequest("Invalid login request");
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

                if (!isCorrect)
                {
                    return BadRequest("Invalid login request");
                }

                var jwtToken = await GenerateJwtToken(existingUser);

                return Ok(jwtToken);
            }

            return BadRequest("Invalid payload");
        }

        private async Task<IActionResult> GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var claims = await GetValidClaims(user);

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        private async Task<List<Claim>> GetValidClaims(IdentityUser user)
        {
            IdentityOptions _options = new IdentityOptions();
            var claims = new List<Claim>
         {
               new Claim("Id", user.Id),
               new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
               new Claim("UserId", user.Id.ToString()),
               new Claim("UserName", user.UserName),
         };

            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            claims.AddRange(userClaims);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            return claims;
        }
    }
}
