namespace CodecoolApi.Data.Models
{
    public class EducationalMaterialReview
    {
        public int Id { get; set; }
        public int EducationalMaterialId { get; set; }
        public EducationalMaterial EducationalMaterial { get; set; }
        public string TextReview { get; set; }
        public int DigitReview { get; set; }
    }
}
