using System;
using System.Collections.Generic;

namespace MoviesApp.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double? Rating { get; set; }
        public Guid? DirectorId { get; set; }
        public int? Budget { get; set; }
        public int? BoxOffice { get; set; }
        public Genre? Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public Person Director { get; set; }
        public ICollection<Acting> Actors { get; set; }
        public string ReleaseDateFormatted => ReleaseDate.HasValue ? ReleaseDate.Value.ToString("yyyy MMMM dd") : "";
    }
}
