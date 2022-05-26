using Microsoft.EntityFrameworkCore;
using MovieStore.DataAccess.Context;
using MovieStore.DataAccess.Repositories.Abstract;
using MovieStore.DTO.Response.Movie;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DataAccess.Repositories.Concrete
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdDto> GetMovieDetailById(int id)
        {
            return  await _context.Movies.Include(x => x.Genre).Where(x => x.Id == id).Select(x =>
                  new GetMovieByIdDto
                  {
                      MovieName = x.MovieName,
                      GenreName = x.Genre.GenreName,
                      ReleaseDate = x.ReleaseDate,
                  }

                  ).SingleOrDefaultAsync();
        
        }

        public async Task<List<Movie>> GetMoviesByNameAsync(string key)
        {
            return await _context.Movies.Where(x => x.MovieName.Contains(key)).ToListAsync();

        }
    }
}
