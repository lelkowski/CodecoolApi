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
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(CodecoolApiContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Author>> GetAllWithNestedDataAsync()
         => await _context.Authors
                .Include(author => author.Materials)
                .ToListAsync();

        public async Task<Author> GetWithNestedDataAsync(int id)
        => await _context.Authors
                .Include(author => author.Materials)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Author> GetMostProductiveAuthorAsync()
            => await _context.Authors.Include(author => author.Materials).
            OrderByDescending(x => x.Counter).FirstOrDefaultAsync();
    }
}
