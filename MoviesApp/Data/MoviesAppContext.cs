using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public class MoviesAppContext : DbContext
    {
        public MoviesAppContext (DbContextOptions<MoviesAppContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Acting> Actings { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Acting>().ToTable("Acting");
            modelBuilder.Entity<Movie>().ToTable("Movie");
        }
    }
}
