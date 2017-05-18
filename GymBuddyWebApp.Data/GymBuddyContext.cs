using GymBuddyWebApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace GymBuddyWebApp.Data
{
    public class GymBuddyContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Cardio> Cardio { get; set; }
        public DbSet<Weights> Weights { get; set; }
        public DbSet<PersonCardioCompetiotion> Competitions { get; set; }
        public DbSet<CardioContest> CardioContests { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = GymBuddy; Trusted_Connection = True; ");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<PersonCardioCompetiotion>().HasKey(competition => new { competition.CardioContestId, competition.PersonId});
        //}
    }
}

