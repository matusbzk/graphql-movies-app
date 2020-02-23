using GraphQL.Types;
using MoviesApp.GraphQL.Types;
using MoviesApp.Models;
using MoviesApp.Repositories;

namespace MoviesApp.GraphQL
{
    public class MoviesAppMutation : ObjectGraphType
    {
        public MoviesAppMutation(PeopleRepository peopleRepository)
        {
            FieldAsync<PersonType>(
                "createPerson",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PersonInputType>> {Name = "person"}),
                resolve: async context =>
                {
                    var person = context.GetArgument<Person>("person");
                    return await context.TryAsyncResolve(async c => await peopleRepository.AddPerson(person));
                });
        }
    }
}
