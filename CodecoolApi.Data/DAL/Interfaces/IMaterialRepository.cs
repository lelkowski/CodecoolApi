using CodecoolApi.Data.Models;

namespace CodecoolApi.Data.DAL.Interfaces
{
    public interface IMaterialRepository : IRepository<EducationalMaterial>
    {
        Task<IEnumerable<EducationalMaterial>> GetAllWithNestedDataAsync();

        Task<EducationalMaterial> GetWithNestedDataAsync(int id);
    }
}