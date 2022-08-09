using CodecoolApi.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodecoolApi.Services.Services
{
   public class AuthService : IAuthService
   {
      private readonly IConfiguration _configuration;

      public AuthService(IConfiguration configuration)
      {
         _configuration = configuration;
      }

      public async Task<string> GenerateAnonToken()
      {
         var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    };

         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
         var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
         var token = new JwtSecurityToken(
             _configuration["Jwt:Issuer"],
             _configuration["Jwt:Audience"],
             claims,
             expires: DateTime.UtcNow.AddMinutes(10),
             signingCredentials: signIn);

         return new JwtSecurityTokenHandler().WriteToken(token);
      }
   }
}
