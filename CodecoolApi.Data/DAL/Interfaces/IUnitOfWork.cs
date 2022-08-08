using CodecoolApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
