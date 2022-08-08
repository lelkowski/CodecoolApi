using CodecoolApi.Data.Context;
using CodecoolApi.Data.DAL.Interfaces;
using CodecoolApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Data.DAL.Repositories
{
    public class MaterialRepository : Repository<EducationalMaterial>, IMaterialRepository
    {
        public MaterialRepository(CodecoolApiContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EducationalMaterial>> GetAllWithNestedDataAsync()
         => await _context.Materials
                .Include(material => material.Author)
                .Include(material => material.EducationalMaterialType)
                .Include(material => material.Reviews)
                .ToListAsync();

        public async Task<EducationalMaterial> GetWithNestedDataAsync(int id)
        => await _context.Materials
                .Include(material => material.Author)
                .Include(material => material.EducationalMaterialType)
                .Include(material => material.Reviews)
                .FirstOrDefaultAsync(x => x.Id == id);
    }
}
