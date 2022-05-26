using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.Entities
{
    public class Race:IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}
