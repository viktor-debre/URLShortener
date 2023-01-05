using Microsoft.EntityFrameworkCore;
using URLShortener.Models;
using URLShortener.Models.Entities;

namespace URLShortener.DAO
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        //Entities
        public DbSet<User> Users { get; set; }

        public DbSet<URL> URLs { get; set; }
    }
}
