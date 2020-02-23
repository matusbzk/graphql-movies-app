using GraphQL;
using GraphQL.Types;

namespace MoviesApp.GraphQL
{
    public class MoviesAppSchema : Schema
    {
        public MoviesAppSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MoviesAppQuery>();
            Mutation = resolver.Resolve<MoviesAppMutation>();
        }
    }
}
