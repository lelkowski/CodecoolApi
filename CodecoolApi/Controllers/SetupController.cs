using CodecoolApi.Identity.Context;
using CodecoolApi.Services.Dtos.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace CodecoolApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly CodecoolApiIdentityContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public SetupController(CodecoolApiIdentityContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets All Roles")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates New Role")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                //create the roles and seed them to the database: Question 1
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));

                if (roleResult.Succeeded)
                {
                    return Ok(new { result = $"Role {roleName} added successfully" });
                }
                else
                {
                    return BadRequest(new { error = $"Issue adding the new {roleName} role" });
                }
            }

            return BadRequest(new { error = "Role already exist" });
        }

        // Get all users
        [HttpGet]
        [SwaggerOperation(Summary = "Gets All Users")]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        // Add User to role
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
                    return Ok(new { result = $"User {user.Email} added to the {roleName} role" });
                }
                else
                {
                    return BadRequest(new { error = $"Error: Unable to add user {user.Email} to the {roleName} role" });
                }
            }

            // User doesn't exist
            return BadRequest(new { error = "Unable to find user" });
        }

        // Add new admin
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

        // Get specific user role
        [HttpGet]
        [SwaggerOperation(Summary = "Gets Roles Of Specific User")]
        [Route("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string email)
        {
            // Resolve the user via their email
            var user = await _userManager.FindByEmailAsync(email);
            // Get the roles for the user
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }

        // Remove User to role
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
                    return Ok(new { result = $"User {user.Email} removed from the {roleName} role" });
                }
                else
                {
                    return BadRequest(new { error = $"Error: Unable to removed user {user.Email} from the {roleName} role" });
                }
            }

            // User doesn't exist
            return BadRequest(new { error = "Unable to find user" });
        }
    }
}
