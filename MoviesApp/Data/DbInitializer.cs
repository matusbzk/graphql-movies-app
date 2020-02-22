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
                    FirstName = "Steven",
                    LastName = "Spielberg",
                    Birthdate = new DateTime(1946, 12, 18),
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
                new Person
                {
                    FirstName = "Brad",
                    LastName = "Pitt",
                    Birthdate = new DateTime(1963, 12, 18),
                    IsAlive = true
                },
                new Person
                {
                    FirstName = "Matt",
                    LastName = "Damon",
                    Birthdate = new DateTime(1970, 10, 8),
                    IsAlive = true
                },
                new Person
                {
                    FirstName = "Sean",
                    LastName = "Bean",
                    Birthdate = new DateTime(1959, 4, 17),
                    IsAlive = true
                },
                new Person
                {
                    FirstName = "Donald",
                    LastName = "Glover",
                    Birthdate = new DateTime(1983, 9, 25),
                    IsAlive = true
                },
                new Person
                {
                    FirstName = "Orlando",
                    LastName = "Bloom",
                    Birthdate = new DateTime(1977, 1, 13),
                    IsAlive = true
                },
                new Person
                {
                    FirstName = "Ian",
                    LastName = "McKellen",
                    Birthdate = new DateTime(1939, 5, 25),
                    IsAlive = true
                },
                new Person
                {
                    FirstName = "Elijah",
                    LastName = "Wood",
                    Birthdate = new DateTime(1981, 1, 28),
                    IsAlive = true
                },
                new Person
                {
                    FirstName = "Tommy",
                    LastName = "Wiseau",
                    Birthdate = new DateTime(1955, 10, 3),
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
                    BoxOffice = 678200000,
                    Genre = Genre.Comedy
                },
                new Movie
                {
                    Name = "Pulp Fiction",
                    Rating = 8.9,
                    ReleaseDate = new DateTime(1994,10,14),
                    DirectorId = context.People.First(p => p.LastName == "Tarantino").Id,
                    Budget = 8000000,
                    BoxOffice = 213900000,
                    Genre = Genre.Drama
                },
                new Movie
                {
                    Name = "Inglorious Basterds",
                    Rating = 8.3,
                    ReleaseDate = new DateTime(2009,8,21),
                    DirectorId = context.People.First(p => p.LastName == "Tarantino").Id,
                    Budget = 70000000,
                    BoxOffice = 321500000,
                    Genre = Genre.Drama
                },
                new Movie
                {
                    Name = "Jurassic Park",
                    Rating = 8.1,
                    ReleaseDate = new DateTime(1993,6,11),
                    DirectorId = context.People.First(p => p.LastName == "Spielberg").Id,
                    Budget = 63000000,
                    BoxOffice = 1030000000
                },
                new Movie
                {
                    Name = "Saving Private Ryan",
                    Rating = 8.6,
                    ReleaseDate = new DateTime(1998,7,24),
                    DirectorId = context.People.First(p => p.LastName == "Spielberg").Id,
                    Budget = 70000000,
                    BoxOffice = 482300000,
                    Genre = Genre.Drama
                },
                new Movie
                {
                    Name = "The Green Mile",
                    Rating = 8.6,
                    ReleaseDate = new DateTime(1999,12,10),
                    Budget = 60000000,
                    BoxOffice = 290700000,
                    Genre = Genre.Drama
                },
                new Movie
                {
                    Name = "The Martian",
                    Rating = 8.0,
                    ReleaseDate = new DateTime(2015,9,30),
                    Budget = 108000000,
                    BoxOffice = 630200000,
                    Genre = Genre.SciFi
                },
                new Movie
                {
                    Name = "The Lord of the Rings: The Fellowship of the Ring",
                    Rating = 8.8,
                    ReleaseDate = new DateTime(2001,12,19),
                    Budget = 93000000,
                    BoxOffice = 887800000,
                    Genre = Genre.Fantasy
                },
                new Movie
                {
                    Name = "The Lord of the Rings: The Two Towers",
                    Rating = 8.7,
                    ReleaseDate = new DateTime(2002,12,18),
                    Budget = 94000000,
                    BoxOffice = 951200000,
                    Genre = Genre.Fantasy
                },
                new Movie
                {
                    Name = "The Lord of the Rings: The Return of the King",
                    Rating = 8.9,
                    ReleaseDate = new DateTime(2003,12,17),
                    Budget = 94000000,
                    BoxOffice = 1142000000,
                    Genre = Genre.Fantasy
                },
                new Movie
                {
                    Name = "Sharknado",
                    Rating = 3.3,
                    ReleaseDate = new DateTime(2013,7,11),
                    Budget = 2000000,
                    Genre = Genre.Action
                },
                new Movie
                {
                    Name = "Sharknado 2: The Second One",
                    Rating = 4.0,
                    ReleaseDate = new DateTime(2014,7,30),
                    Budget = 1500000,
                    Genre = Genre.Action
                },
                new Movie
                {
                    Name = "Sharknado 3: Oh Hell No!",
                    Rating = 4.1,
                    ReleaseDate = new DateTime(2015,7,22),
                    Budget = 2400000,
                    Genre = Genre.Action
                },
                new Movie
                {
                    Name = "Sharknado: The 4th Awakens",
                    Rating = 3.9,
                    ReleaseDate = new DateTime(2016,7,31),
                    Budget = 3000000,
                    Genre = Genre.Action
                },
                new Movie
                {
                    Name = "Sharknado 5: Global Swarming",
                    Rating = 3.9,
                    ReleaseDate = new DateTime(2017,8,6),
                    Budget = 5000000,
                    Genre = Genre.Action
                },
                new Movie
                {
                    Name = "The Last Sharknado: It's About Time",
                    Rating = 3.5,
                    ReleaseDate = new DateTime(2018,8,19),
                    Budget = 3000000,
                    Genre = Genre.Action
                },
                new Movie
                {
                    Name = "The Room",
                    Rating = 3.7,
                    ReleaseDate = new DateTime(2003,6,27),
                    DirectorId = context.People.First(p => p.LastName == "Wiseau").Id,
                    Budget = 6000000,
                    BoxOffice = 1800,
                    Genre = Genre.Drama
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
                    MovieId = context.Movies.First(m => m.Name == "The Green Mile").Id,
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
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "Inglorious Basterds").Id,
                    PersonId = context.People.First(p => p.LastName == "Pitt").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "Saving Private Ryan").Id,
                    PersonId = context.People.First(p => p.LastName == "Damon").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "Saving Private Ryan").Id,
                    PersonId = context.People.First(p => p.LastName == "Hanks").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Martian").Id,
                    PersonId = context.People.First(p => p.LastName == "Damon").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Martian").Id,
                    PersonId = context.People.First(p => p.LastName == "Bean").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Martian").Id,
                    PersonId = context.People.First(p => p.LastName == "Glover").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Lord of the Rings: The Fellowship of the Ring").Id,
                    PersonId = context.People.First(p => p.LastName == "Bean").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Lord of the Rings: The Fellowship of the Ring").Id,
                    PersonId = context.People.First(p => p.LastName == "Wood").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Lord of the Rings: The Fellowship of the Ring").Id,
                    PersonId = context.People.First(p => p.LastName == "Bloom").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Lord of the Rings: The Fellowship of the Ring").Id,
                    PersonId = context.People.First(p => p.LastName == "McKellen").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Lord of the Rings: The Two Towers").Id,
                    PersonId = context.People.First(p => p.LastName == "Bean").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Lord of the Rings: The Two Towers").Id,
                    PersonId = context.People.First(p => p.LastName == "Wood").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Lord of the Rings: The Two Towers").Id,
                    PersonId = context.People.First(p => p.LastName == "Bloom").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Lord of the Rings: The Two Towers").Id,
                    PersonId = context.People.First(p => p.LastName == "McKellen").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Lord of the Rings: The Return of the King").Id,
                    PersonId = context.People.First(p => p.LastName == "Bean").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Lord of the Rings: The Return of the King").Id,
                    PersonId = context.People.First(p => p.LastName == "Wood").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Lord of the Rings: The Return of the King").Id,
                    PersonId = context.People.First(p => p.LastName == "Bloom").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Lord of the Rings: The Return of the King").Id,
                    PersonId = context.People.First(p => p.LastName == "McKellen").Id
                },
                new Acting
                {
                    MovieId = context.Movies.First(m => m.Name == "The Room").Id,
                    PersonId = context.People.First(p => p.LastName == "Wiseau").Id
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
