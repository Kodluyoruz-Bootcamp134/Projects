using Entities;

namespace DataTransferObject.Responses
{
    public class PokemonDisplayResponses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public IEnumerable<string> ClassName { get; set; }
    }
}


