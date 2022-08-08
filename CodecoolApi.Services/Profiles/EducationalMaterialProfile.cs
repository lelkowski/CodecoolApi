using AutoMapper;
using CodecoolApi.Data.Models;
using CodecoolApi.Services.Dtos.EducationalMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
