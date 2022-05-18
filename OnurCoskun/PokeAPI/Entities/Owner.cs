namespace Entities
{
    public class Owner : BaseEntity
    {

        public string Name { get; set; }
        public string Gender { get; set; }
        public string Gym { get; set; }
        public Country Country { get; set; }
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
    }
}
