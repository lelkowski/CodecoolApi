using CodecoolApi.Data.Models;

namespace CodecoolApi.Data.DAL.Interfaces
{
    public interface ITypeRepository : IRepository<EducationalMaterialType>
    {
        Task<IEnumerable<EducationalMaterialType>> GetAllWithNestedDataAsync();

        Task<EducationalMaterialType> GetWithNestedDataAsync(int id);
    }
}