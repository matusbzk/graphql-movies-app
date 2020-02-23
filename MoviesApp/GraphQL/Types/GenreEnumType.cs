using GraphQL.Types;
using MoviesApp.Models;

namespace MoviesApp.GraphQL.Types
{
    public class GenreEnumType : EnumerationGraphType<Genre>
    {
        public GenreEnumType()
        {
            Name = "Genre";
            Description = "Genre of movie";
        }
    }
}
