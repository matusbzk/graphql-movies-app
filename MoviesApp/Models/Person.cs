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
    }
}
