using AutoMapper;
using CodecoolApi.Data.Models;
using CodecoolApi.Services.Dtos.EducationalMaterialType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
