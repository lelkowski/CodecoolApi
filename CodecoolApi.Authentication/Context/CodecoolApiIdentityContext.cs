using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodecoolApi.Identity.Context
{
    public class CodecoolApiIdentityContext : IdentityDbContext
    {
        public CodecoolApiIdentityContext(DbContextOptions<CodecoolApiIdentityContext> options)
         : base(options)
        {
        }
    }
}
