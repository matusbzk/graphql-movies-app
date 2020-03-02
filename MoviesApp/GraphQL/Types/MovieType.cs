using System;
using GraphQL.DataLoader;
using GraphQL.Types;
using MoviesApp.Models;
using MoviesApp.Repositories;

namespace MoviesApp.GraphQL.Types
{
    public class MovieType : ObjectGraphType<Movie>
    {
        public MovieType(PeopleRepository peopleRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.Name);
            Field("releaseDate", t => t.ReleaseDateFormatted);
            Field(t => t.BoxOffice, true);
            Field(t => t.Budget, true);
            Field(t => t.Rating, true).Description("Rating on IMDb");
            Field<GenreEnumType>("Genre", "Genre of movie");

            Field<PersonType>("director",
                resolve: context =>
                {
                    if (!context.Source.DirectorId.HasValue)
                    {
                        return null;
                    }

                    // return peopleRepository.GetById(context.Source.DirectorId.Value);
                    var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<Guid, Person>(
                        "GetActorsById",
                        peopleRepository.GetByIds);
                    return loader.LoadAsync(context.Source.DirectorId.Value);
                });

            Field<ListGraphType<PersonType>>("actors",
                resolve: context =>
                {
                    var loader =
                        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<Guid, Person>(
                            "GetActorsByMovieId",
                            peopleRepository.GetActorsForMovies);
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
