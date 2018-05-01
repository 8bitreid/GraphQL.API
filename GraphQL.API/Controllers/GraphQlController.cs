using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using GraphQL.API.Models;
using System.Threading.Tasks;
using Graphql.Data.InMemory;
namespace GraphQL.API.Controllers
{
    [Route("reviews")]
    public class GraphQlController : Controller
    {
        private ReviewQuery _reviewQuery { get; set; }

        public GraphQlController(ReviewQuery reviewQuery)
        {
            _reviewQuery = reviewQuery;
        }

        [HttpPost]
        public async Task<IActionResult> ReviewsAsync([FromBody] GraphQLQuery query)
        {
            var schema = new Schema { Query = new ReviewQuery(new ReviewsRepository()) };
            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
            });
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}