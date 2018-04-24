using GraphQL.Types;
using Grqphql.Core.Models;

namespace GraphQL.API.GraphTypes
{
    public class ReviewType : ObjectGraphType<Review>
    {
        public ReviewType()
        {
            Field(f => f.Id).Description("Each Review has an ID");
            Field(f => f.Body, nullable: true).Description("Every Review has a Body or content of a review.");
            Field(f => f.User).Description("Users are the author of reviews.");
            Field(f => f.Rating).Description("The rating of the review");
        }
    }
}
