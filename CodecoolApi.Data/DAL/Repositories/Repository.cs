using CodecoolApi.Data.Context;
using CodecoolApi.Data.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Data.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected CodecoolApiContext _context;

        public Repository(CodecoolApiContext context)
            => _context = context;

        public void Add(T entity)
            => _context.Set<T>().Add(entity);

        public void Update(T entity)
            => _context.Set<T>().Update(entity);

        public void Delete(T entity)
            => _context.Set<T>().Remove(entity);

        public async Task<T> GetAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public IQueryable<T> FindAll()
            => _context.Set<T>();
    }
}
