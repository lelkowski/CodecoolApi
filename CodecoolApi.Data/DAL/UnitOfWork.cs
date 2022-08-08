using CodecoolApi.Data.Context;
using CodecoolApi.Data.DAL.Interfaces;
using CodecoolApi.Data.DAL.Repositories;
using CodecoolApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Data.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private CodecoolApiContext _context;

        public IAuthorRepository Authors { get; }
        public IRepository<EducationalMaterial> Materials { get; }
        public IRepository<EducationalMaterialReview> Reviews { get; }
        public IRepository<EducationalMaterialType> Types { get; }

        public UnitOfWork(CodecoolApiContext context)
        {
            _context = context;
            Authors = new AuthorRepository(_context);
            Materials = new Repository<EducationalMaterial>(_context);
            Reviews = new Repository<EducationalMaterialReview>(_context);
            Types = new Repository<EducationalMaterialType>(_context);

        }

        public async Task<int> CompleteUnitAsync()
            => await _context.SaveChangesAsync();
    }
}
