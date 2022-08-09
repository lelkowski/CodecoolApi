namespace CodecoolApi.Services.Services.Interfaces
{
    public interface IMaterialService
    {
        Task UpdateAsync(int id, CreateUpdateMaterialDto dto);
        Task<MaterialDto> GetAsync(int id);
        Task<IEnumerable<MaterialDto>> GetAllAsync();
        Task<MaterialDto> CreateNewAsync(CreateUpdateMaterialDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<MaterialDto>> GetAllWithNestedDataWithReviewsAboveAverageAsync();
        Task<IEnumerable<MaterialDto>> GetAllWithNestedDataWithReviewsAboveAverageAsync(int id);
        Task Validate(CreateUpdateMaterialDto dto);
    }
}
