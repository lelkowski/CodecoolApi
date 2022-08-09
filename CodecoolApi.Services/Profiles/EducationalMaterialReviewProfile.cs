namespace CodecoolApi.Services.Profiles
{
    public class EducationalMaterialReviewProfile : Profile
    {
        public EducationalMaterialReviewProfile()
        {
            CreateMap<CreateUpdateReviewDto, EducationalMaterialReview>();
            CreateMap<EducationalMaterialReview, ReviewDto>()
                .ForMember(pts => pts.EducationalMaterial, opt => opt.MapFrom(ps => ps.EducationalMaterial.Title));
            CreateMap<EducationalMaterialReview, ReviewDtoWithoutMaterial>();
        }
    }
}
