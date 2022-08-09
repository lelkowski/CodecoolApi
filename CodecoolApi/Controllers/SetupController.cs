namespace CodecoolApi.Controllers
{
    /// <response code="401">Unauthenticated user can't use this endpoint</response>
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly ISetupService _service;

        public SetupController(ISetupService service)
        {
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
        /// <response code="409">Role with that name already exists</response>
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
        /// <response code="404">Role or user doesn't exist</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Add User To Role")]
        [Route("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string email, string roleName)
        {
            await _service.AddUserToRole(email, roleName);
            return NoContent();
        }

        /// <response code="200">Created new Admin</response>
        /// <response code="400">Invalid values in required properties</response>
        /// <response code="409">Admin with those credentials exists</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Add New Admin")]
        [Route("AddNewAdmin")]
        public async Task<IActionResult> AddNewAdmin([FromBody] UserRegistrationDto user)
        {
            if (ModelState.IsValid)
            {
                await _service.AddNewAdmin(user);
                return Ok("Added New Admin");
            }
            return BadRequest("Invalid payload");
        }

        /// <response code="200">Returned roles of specific user</response>
        /// <response code="404">Selected user doesn't exist</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Gets Roles Of Specific User")]
        [Route("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string email)
        {
            return Ok(await _service.GetUserRoles(email));
        }

        /// <response code="204">Removed user from role</response>
        /// <response code="400">Can't remove role from user</response>
        /// <response code="404">Role or user doesn't exist</response>
        [HttpDelete]
        [SwaggerOperation(Summary = "Remove User From Role")]
        [Route("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(string email, string roleName)
        {
            await _service.RemoveUserFromRole(email, roleName);
            return NoContent();
        }
    }
}
