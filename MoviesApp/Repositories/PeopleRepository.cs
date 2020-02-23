using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;

namespace MoviesApp.Repositories
{
    public class PeopleRepository
    {
        private readonly MoviesAppContext _dbContext;

        public PeopleRepository(MoviesAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<Person> GetAll() => _dbContext.People;

        public async Task<Person> GetById(Guid id) => await _dbContext.People.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IDictionary<Guid, Person>> GetByIds(IEnumerable<Guid> ids)
        {
            var people = _dbContext.People.Where(p => ids.Contains(p.Id)).ToList();
            return people.ToDictionary(p => p.Id);
        }

        public IEnumerable<Person> GetActorsForMovie(Guid movieId) =>
            _dbContext.Actings.Where(a => a.MovieId == movieId).Select(a => a.Person);

        public async Task<ILookup<Guid, Person>> GetActorsForMovies(IEnumerable<Guid> movieIds)
        {
            var people = _dbContext.Actings.Where(a => movieIds.Contains(a.MovieId))
                .Select(a => new {MovieId = a.MovieId, Actor = a.Person}).ToList();
            return people.ToLookup(p => p.MovieId, p => p.Actor);
        }

        public async Task<Person> AddPerson(Person person)
        {
            await _dbContext.People.AddAsync(person);
            await _dbContext.SaveChangesAsync();
            return person;
        }
    }
}
