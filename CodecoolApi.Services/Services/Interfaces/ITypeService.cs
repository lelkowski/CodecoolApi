namespace CodecoolApi.Services.Services.Interfaces
{
    public interface ITypeService
    {
        Task<TypeDto> GetAsync(int id);
        Task<IEnumerable<TypeDto>> GetAllAsync();
        Task<TypeDto> CreateNewAsync(CreateUpdateTypeDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<MaterialDto>> GetMaterialsFromSpecificTypeAsync(int id);
        Task UpdateAsync(int id, CreateUpdateTypeDto dto);
    }
}
