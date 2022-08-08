using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Dtos.EducationalMaterialReview
{
    public class ReviewDtoWithoutMaterial
    {
        public int Id { get; set; }
        public string TextReview { get; set; }
        public int DigitReview { get; set; }
    }
}
