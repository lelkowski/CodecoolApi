using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Data.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> FindAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
