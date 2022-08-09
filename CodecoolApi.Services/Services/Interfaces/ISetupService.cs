using Microsoft.AspNetCore.Identity;

namespace CodecoolApi.Services.Services.Interfaces
{
    public interface ISetupService
    {
        Task<List<IdentityRole>> GetAllRoles();
        Task CreateRole(string roleName);
        Task<List<IdentityUser>> GetAllUser();
    }
}