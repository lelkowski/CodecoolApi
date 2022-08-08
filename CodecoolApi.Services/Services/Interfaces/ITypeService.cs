using CodecoolApi.Services.Dtos.Author;
using CodecoolApi.Services.Dtos.EducationalMaterial;
using CodecoolApi.Services.Dtos.EducationalMaterialType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Services.Interfaces
{
    public interface ITypeService
    {
        Task<TypeDto> GetAsync(int id);
        Task<IEnumerable<TypeDto>> GetAllAsync();
        Task<TypeDto> CreateNewAsync(CreateUpdateTypeDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<MaterialDto>> GetMaterialsFromSpecificTypeAsync(int id);
    }
}
