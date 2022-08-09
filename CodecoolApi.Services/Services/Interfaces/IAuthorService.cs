namespace CodecoolApi.Services.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorDto> GetAsync(int id);
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto> CreateNewAsync(CreateUpdateAuthorDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, CreateUpdateAuthorDto dto);
        Task<AuthorDto> GetMostProductiveAuthorAsync();
    }
}
