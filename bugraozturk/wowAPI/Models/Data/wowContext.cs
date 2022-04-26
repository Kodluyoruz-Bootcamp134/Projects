using Microsoft.EntityFrameworkCore;
using wowAPI.Entities;

namespace wowAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
        
        public DbSet <MajorCharacter> MajorCharacters { get; set; }
        public DbSet <Expansion> Expansions { get; set; }
        public DbSet <Race> Races { get; set; }
        public DbSet <Class> Classes { get; set; }
    }
}
