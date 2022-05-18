namespace Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}
