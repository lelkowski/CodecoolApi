using CodecoolApi.Data.Models;

namespace CodecoolApi.Data.DAL.Interfaces
{
    public interface IReviewRepository : IRepository<EducationalMaterialReview>
    {
        Task<IEnumerable<EducationalMaterialReview>> GetAllWithNestedDataAsync();

        Task<EducationalMaterialReview> GetWithNestedDataAsync(int id);
    }
}