using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant.DTO.Requests
{
    public class AddAgentRequest
    {
        [Required(ErrorMessage = "You must enter an agent name!")]
        [StringLength(50, ErrorMessage ="You have max.  50 characters")]
        [MinLength(3, ErrorMessage ="You must enter min. 3 characters ")]
        public string CodeName { get; set; }
        public string? RealName { get; set; }
        public string Origin { get; set; }
        public string Role { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
    }
}
