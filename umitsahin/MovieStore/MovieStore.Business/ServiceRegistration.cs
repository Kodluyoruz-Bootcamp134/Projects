using Microsoft.Extensions.DependencyInjection;
using MovieStore.Business.Abstract;
using MovieStore.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IDirectorService, DirectorService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

        }
    }

}
