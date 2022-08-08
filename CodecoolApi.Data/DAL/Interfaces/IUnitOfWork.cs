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
        IRepository<Author> Authors { get; }
        IRepository<EducationalMaterial> Materials { get; }
        IRepository<EducationalMaterialReview> Reviews { get; }
        IRepository<EducationalMaterialType> Types { get; }
        Task<int> CompleteUnitAsync();
    }
}
