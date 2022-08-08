using AutoMapper;
using CodecoolApi.Data.Models;
using CodecoolApi.Services.Dtos.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
