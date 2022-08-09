using CodecoolApi.Data.Context;
using CodecoolApi.Data.DAL.Interfaces;
using CodecoolApi.Data.DAL.Repositories;

namespace CodecoolApi.Data.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private CodecoolApiContext _context;

        public IAuthorRepository Authors { get; }
        public IMaterialRepository Materials { get; }
        public IReviewRepository Reviews { get; }
        public ITypeRepository Types { get; }

        public UnitOfWork(CodecoolApiContext context)
        {
            _context = context;
            Authors = new AuthorRepository(_context);
            Materials = new MaterialRepository(_context);
            Reviews = new ReviewRepository(_context);
            Types = new TypeRepository(_context);

        }

        public async Task<int> CompleteUnitAsync()
            => await _context.SaveChangesAsync();
    }
}
