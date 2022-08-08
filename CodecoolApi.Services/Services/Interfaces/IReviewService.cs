using CodecoolApi.Services.Dtos.Author;
using CodecoolApi.Services.Dtos.EducationalMaterialReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> GetAsync(int id);
        Task<IEnumerable<ReviewDto>> GetAllAsync();
        Task<ReviewDto> CreateNewAsync(CreateUpdateReviewDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, CreateUpdateReviewDto dto);
    }
}
