using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
