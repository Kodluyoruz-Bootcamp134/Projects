using System.ComponentModel.DataAnnotations;

namespace DataTransferObject.Requests
{
    public class AddPokemonRequest
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "You have max. 15 characters")]
        [MinLength(2, ErrorMessage = "You must enter min. 2 characters")]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        public IEnumerable<string> ClassName { get; set; }
    }
}
