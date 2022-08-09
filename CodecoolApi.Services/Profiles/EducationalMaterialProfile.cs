namespace CodecoolApi.Services.Profiles
{
    public class EducationalMaterialProfile : Profile
    {
        public EducationalMaterialProfile()
        {
            CreateMap<CreateUpdateMaterialDto, EducationalMaterial>();
            CreateMap<EducationalMaterial, MaterialDto>();
        }
    }
}
