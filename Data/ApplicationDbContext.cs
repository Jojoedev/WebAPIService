using Microsoft.EntityFrameworkCore;
using WebAPIService.Models;

namespace WebAPIService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new Person()
            {
                Id = 1,
                FirstName = "Jonas",
                LastName = "Odogwu",

                Address = "Lagos, Nigeria",
                CreditCard = ""

            },
            new Person()
            {
                Id = 2,
                FirstName = "Halland",
                LastName = "Torres",

                Address = "Manchester, UK",
                CreditCard = ""
            });
        }
    }
}
