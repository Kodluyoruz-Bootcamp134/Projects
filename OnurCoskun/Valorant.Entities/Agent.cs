using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant.Entities
{
    public class Agent : IEntity
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public string? RealName { get; set; }
        public string Origin { get; set; }
        public string Role { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Skill>? Skills { get; set; }
    }
}
