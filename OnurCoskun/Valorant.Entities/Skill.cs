using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant.Entities
{
    public class Skill : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Agent Agent { get; set; }
        public int AgentId { get; set; }

    }
}
