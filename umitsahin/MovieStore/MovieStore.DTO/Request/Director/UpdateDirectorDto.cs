using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DTO.Request.Director
{
    public class UpdateDirectorDto
    {
        public int Id { get; set; }
        public string DirectorName { get; set; }
    }
}
