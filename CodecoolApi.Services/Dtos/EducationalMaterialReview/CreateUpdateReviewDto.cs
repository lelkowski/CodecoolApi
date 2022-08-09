namespace CodecoolApi.Services.Dtos.EducationalMaterialReview
{
    public class CreateUpdateReviewDto
    {
        [Required]
        public int EducationalMaterialId { get; set; }
        [Required]
        [MinLength(2)]
        public string TextReview { get; set; }
        [Range(1,10)]
        public int DigitReview { get; set; }
    }
}
