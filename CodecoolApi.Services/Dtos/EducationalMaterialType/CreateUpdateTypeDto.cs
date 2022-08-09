namespace CodecoolApi.Services.Dtos.EducationalMaterialType
{
    public class CreateUpdateTypeDto
    {
        [Required]
        [MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string Definition { get; set; }
    }
}
