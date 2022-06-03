using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DTO.Request.Genre
{
    public class UpdateGenreDto
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
    }
}
