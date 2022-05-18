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

            //modelBuilder.Entity<PokemonOwner>().HasData(
            //    new PokemonOwner()
            //    {
            //        Pokemon = new Pokemon()
            //        {
            //            Id= 1,
            //            Name = "Pikachu",
            //            Birthday = new DateTime(1903, 1, 1),
            //            PokemonClasses = new List<PokemonClass>()
            //            {
            //                new PokemonClass { Class = new Class() { Name = "Electric"}}
            //            },
            //            Reviews = new List<Review>()
            //            {
            //                new Review { Title="Pikachu",About = "Pikachu that can generate powerful electricity have cheek sacs that are extra soft and super stretchy.", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Teddy", Surname = "Smith" } },
            //                new Review { Title="Pikachu", About = "Pickachu is the best a killing water types", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Taylor", Surname = "Jones" } },
            //                new Review { Title="Pikachu",About = "Pika, pickachu, pikachu", Rating = 1,
            //                Reviewer = new Reviewer(){ Name = "Jessica", Surname = "McGregor" } },
            //            }
            //        },
            //        Owner = new Owner()
            //        {
            //            Name = "Ash",
            //            Gym = "Free",
            //            Gender = "Male",
            //            Country = new Country()
            //            {
            //                Name = "Kanto"
            //            }
            //        }
            //    },
            //     new PokemonOwner()
            //     {
            //         Pokemon = new Pokemon()
            //         {
            //             Id=2,
            //             Name = "Squirtle",
            //             Birthday = new DateTime(1903, 1, 1),
            //             PokemonClasses = new List<PokemonClass>()
            //            {
            //                new PokemonClass { Class = new Class() { Name = "Water"}}
            //            },
            //             Reviews = new List<Review>()
            //            {
            //                new Review { Title= "Squirtle", About = "When it retracts its long neck into its shell, it squirts out water with vigorous force.", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Teddy", Surname = "Smith" } },
            //                new Review { Title= "Squirtle",About = "Squirtle is the best a killing rocks", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Taylor", Surname = "Jones" } },
            //                new Review { Title= "Squirtle", About = "squirtle, squirtle, squirtle", Rating = 1,
            //                Reviewer = new Reviewer(){ Name = "Jessica", Surname = "McGregor" } },
            //            }
            //         },
            //         Owner = new Owner()
            //         {
            //             Name = "Onur",
            //             Gym = "Brock's Gym",
            //             Gender = "Male",
            //             Country = new Country()
            //             {
            //                 Name = "Kanto"
            //             }
            //         }
            //     },
            //     new PokemonOwner()
            //     {
            //         Pokemon = new Pokemon()
            //         {
            //             Id = 3,
            //             Name = "Psyduck",
            //             Birthday = new DateTime(1903, 1, 1),
            //             PokemonClasses = new List<PokemonClass>()
            //            {
            //                new PokemonClass { Class = new Class() { Name = "Water"}}
            //            },
            //             Reviews = new List<Review>()
            //            {
            //                new Review { Title="Psyduck",About = "Psyduck is constantly beset by headaches. If the Pokémon lets its strange power erupt, apparently the pain subsides for a while.", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Teddy", Surname = "Smith" } },
            //                new Review { Title="Psyduck",About = "Psyduck is the best choose if you want to lose it", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Taylor", Surname = "Jones" } },
            //                new Review { Title="Psydcuk",About = "Psy, ay, ayyy..", Rating = 1,
            //                Reviewer = new Reviewer(){ Name = "Jessica", Surname = "McGregor" } },
            //            }
            //         },
            //         Owner = new Owner()
            //         {
            //             Name = "Misty",
            //             Gender = "Female",
            //             Gym = "Cerulean City Gym",
            //             Country = new Country()
            //             {
            //                 Name = "Kanto"
            //             }
            //         }
            //     },
            //     new PokemonOwner()
            //     {
            //         Pokemon = new Pokemon()
            //         {
            //             Id=4,
            //             Name = "Bulbasaur",
            //             Birthday = new DateTime(1903, 1, 1),
            //             PokemonClasses = new List<PokemonClass>()
            //            {
            //                new PokemonClass { Class = new Class() { Name = "Leaf"}}
            //            },
            //             Reviews = new List<Review>()
            //            {
            //                new Review { Title="Bulbasaur",About = "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger.", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Teddy", Surname = "Smith" } },
            //                new Review { Title="Bulbasaur",About = "Bulbasaur is the worst choose for fire type", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Taylor", Surname = "Jones" } },
            //                new Review { Title="Bulbasaur",About = "Bulbasaur, Bulba, Bulba", Rating = 1,
            //                Reviewer = new Reviewer(){ Name = "Jessica", Surname = "McGregor" } },
            //            }
            //         },
            //         Owner = new Owner()
            //         {
            //             Name = "Gardenia",
            //             Gender = "Female",
            //             Gym = "Gardenia's Gym",
            //             Country = new Country()
            //             {
            //                 Name = "Sinnoh"
            //             }
            //         }
            //     },
            //     new PokemonOwner()
            //     {
            //         Pokemon = new Pokemon()
            //         {
            //             Id=5,
            //             Name = "Ninetales",
            //             Birthday = new DateTime(1903, 1, 1),
            //             PokemonClasses = new List<PokemonClass>()
            //            {
            //                new PokemonClass { Class = new Class() { Name = "Fire"}}
            //            },
            //             Reviews = new List<Review>()
            //            {
            //                new Review { Title="Ninetales",About = "It is said to live 1,000 years, and each of its tails is loaded with supernatural powers.", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Teddy", Surname = "Smith" } },
            //                new Review { Title="Ninetales",About = "Ninetales is the best choose for the leaf types ", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Taylor", Surname = "Jones" } },
            //                new Review { Title="Ninetales",About = "Ninetales burns!", Rating = 1,
            //                Reviewer = new Reviewer(){ Name = "Jessica", Surname = "McGregor" } },
            //            }
            //         },
            //         Owner = new Owner()
            //         {
            //             Name = "Blaine",
            //             Gender = "Male",
            //             Gym = "Cinnabar Island",
            //             Country = new Country()
            //             {
            //                 Name = "Kanto"
            //             }
            //         }
            //     },
            //     new PokemonOwner()
            //     {
            //         Pokemon = new Pokemon()
            //         {
            //             Id=6,
            //             Name = "Charmender",
            //             Birthday = new DateTime(1903, 1, 1),
            //             PokemonClasses = new List<PokemonClass>()
            //            {
            //                new PokemonClass { Class = new Class() { Name = "Fire"}}
            //            },
            //             Reviews = new List<Review>()
            //            {
            //                new Review { Title="Charmender",About = "It has a preference for hot things. When it rains, steam is said to spout from the tip of its tail.", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Teddy", Surname = "Smith" } },
            //                new Review { Title="Charmender",About = "Charmender is the best choose for the leaf types ", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Taylor", Surname = "Jones" } },
            //                new Review { Title="Charmender",About = "Charmender burns!", Rating = 1,
            //                Reviewer = new Reviewer(){ Name = "Jessica", Surname = "McGregor" } },
            //            }
            //         },
            //         Owner = new Owner()
            //         {
            //             Name = "Ümit",
            //             Gender = "Male",
            //             Gym = "Brock's Gym",
            //             Country = new Country()
            //             {
            //                 Name = "Trabzon"
            //             }
            //         }
            //     },
            //     new PokemonOwner()
            //     {
            //         Pokemon = new Pokemon()
            //         {
            //             Id=7,
            //             Name = "Geodude",
            //             Birthday = new DateTime(1903, 1, 1),
            //             PokemonClasses = new List<PokemonClass>()
            //            {
            //                new PokemonClass { Class = new Class() { Name = "Rock"}}
            //            },
            //             Reviews = new List<Review>()
            //            {
            //                new Review { Title="Geodude",About = "Commonly found near mountain trails and the like. If you step on one by accident, it gets angry.", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Teddy", Surname = "Smith" } },
            //                new Review { Title="Geodude",About = "Geodude is the worst choose for the water types ", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Taylor", Surname = "Jones" } },
            //                new Review { Title="Geodude",About = "Geodude is strong!", Rating = 1,
            //                Reviewer = new Reviewer(){ Name = "Jessica", Surname = "McGregor" } },
            //            }
            //         },
            //         Owner = new Owner()
            //         {
            //             Name = "Gökcan",
            //             Gender = "Male",
            //             Gym = "Brock's Gym",
            //             Country = new Country()
            //             {
            //                 Name = "Ankara"
            //             }
            //         }
            //     },
            //     new PokemonOwner()
            //     {
            //         Pokemon = new Pokemon()
            //         {
            //             Id=8,
            //             Name = "Pidgeotto",
            //             Birthday = new DateTime(1903, 1, 1),
            //             PokemonClasses = new List<PokemonClass>()
            //            {
            //                new PokemonClass { Class = new Class() { Name = "Flying"}}
            //            },
            //             Reviews = new List<Review>()
            //            {
            //                new Review { Title="Pidgeotto",About = "This Pokémon is full of vitality. It constantly flies around its large territory in search of prey.", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Teddy", Surname = "Smith" } },
            //                new Review { Title="Pidgeotto",About = "Pidgeotto is the worst choose for the electric types ", Rating = 5,
            //                Reviewer = new Reviewer(){ Name = "Taylor", Surname = "Jones" } },
            //                new Review { Title="Pidgeotto",About = "Pidgeotto fly!", Rating = 1,
            //                Reviewer = new Reviewer(){ Name = "Jessica", Surname = "McGregor" } },
            //            }
            //         },
            //         Owner = new Owner()
            //         {
            //             Name = "Halit",
            //             Gender = "Male",
            //             Gym = "Brock's Gym",
            //             Country = new Country()
            //             {
            //                 Name = "Bursa"
            //             }
            //         }
            //     });

        }
    }
}
