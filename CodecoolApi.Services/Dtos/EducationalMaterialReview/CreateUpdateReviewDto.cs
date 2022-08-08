using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Dtos.EducationalMaterialReview
{
    public class CreateUpdateReviewDto
    {
        [Required]
        public int EducationalMaterialId { get; set; }
        [Required]
        public string TextReview { get; set; }
        [Range(1,10)]
        public int DigitReview { get; set; }
    }
}
