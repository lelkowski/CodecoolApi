using CodecoolApi.Data.Models;

namespace CodecoolApi.Data.DAL.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllWithNestedDataAsync();

        Task<Author> GetWithNestedDataAsync(int id);
    }
}