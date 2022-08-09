namespace CodecoolApi.Services.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> GetAsync(int id);
        Task<IEnumerable<ReviewDto>> GetAllAsync();
        Task<ReviewDto> CreateNewAsync(CreateUpdateReviewDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, CreateUpdateReviewDto dto);
        Task Validate(CreateUpdateReviewDto dto);
    }
}
