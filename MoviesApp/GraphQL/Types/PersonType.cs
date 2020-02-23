using System;
using GraphQL.DataLoader;
using GraphQL.Types;
using MoviesApp.Models;
using MoviesApp.Repositories;

namespace MoviesApp.GraphQL.Types
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType(MoviesRepository moviesRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.Name);
            Field("birthDate", t => t.BirthdateFormatted);
            Field(t => t.IsAlive);

            Field<ListGraphType<MovieType>>("movies",
                resolve: context =>
                {
                    var loader =
                        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<Guid, Movie>(
                            "GetMoviesByActorId",
                            moviesRepository.GetMoviesForActors);
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
