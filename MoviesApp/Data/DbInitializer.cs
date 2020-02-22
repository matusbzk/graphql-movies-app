using System;
using System.Linq;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MoviesAppContext context)
        {
            context.Database.EnsureCreated();

            if (context.Movies.Any())
            {
                return;
            }

            var people = new[]
            {
                new Person
                {
                    FirstName = "Tom",
                    LastName = "Hanks",
                    Birthdate = new DateTime(1956, 7, 9),
                    IsAlive = true
                },
                new Person
                {
                    FirstName = "Quentin",
                    LastName = "Tarantino",
                    Birthdate = new DateTime(1963, 3, 27),
                    IsAlive = true
                },
                new Person
                {
                    FirstName = "John",
                    LastName = "Travolta",
                    Birthdate = new DateTime(1954, 2, 18),
                    IsAlive = true
                },
                new Person
                {
                    FirstName = "Samuel L.",
                    LastName = "Jackson",
                    Birthdate = new DateTime(1948, 12, 21),
                    IsAlive = true
                },
                new Person
                {
                    FirstName = "Uma",
                    LastName = "Thurman",
                    Birthdate = new DateTime(1970, 4, 29),
                    IsAlive = true
                },
            };

            foreach (var person in people)
            {
                context.People.Add(person);
            }

            context.SaveChanges();

            var movies = new[]
            {
                new Movie
                {
                    Name = "Forrest Gump",
                    Rating = 8.8,
                    ReleaseDate = new DateTime(1994,7,6),
                    Budget = 55000000,
                    BoxOffice = 678200000
                },
                new Movie
                {
                    Name = "Pulp Fiction",
                    Rating = 8.9,
                    ReleaseDate = new DateTime(1994,10,14),
                    DirectorId = context.People.First(p => p.LastName == "Tarantino").Id,
                    Budget = 8000000,
                    BoxOffice = 213900000
                },
            };

            foreach (var movie in movies)
            {
                context.Movies.Add(movie);
            }

            context.SaveChanges();

            var actings = new[]
            {
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "Forrest Gump").Id,
                    PersonId = context.People.First(p => p.LastName == "Hanks").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "Pulp Fiction").Id,
                    PersonId = context.People.First(p => p.LastName == "Travolta").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "Pulp Fiction").Id,
                    PersonId = context.People.First(p => p.FirstName == "Samuel L.").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "Pulp Fiction").Id,
                    PersonId = context.People.First(p => p.LastName == "Thurman").Id
                },
            };

            foreach (var acting in actings)
            {
                context.Actings.Add(acting);
            }

            context.SaveChanges();
        }
    }
}
