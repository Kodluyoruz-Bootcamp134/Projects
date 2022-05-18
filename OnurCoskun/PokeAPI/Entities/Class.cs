namespace Entities
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PokemonClass> PokemonClasses { get; set; }
    }
}
