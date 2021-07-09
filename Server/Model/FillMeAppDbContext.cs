using FillMeApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FillMeApp.Server.Model
{
    public class FillMeAppDbContext : DbContext
    {
        public virtual DbSet<Party> Parties { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public FillMeAppDbContext()
        {
        }

        public FillMeAppDbContext(DbContextOptions<FillMeAppDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=FillMeApp;user=fillme;password=fillme");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var Parties = new List<Party>();
            Parties.Add(new Party
            {
                Id = "party1",
                Name = "Party number one",
                Description = "Party for development"
            });
            Parties.Add(new Party
            {
                Id = "party2",
                Name = "Party number two",
                Description = "Party for development"
            });
            var Users = new List<User>();
            Users.Add(new User
            {
                Login = "user1",
                Nick = "Zuczek",
                PartyId = "party1"
            });
            Users.Add(new User
            {
                Login = "user2",
                Nick = "Kornel",
                PartyId = "party1"
            });
            Users.Add(new User
            {
                Login = "user3",
                Nick = "Szymek",
                PartyId = "party2"
            });
            var Surveys = new List<Survey>();
            Surveys.Add(new Survey
            {
                Id = 1,
                Name = "First survey",
                Description = "For development",
                PartyId = "party1"
            });
            Surveys.Add(new Survey
            {
                Id = 2,
                Name = "Second survey",
                PartyId = "party1"
            });
            Surveys.Add(new Survey
            {
                Id = 3,
                Name = "Third survey",
                PartyId = "party2"
            });
            modelBuilder.Entity<Party>().HasData(Parties);
            modelBuilder.Entity<User>().HasData(Users);
            modelBuilder.Entity<Survey>().HasData(Surveys);
        }
    }
}
