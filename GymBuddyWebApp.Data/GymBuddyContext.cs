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
                "Server=tcp:gymbuddydb.database.windows.net,1433;Initial Catalog=GymBuddyDb;Persist Security Info=False;User ID=prys45@hotmail.com@gymbuddydb;Password=Expressen37;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<PersonCardioCompetiotion>().HasKey(competition => new { competition.CardioContestId, competition.PersonId});
        //}
    }
}

