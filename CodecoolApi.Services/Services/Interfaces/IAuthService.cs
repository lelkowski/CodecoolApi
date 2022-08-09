using CodecoolApi.Services.Dtos.User;

namespace CodecoolApi.Services.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(UserLoginRequest user);
        Task Register(UserRegistrationDto user);
    }
}