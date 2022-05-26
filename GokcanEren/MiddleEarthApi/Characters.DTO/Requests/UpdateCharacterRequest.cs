using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.DTO.Requests
{
    public class UpdateCharacterRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Character name is required!")]
        public string Name { get; set; }

        public int Age { get; set; }

        public int RaceId { get; set; }

        public bool isAlive { get; set; } = true;

        public string ImageUrl { get; set; }
    }
}
