namespace CodecoolApi.Data.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IMaterialRepository Materials { get; }
        IReviewRepository Reviews { get; }
        ITypeRepository Types { get; }
        Task<int> CompleteUnitAsync();
    }
}
