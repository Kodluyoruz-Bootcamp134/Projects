using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.DTO.Responses
{
    public class CharactersRespons
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int RaceId { get; set; }

        public bool isAlive { get; set; } = true;

        public string ImageUrl { get; set; }
    }
}
