using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;

namespace MoviesApp.Repositories
{
    public class MoviesRepository
    {
        private readonly MoviesAppContext _dbContext;

        public MoviesRepository(MoviesAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<Movie> GetAll() => _dbContext.Movies;

        public Movie GetById(Guid id) => _dbContext.Movies.FirstOrDefault(m => m.Id == id);

        public IEnumerable<Movie> GetMoviesForActor(Guid actorId) =>
            _dbContext.Actings.Where(a => a.PersonId == actorId).Select(a => a.Movie);

        public async Task<ILookup<Guid, Movie>> GetMoviesForActors(IEnumerable<Guid> actorIds)
        {
            var people = _dbContext.Actings.Where(a => actorIds.Contains(a.PersonId))
                .Select(a => new { a.PersonId, a.Movie }).ToList();
            return people.ToLookup(p => p.PersonId, p => p.Movie);
        }
    }
}
