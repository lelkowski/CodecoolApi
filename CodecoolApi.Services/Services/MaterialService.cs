using AutoMapper;
using CodecoolApi.Data.DAL.Interfaces;
using CodecoolApi.Data.Models;
using CodecoolApi.Services.Dtos.Author;
using CodecoolApi.Services.Dtos.EducationalMaterial;
using CodecoolApi.Services.Exceptions;
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
            await Validate(dto);
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
                throw new ResourceNotFoundException($"Material with id {id} not found");

            _unitOfWork.Materials.Delete(materialToDelete);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task<IEnumerable<MaterialDto>> GetAllAsync()
        {
            var materials = await _unitOfWork.Materials.GetAllWithNestedDataAsync();
            return _mapper.Map<IEnumerable<MaterialDto>>(materials);
        }

        public async Task<IEnumerable<MaterialDto>> GetAllWithNestedDataWithReviewsAboveAverageAsync()
        {
            var materials = await _unitOfWork.Materials.GetAllWithNestedDataAsync();
            var materialsAboveAverage = materials.Where(material => material.Reviews.Average(review => review.DigitReview) > 5);
            return _mapper.Map<IEnumerable<MaterialDto>>(materialsAboveAverage);
        }

        public async Task<IEnumerable<MaterialDto>> GetAllWithNestedDataWithReviewsAboveAverageAsync(int id)
        {
            var materials = await _unitOfWork.Materials.GetAllWithNestedDataAsync();
            if (_unitOfWork.Authors.GetAsync(id) == null)
                throw new ResourceNotFoundException($"Material with id {id} not found");
            var materialsAboveAverage = materials.Where(material => material.Reviews.Average(review => review.DigitReview) > 5 && material.AuthorId == id);
            return _mapper.Map<IEnumerable<MaterialDto>>(materialsAboveAverage);
        }

        public async Task<MaterialDto> GetAsync(int id)
        {
            var material = await _unitOfWork.Materials.GetWithNestedDataAsync(id);
            if (material is null)
                throw new ResourceNotFoundException($"Material with id {id} not found");
            return _mapper.Map<MaterialDto>(material);
        }

        public async Task UpdateAsync(int id, CreateUpdateMaterialDto dto)
        {
            await Validate(dto);
            var material = await _unitOfWork.Materials.GetAsync(id);
            if (material == null)
            {
                throw new ResourceNotFoundException($"Material with id {id} not found");
            }
            _mapper.Map(dto, material);
            _unitOfWork.Materials.Update(material);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task Validate(CreateUpdateMaterialDto dto)
        {
            if(await _unitOfWork.Materials.GetAsync(dto.EducationalMaterialTypeId)==null)
            {
                throw new ResourceNotFoundException($"There is no Educational Material Type with id {dto.EducationalMaterialTypeId}");
            }
            if(await _unitOfWork.Authors.GetAsync(dto.AuthorId)==null)
            {
                throw new ResourceNotFoundException($"There is no Author with id {dto.AuthorId}");
            }
        }
    }
}
