using System;

namespace MoviesApp.Models
{
    public class Acting
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid MovieId { get; set; }

        public Person Person { get; set; }
        public Movie Movie { get; set; }
    }
}
