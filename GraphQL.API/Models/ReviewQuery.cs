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
                resolve: context => new Review { Id = 1, Body = "Best place ever!", Rating = 5, User = "rmewborne@me.com" }
                );
        }
    }
}
