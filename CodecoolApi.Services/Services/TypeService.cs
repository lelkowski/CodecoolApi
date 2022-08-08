using AutoMapper;
using CodecoolApi.Data.DAL.Interfaces;
using CodecoolApi.Data.Models;
using CodecoolApi.Services.Dtos.Author;
using CodecoolApi.Services.Dtos.EducationalMaterial;
using CodecoolApi.Services.Dtos.EducationalMaterialReview;
using CodecoolApi.Services.Dtos.EducationalMaterialType;
using CodecoolApi.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Services
{
    public class TypeService : ITypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TypeDto> CreateNewAsync(CreateUpdateTypeDto dto)
        {
            var newType = _mapper.Map<EducationalMaterialType>(dto);
            _unitOfWork.Types.Add(newType);
            await _unitOfWork.CompleteUnitAsync();
            return _mapper.Map<TypeDto>(newType);
        }

        public async Task DeleteAsync(int id)
        {
            var typeToDelete = await _unitOfWork.Types.GetAsync(id);
            if (typeToDelete is null)
                throw new Exception($"Type with id {id} not found");

            _unitOfWork.Types.Delete(typeToDelete);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task<IEnumerable<TypeDto>> GetAllAsync()
        {
            var types = await _unitOfWork.Types.GetAllWithNestedDataAsync();
            return _mapper.Map<IEnumerable<TypeDto>>(types);
        }

        public async Task<TypeDto> GetAsync(int id)
        {
            var type = await _unitOfWork.Types.GetWithNestedDataAsync(id);
            if (type is null)
                throw new Exception($"Type with id {id} not found");
            return _mapper.Map<TypeDto>(type);
        }

        public async Task<IEnumerable<MaterialDto>> GetMaterialsFromSpecificTypeAsync(int id)
        {
            var type = await _unitOfWork.Types.GetWithNestedDataAsync(id);
            if (type is null)
                throw new Exception($"Type with id {id} not found");
            return _mapper.Map<IEnumerable<MaterialDto>>(type.Materials);
        }
    }
}
