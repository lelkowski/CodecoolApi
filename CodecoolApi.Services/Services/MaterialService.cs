using AutoMapper;
using CodecoolApi.Data.DAL.Interfaces;
using CodecoolApi.Data.Models;
using CodecoolApi.Services.Dtos.Author;
using CodecoolApi.Services.Dtos.EducationalMaterial;
using CodecoolApi.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaterialService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MaterialDto> CreateNewAsync(CreateUpdateMaterialDto dto)
        {
            var newMaterial = _mapper.Map<EducationalMaterial>(dto);
            newMaterial.DateOfCreation = DateTime.Now;
            _unitOfWork.Materials.Add(newMaterial);
            await _unitOfWork.CompleteUnitAsync();
            return _mapper.Map<MaterialDto>(newMaterial);
        }

        public async Task DeleteAsync(int id)
        {
            var materialToDelete = await _unitOfWork.Materials.GetAsync(id);
            if (materialToDelete is null)
                throw new Exception($"Material with id {id} not found");

            _unitOfWork.Materials.Delete(materialToDelete);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task<IEnumerable<MaterialDto>> GetAllAsync()
        {
            var materials = await _unitOfWork.Materials.GetAllWithNestedDataAsync();
            return _mapper.Map<IEnumerable<MaterialDto>>(materials);
        }

        public async Task<MaterialDto> GetAsync(int id)
        {
            var material = await _unitOfWork.Materials.GetWithNestedDataAsync(id);
            if (material is null)
                throw new Exception($"Material with id {id} not found");
            return _mapper.Map<MaterialDto>(material);
        }
    }
}
