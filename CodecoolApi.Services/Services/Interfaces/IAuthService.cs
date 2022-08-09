using CodecoolApi.Services.Dtos.User;

namespace CodecoolApi.Services.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthenticationResponse> Login(UserLoginRequest user);
        Task Register(UserRegistrationDto user);
    }
}