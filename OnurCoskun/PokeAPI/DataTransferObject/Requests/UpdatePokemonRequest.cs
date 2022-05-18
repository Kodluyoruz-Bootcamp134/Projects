using System.ComponentModel.DataAnnotations;

namespace DataTransferObject.Requests
{
    public class UpdatePokemonRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
