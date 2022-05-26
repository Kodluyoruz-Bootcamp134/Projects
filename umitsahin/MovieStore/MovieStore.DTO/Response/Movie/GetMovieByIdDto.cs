using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DTO.Response.Movie;

public class GetMovieByIdDto
{
    public string MovieName { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string GenreName { get; set; }
}
