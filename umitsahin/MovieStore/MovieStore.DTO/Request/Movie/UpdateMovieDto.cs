using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DTO.Request.Movie;

public class UpdateMovieDto
{
    public int Id { get; set; }
    public string MovieName { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public int GenreId { get; set; }
    public int DirectorId { get; set; }
}

