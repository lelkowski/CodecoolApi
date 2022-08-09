namespace CodecoolApi.Services.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> GenerateAnonToken();
    }
}
