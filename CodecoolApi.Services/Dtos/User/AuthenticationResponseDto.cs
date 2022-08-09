using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
