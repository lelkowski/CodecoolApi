using CodecoolApi.Services.Dtos.User;

namespace CodecoolApi.Services.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthenticationResponseDto> Login(UserLoginRequestDto user);
        Task Register(UserRegistrationDto user);
    }
}