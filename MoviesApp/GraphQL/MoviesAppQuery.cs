using System;
using GraphQL.Types;
using MoviesApp.GraphQL.Types;
using MoviesApp.Repositories;

namespace MoviesApp.GraphQL
{
    public class MoviesAppQuery : ObjectGraphType
    {
        public MoviesAppQuery(MoviesRepository moviesRepository, PeopleRepository peopleRepository)
        {
            Field<ListGraphType<MovieType>>("movies", resolve: context => moviesRepository.GetAll());
            Field<ListGraphType<PersonType>>("people", resolve: context => peopleRepository.GetAll());

            Field<MovieType>("movie",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "id"}),
                resolve: context => moviesRepository.GetById(context.GetArgument<Guid>("id")));
        }
    }
}
