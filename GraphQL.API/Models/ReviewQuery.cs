using GraphQL.API.GraphTypes;
using GraphQL.Types;
using Grqphql.Core.Models;

namespace GraphQL.API.Models
{
    public class ReviewQuery : ObjectGraphType
    {
        public ReviewQuery()
        {
            Field<ReviewType>(
                "review",
                resolve: context => new Review { Id = 1, Body = "GraphQL is awesome!", Rating = 5, User = "DropAcake@me.com" }
                );
        }
    }
}
