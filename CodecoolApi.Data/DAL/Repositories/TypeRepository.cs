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
    public class TypeRepository : Repository<EducationalMaterialType>, ITypeRepository
    {
        public TypeRepository(CodecoolApiContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EducationalMaterialType>> GetAllWithNestedDataAsync()
         => await _context.Types
                .Include(type => type.Materials)
                .ToListAsync();

        public async Task<EducationalMaterialType> GetWithNestedDataAsync(int id)
        => await _context.Types
                .Include(type => type.Materials)
                .FirstOrDefaultAsync(x => x.Id == id);
    }
}
