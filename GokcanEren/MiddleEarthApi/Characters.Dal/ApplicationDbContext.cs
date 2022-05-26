using Characters.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.Dal
{
    public class ApplicationDbContext:DbContext
    {

        public DbSet<Character> Characters { get; set; }
        public DbSet<Race> Races { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Character>().Property(x => x.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Character>().HasOne(c => c.Race)
                                            .WithMany(r => r.Characters)
                                            .HasForeignKey(c => c.RaceId)
                                            .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Race>().HasData(
                new Race() { Id=1, Name="Elves"},
                new Race() { Id=2, Name="Men"},
                new Race() { Id=3, Name="Dwarves"},
                new Race() { Id=5, Name="Hobbits"},
                new Race() { Id=6, Name="Orcs"},
                new Race() { Id=7, Name="Ents"},
                new Race() { Id=8, Name="Maiar"},
                new Race() { Id=9, Name="Trolls"},
                new Race() { Id=10, Name= "Barrow-wights"},
                new Race() { Id=11, Name= "Balrogs"},
                new Race() { Id=12, Name= "Dragons"},
                new Race() { Id=13, Name= "Easterlings" },
                new Race() { Id=14, Name= "Ainur" }
                );

            modelBuilder.Entity<Character>().HasData(
                new Character() { Id = 1, Name = "Aragorn", Age = 75, RaceId = 2, isAlive = true, ImageUrl = "https://static.wikia.nocookie.net/ortadunya/images/3/34/Aragorn2.jpg/revision/latest?cb=20210609105006" },
                new Character() { Id = 2, Name = "Gandalf", Age = 150, RaceId = 8, isAlive = true, ImageUrl = "https://static.wikia.nocookie.net/lotr/images/e/e7/Gandalf_the_Grey.jpg/revision/latest?cb=20121110131754" },
                new Character() { Id = 3, Name = "Boromir", Age = 43, RaceId = 2, isAlive = false, ImageUrl = "https://static.wikia.nocookie.net/lotr/images/b/b4/Seanbean_boromir.jpg/revision/latest?cb=20110327195115" },
                new Character() { Id = 4, Name = "Legolas", Age = 66, RaceId = 1, isAlive = true, ImageUrl = "https://static.wikia.nocookie.net/middle-earth-film-saga/images/7/77/Legolas.png/revision/latest/top-crop/width/360/height/450?cb=20160207050831" },
                new Character() { Id = 5, Name = "Witch King", Age = 135, RaceId = 2, isAlive = false, ImageUrl = "https://static.wikia.nocookie.net/lotr/images/5/59/Witch-king.jpg/revision/latest?cb=20220209185252" },
                new Character() { Id = 6, Name = "Gimli", Age = 63, RaceId = 3, isAlive = true, ImageUrl = "https://static.wikia.nocookie.net/ortadunya/images/4/43/Gimli.jpg/revision/latest/top-crop/width/360/height/450?cb=20190424060619" },
                new Character() { Id = 7, Name = "Gil-Galad", Age = 200, RaceId = 1, isAlive = true, ImageUrl = "https://static.wikia.nocookie.net/ortadunya/images/0/06/Gilgalad.jpg/revision/latest/top-crop/width/360/height/450?cb=20190628103851" },
                new Character() { Id = 8, Name = "Saruman", Age = 150, RaceId = 8, isAlive = false, ImageUrl = "https://static.wikia.nocookie.net/lotr/images/0/0c/Christopher_Lee_as_Saruman.jpg/revision/latest/top-crop/width/360/height/360?cb=20170127113833" }
                );
        }

    }
}
