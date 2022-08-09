namespace CodecoolApi.Services.Dtos.EducationalMaterial
{
    public class CreateUpdateMaterialDto
    {
        [Required]
        [MinLength(3), MaxLength(60)]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int EducationalMaterialTypeId { get; set; }
    }
}
