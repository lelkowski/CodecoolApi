using System.ComponentModel.DataAnnotations;

namespace CodecoolApi.Services.Dtos.User
{
   public class UserLoginRequest
   {
      [Required]
      [EmailAddress]
      public string Email { get; set; }
      [Required]
      public string Password { get; set; }
   }
}