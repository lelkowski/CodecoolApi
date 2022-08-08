using CodecoolApi.Services.Dtos.Author;
using CodecoolApi.Services.Dtos.EducationalMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Services.Interfaces
{
    public interface IMaterialService
    {
        Task<MaterialDto> GetAsync(int id);
        Task<IEnumerable<MaterialDto>> GetAllAsync();
        Task<MaterialDto> CreateNewAsync(CreateUpdateMaterialDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<MaterialDto>> GetAllWithNestedDataWithReviewsAboveAverageAsync();
        Task<IEnumerable<MaterialDto>> GetAllWithNestedDataWithReviewsAboveAverageAsync(int id);
    }
}
