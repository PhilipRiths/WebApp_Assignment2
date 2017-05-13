using GymBuddyWebApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace GymBuddyWebApp.Data
{
    public class GymBuddyContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Cardio> Cardio { get; set; }
        public DbSet<Weights> Weights { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = GymBuddy; Trusted_Connection = True; ");
        }
    }
}

