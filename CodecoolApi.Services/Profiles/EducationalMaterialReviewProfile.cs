using AutoMapper;
using CodecoolApi.Data.Models;
using CodecoolApi.Services.Dtos.EducationalMaterialReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Profiles
{
    public class EducationalMaterialReviewProfile : Profile
    {
        public EducationalMaterialReviewProfile()
        {
            CreateMap<CreateUpdateReviewDto, EducationalMaterialReview>();
            CreateMap<EducationalMaterialReview, ReviewDto>();
            CreateMap<EducationalMaterialReview, ReviewDtoWithoutMaterial>();
        }
    }
}
