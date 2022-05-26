using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.DataAccess.Context;
using MovieStore.DataAccess.Repositories.Abstract;
using MovieStore.DataAccess.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DataAccess;

public static class ServiceRegistration
{
    
    public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IDirectorRepository, DirectorRepository>();
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.EnableSensitiveDataLogging(true);
            opt.UseSqlServer(configuration.GetConnectionString("db"),
                 configure =>
                 {
                     configure.MigrationsAssembly("Base.Api.Persistence");
                 });
        });

    }
}
