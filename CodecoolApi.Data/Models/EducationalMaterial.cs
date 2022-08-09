namespace CodecoolApi.Data.Models
{
    public class EducationalMaterial
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int EducationalMaterialTypeId { get; set; }
        public EducationalMaterialType EducationalMaterialType { get; set; }
        public ICollection<EducationalMaterialReview> Reviews { get; set; }
        public DateTime DateOfCreation { get; set; }

        public EducationalMaterial()
        {
            Reviews = new List<EducationalMaterialReview>();
        }
    }
}
