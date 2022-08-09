using CodecoolApi.Identity.Context;
using CodecoolApi.Services.Services;
using Microsoft.AspNetCore.Identity;

namespace CodecoolApi.Controllers
{
    /// <response code="401">Unauthenticated user can't use this endpoint</response>
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly ISetupService _service;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public SetupController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ISetupService service)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _service = service;
        }

        /// <response code="200">Returned all roles</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Gets All Roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _service.GetAllRoles());
        }

        /// <response code="200">Created new role</response>
        /// <response code="400">Can't create new role</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Creates New Role")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            await _service.CreateRole(roleName);
            return Ok($"Created new role: {roleName}");
        }

        /// <response code="200">Returned all users</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Gets All Users")]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _service.GetAllUser());
        }

        /// <response code="204">Added user to role</response>
        /// <response code="400">Can't add role to user</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Add User To Role")]
        [Route("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, roleName);

                if (result.Succeeded)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest(new { error = $"Error: Unable to add user {user.Email} to the {roleName} role" });
                }
            }

            return BadRequest(new { error = "Unable to find user" });
        }

        /// <response code="200">Created new Admin</response>
        /// <response code="400">Invalid values in required properties</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Add New Admin")]
        [Route("AddNewAdmin")]
        public async Task<IActionResult> AddNewAdmin([FromBody] UserRegistrationDto user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser != null)
                {
                    return BadRequest("Email already in use");
                }

                var newUser = new IdentityUser() { Email = user.Email, UserName = user.Username };
                await _userManager.CreateAsync(newUser, user.Password);
                await _userManager.AddToRoleAsync(newUser, "admin");
                return Ok("Created new admin");
            }
            return BadRequest("Invalid payload");
        }

        /// <response code="200">Returned roles of specific user</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Gets Roles Of Specific User")]
        [Route("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }

        /// <response code="204">Removed user from role</response>
        /// <response code="400">Can't remove role from user</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Remove User From Role")]
        [Route("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _userManager.RemoveFromRoleAsync(user, roleName);

                if (result.Succeeded)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest(new { error = $"Error: Unable to removed user {user.Email} from the {roleName} role" });
                }
            }

            return BadRequest(new { error = "Unable to find user" });
        }
    }
}
