using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valorant.Entities;

namespace Valorant.DataAccess.Data
{
    /// <summary>
    /// Entity Framework aracılığı ile veri tabanı bağlantısı işlerini bu bölümde gerçekleştiriyoruz.
    /// </summary>
    public class ValorantDbContext : DbContext
    {
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public ValorantDbContext(DbContextOptions<ValorantDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>().Property(x => x.RealName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Agent>().Property(x=> x.Gender).IsRequired().HasMaxLength(6);
            modelBuilder.Entity<Agent>().Property(x=> x.Role).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Skill>().Property(x=> x.Description).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Skill>().HasOne(a => a.Agent)
                                        .WithMany(s => s.Skills)
                                        .HasForeignKey(a=> a.AgentId)
                                        .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Agent>().HasData(
                new Agent() { Id = 1, CodeName = "Jett", Gender = "Female", Origin = "South Korea", Race = "Radiant", RealName = "Sunwoo Han", Role = "Duelist", ImageUrl = "https://static.wikia.nocookie.net/valorant/images/7/79/Jett_artwork.png/revision/latest/scale-to-width-down/326?cb=20200602020209" },
                new Agent() { Id = 2, CodeName = "Phoenix", Gender = "Male", Origin = "United Kingdom", Race = "Radiant", RealName = "Jamie Adeyemi", Role = "Duelist", ImageUrl = "https://static.wikia.nocookie.net/valorant/images/f/fa/Phoenix_artwork.png/revision/latest/scale-to-width-down/326?cb=20200602020246" },
                new Agent() { Id = 3, CodeName = "Fade", Gender = "Female", Origin = "Turkey", Race = "Radiant", RealName="Unknown", Role = "İnitiator", ImageUrl = "https://static.wikia.nocookie.net/valorant/images/8/8a/Fade_artwork.png/revision/latest/scale-to-width-down/326?cb=20220425005211" }

                );
            modelBuilder.Entity<Skill>().HasData(
                new Skill() { Id = 1, AgentId = 3, Name = "Prowler", Description = "Send forward a prowler that chases the first enemy or trail it sees, nearsighting its target on impact." },
                new Skill() { Id = 2, AgentId = 3, Name = "Seize", Description = "Throw a knot of fear that ruptures on impact with the ground, holding enemies in place and afflicting them with deafness and decay." },
                new Skill() { Id = 3, AgentId = 3, Name = "Haunt", Description = "Throw a watcher that lashes out on impact with the ground, revealing enemies in its line of sight and creating trails to them." },
                new Skill() { Id = 4, AgentId = 3, Name = "Nightfall", Description = "Unleash a wave of nightmare energy, afflicting caught enemies with trails, deafeness, and decay." }
                );

        }

    }
}
