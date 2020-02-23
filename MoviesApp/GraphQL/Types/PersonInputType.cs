using GraphQL.Types;

namespace MoviesApp.GraphQL.Types
{
    public class PersonInputType : InputObjectGraphType
    {
        public PersonInputType()
        {
            Name = "person";
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<DateGraphType>>("birthdate");
            Field<BooleanGraphType>("isAlive");
        }
    }
}
