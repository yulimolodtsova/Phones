using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Models
{
    public class PhoneContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; } = null!;

        public PhoneContext(DbContextOptions<PhoneContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().HasData(
                    new Phone { Id = 1, Name = "Телефон 1", Price = 10000 },
                    new Phone { Id = 2, Name = "Телефон 2", Price = 2700 },
                    new Phone { Id = 3, Name = "Телефон 3", Price = 3555 },
                    new Phone { Id = 4, Name = "Телефон 4", Price = 15502 },
                    new Phone { Id = 5, Name = "Телефон 5", Price = 29000 },
                    new Phone { Id = 6, Name = "Телефон 6", Price = 31009 },
                    new Phone { Id = 7, Name = "Телефон 7", Price = 19325 },
                    new Phone { Id = 8, Name = "Телефон 8", Price = 21352 },
                    new Phone { Id = 9, Name = "Телефон 9", Price = 7345 }
            );
        }
    }
}