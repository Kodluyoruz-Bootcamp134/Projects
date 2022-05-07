using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant.DTO.Responses
{
    public class AgentDisplayResponse
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public string Role { get; set; }
        public string ImageUrl { get; set; }
        public string Origin { get; set; }

    }
}
