using AutoMapper;
using CodecoolApi.Data.DAL.Interfaces;
using CodecoolApi.Data.Models;
using CodecoolApi.Services.Dtos.Author;
using CodecoolApi.Services.Dtos.EducationalMaterialReview;
using CodecoolApi.Services.Exceptions;
using CodecoolApi.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReviewDto> CreateNewAsync(CreateUpdateReviewDto dto)
        {
            await Validate(dto);
            var newReview = _mapper.Map<EducationalMaterialReview>(dto);
            _unitOfWork.Reviews.Add(newReview);
            await _unitOfWork.CompleteUnitAsync();
            return _mapper.Map<ReviewDto>(newReview);
        }

        public async Task DeleteAsync(int id)
        {
            var reviewToDelete = await _unitOfWork.Reviews.GetAsync(id);
            if (reviewToDelete is null)
                throw new ResourceNotFoundException($"Review with id {id} not found");

            _unitOfWork.Reviews.Delete(reviewToDelete);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task<IEnumerable<ReviewDto>> GetAllAsync()
        {
            var reviews = await _unitOfWork.Reviews.GetAllWithNestedDataAsync();
            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<ReviewDto> GetAsync(int id)
        {
            var review = await _unitOfWork.Reviews.GetWithNestedDataAsync(id);
            if (review is null)
                throw new ResourceNotFoundException($"Review with id {id} not found");
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task UpdateAsync(int id, CreateUpdateReviewDto dto)
        {
            await Validate(dto);
            var review = await _unitOfWork.Reviews.GetAsync(id);
            if (review == null)
            {
                throw new ResourceNotFoundException($"Review with id {id} not found");
            }
            _mapper.Map(dto, review);
            _unitOfWork.Reviews.Update(review);
            await _unitOfWork.CompleteUnitAsync();
        }
        public async Task Validate(CreateUpdateReviewDto dto)
        {
            if (await _unitOfWork.Reviews.GetAsync(dto.EducationalMaterialId) == null)
            {
                throw new ResourceNotFoundException($"There is no Educational Material with id {dto.EducationalMaterialId}");
            }
        }
    }
}
