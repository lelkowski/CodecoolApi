using CodecoolApi.Services.Dtos.User;
using Microsoft.AspNetCore.Identity;

namespace CodecoolApi.Services.Services.Interfaces
{
    public interface ISetupService
    {
        Task<List<IdentityRole>> GetAllRoles();
        Task CreateRole(string roleName);
        Task<List<IdentityUser>> GetAllUser();
        Task AddUserToRole(string email, string roleName);
        Task AddNewAdmin(UserRegistrationDto user);
        Task<List<string>> GetUserRoles(string email);
        Task RemoveUserFromRole(string email, string roleName);

        Task RemoveUser(string email);
    }
}