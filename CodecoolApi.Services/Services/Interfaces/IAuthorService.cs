using CodecoolApi.Services.Dtos.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorDto> GetAsync(int id);
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto> CreateNewAsync(CreateUpdateAuthorDto dto);
        Task DeleteAsync(int id);
    }
}
