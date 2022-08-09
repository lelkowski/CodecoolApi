using CodecoolApi.Services.Dtos.User;
using CodecoolApi.Services.Exceptions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Services
{
    public class SetupService : ISetupService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public SetupService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<List<IdentityRole>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }
        public async Task CreateRole(string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
            throw new ResourceAlreadyExistsException("Role with that name already exists");
        }
        public async Task<List<IdentityUser>> GetAllUser()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }
        public async Task AddUserToRole(string email, string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                throw new ResourceNotFoundException("Role with that name doesn't exist");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
            else
            {
                throw new ResourceNotFoundException("User with that email doesn't exist");
            }
        }
        public async Task AddNewAdmin(UserRegistrationDto user)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser != null)
            {
                throw new ResourceAlreadyExistsException("Email already in use!");
            }

            var newUser = new IdentityUser() { Email = user.Email, UserName = user.Username };
            await _userManager.CreateAsync(newUser, user.Password);
            await _userManager.AddToRoleAsync(newUser, "admin");
        }
        public async Task<List<string>> GetUserRoles(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            return (List<string>)roles;
        }
        public async Task RemoveUserFromRole(string email, string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                throw new ResourceNotFoundException("Role with that name doesn't exist");
            }
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, roleName);
            }
            else throw new ResourceNotFoundException("User with that email doesn't exist");
        }
    }
}
