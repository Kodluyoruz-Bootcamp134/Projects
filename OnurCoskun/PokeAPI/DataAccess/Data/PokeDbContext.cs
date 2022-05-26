using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class PokeDbContext : DbContext
    {
        public PokeDbContext(DbContextOptions<PokeDbContext> options) : base(options)
        {

        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<PokemonClass> PokemonClasses { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonClass>()
                .HasKey(pC => new { pC.PokemonId, pC.ClassId });
            modelBuilder.Entity<PokemonClass>()
                .HasOne(p => p.Class)
                .WithMany(pC => pC.PokemonClasses)
                .HasForeignKey(c => c.ClassId);
            modelBuilder.Entity<PokemonClass>()
                .HasOne(p => p.Pokemon)
                .WithMany(pC => pC.PokemonClasses)
                .HasForeignKey(p => p.PokemonId);

            modelBuilder.Entity<PokemonOwner>()
                .HasKey(pO => new { pO.PokemonId, pO.OwnerId });
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(pC => pC.PokemonOwners)
                .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Owner)
                .WithMany(pO => pO.PokemonOwners)
                .HasForeignKey(p => p.OwnerId);

        }
    }
}
