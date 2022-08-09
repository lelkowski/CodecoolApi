namespace CodecoolApi.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<EducationalMaterial> Materials { get; set;}
        public int Counter { get; set; }
        public Author()
        {
            Materials = new List<EducationalMaterial>();
        }
    }
}
