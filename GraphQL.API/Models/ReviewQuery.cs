using GraphQL.API.GraphTypes;
using GraphQL.Types;
using Grqphql.Core.data;
using Grqphql.Core.Models;

namespace GraphQL.API.Models
{
    public class ReviewQuery : ObjectGraphType
    {
        private IReviewsRepository ReviewsRepository { get; set; }
        public ReviewQuery(IReviewsRepository reviewsRepository)
        {
            Field<ReviewType>(
                "review",
                resolve: context => reviewsRepository.Get(1)
                );
        }
    }
}
