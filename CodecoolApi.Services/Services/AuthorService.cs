using AutoMapper;
using CodecoolApi.Data.DAL.Interfaces;
using CodecoolApi.Data.Models;
using CodecoolApi.Services.Dtos.Author;
using CodecoolApi.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthorDto> CreateNewAsync(CreateUpdateAuthorDto dto)
        {
            var newAuthor = _mapper.Map<Author>(dto);
            _unitOfWork.Authors.Add(newAuthor);
            await _unitOfWork.CompleteUnitAsync();
            return _mapper.Map<AuthorDto>(newAuthor);
        }

        public async Task DeleteAsync(int id)
        {
            var authorToDelete = await _unitOfWork.Authors.GetAsync(id);
            if (authorToDelete is null)
                throw new Exception($"Actor with id {id} not found");

            _unitOfWork.Authors.Delete(authorToDelete);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _unitOfWork.Authors.GetAllWithNestedDataAsync();
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetAsync(int id)
        {
            var author = await _unitOfWork.Authors.GetWithNestedDataAsync(id);
            if (author is null)
                throw new Exception($"Author with id {id} not found");
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<AuthorDto> GetMostProductiveAuthorAsync()
        {
            var author = await _unitOfWork.Authors.GetMostProductiveAuthorAsync();
            if (author is null)
                throw new Exception($"Author not found");
            return _mapper.Map<AuthorDto>(author);
        }
    }
}
