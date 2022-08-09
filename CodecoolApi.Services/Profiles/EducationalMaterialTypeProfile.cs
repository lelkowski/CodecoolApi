namespace CodecoolApi.Services.Profiles
{
    public class EducationalMaterialTypeProfile : Profile
    {
        public EducationalMaterialTypeProfile()
        {
            CreateMap<CreateUpdateTypeDto, EducationalMaterialType>();
            CreateMap<EducationalMaterialType, TypeDto>()
                .ForMember(pts => pts.Materials, opt => opt.MapFrom(ps => ps.Materials.Select(Material => Material.Title))); ;
        }
    }
}
