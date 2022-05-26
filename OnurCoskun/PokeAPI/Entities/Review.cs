namespace Entities
{
    public class Review : BaseEntity
    {
        public string Title { get; set; }
        public string About { get; set; }
        public int Rating { get; set; }
        public Reviewer Reviewer { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
