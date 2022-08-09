namespace CodecoolApi.Services.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<CreateUpdateAuthorDto, Author>();
            CreateMap<Author, AuthorDto>().ForMember(pts => pts.MaterialNames, opt => opt.MapFrom(ps => ps.Materials.Select(Material => Material.Title)));
        }
    }
}
