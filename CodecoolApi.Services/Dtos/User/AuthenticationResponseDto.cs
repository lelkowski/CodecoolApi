namespace CodecoolApi.Services.Dtos.User
{
    public class AuthenticationResponseDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string TokenExpiration { get; set; }
    }
}
