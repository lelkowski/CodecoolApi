using CodecoolApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Data.Context
{
    public class CodecoolApiContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<EducationalMaterial> Materials { get; set; }
        public DbSet<EducationalMaterialType> Types { get; set; }
        public DbSet<EducationalMaterialReview> Reviews { get; set; }

        public CodecoolApiContext(DbContextOptions<CodecoolApiContext> options)
            : base(options) { }
    }
}
