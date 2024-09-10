using Microsoft.EntityFrameworkCore;
using Qinshift.Movies.DomainModels;

namespace Qinshift.Movies.DataAccess
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PopulateDb.Seed(modelBuilder); 
        }
    }
}
