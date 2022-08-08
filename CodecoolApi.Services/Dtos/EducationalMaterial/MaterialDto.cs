using CodecoolApi.Services.Dtos.EducationalMaterialReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Dtos.EducationalMaterial
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string EducationalMaterialTypeName { get; set; }
        public List<ReviewDtoWithoutMaterial> Reviews { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
