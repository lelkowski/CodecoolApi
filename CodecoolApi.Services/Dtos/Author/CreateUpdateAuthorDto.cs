namespace CodecoolApi.Services.Dtos.Author
{
    public class CreateUpdateAuthorDto
    {
        [Required]
        [MinLength(3), MaxLength(40)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
