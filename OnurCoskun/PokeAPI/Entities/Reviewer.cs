namespace Entities
{
    public class Reviewer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
