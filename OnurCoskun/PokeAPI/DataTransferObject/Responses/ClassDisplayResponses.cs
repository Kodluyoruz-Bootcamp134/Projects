
namespace DataTransferObject.Responses
{
    public class ClassDisplayResponses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> PokemonName { get; set; }
    }
}
