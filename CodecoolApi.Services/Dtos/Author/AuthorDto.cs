namespace CodecoolApi.Services.Dtos.Author
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> MaterialNames { get; set; }
        public int Counter { get; set; }
    }
}
