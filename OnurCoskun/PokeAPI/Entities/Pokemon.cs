namespace Entities
{
    public class Pokemon : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
        public ICollection<PokemonClass> PokemonClasses { get; set; }
    }
}
