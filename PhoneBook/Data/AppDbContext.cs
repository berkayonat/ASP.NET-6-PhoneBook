using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using PhoneBook.Models.ViewModels;

namespace PhoneBook.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

    }
}
