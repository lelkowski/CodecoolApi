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
            CreateMap<EducationalMaterialType, CreateUpdateTypeDto>();
        }
    }
}
