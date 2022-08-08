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
    public class ReviewRepository : Repository<EducationalMaterialReview>, IReviewRepository
    {
        public ReviewRepository(CodecoolApiContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EducationalMaterialReview>> GetAllWithNestedDataAsync()
         => await _context.Reviews
                .Include(review => review.EducationalMaterial)
                .ToListAsync();

        public async Task<EducationalMaterialReview> GetWithNestedDataAsync(int id)
        => await _context.Reviews
                .Include(review => review.EducationalMaterial)
                .FirstOrDefaultAsync(x => x.Id == id);
    }
}
