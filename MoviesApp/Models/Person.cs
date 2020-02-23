using System;
using System.Collections.Generic;

namespace MoviesApp.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public bool IsAlive { get; set; }

        public ICollection<Acting> Movies { get; set; }

        public string Name => $"{FirstName} {LastName}";
        public int Age => DateTime.Today.Year - Birthdate.Year;
        public string BirthdateFormatted => Birthdate.ToString("yyyy MMMM dd");
    }
}
