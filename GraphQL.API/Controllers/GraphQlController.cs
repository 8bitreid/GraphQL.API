using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using GraphQL.API.Models;
using System.Threading.Tasks;

namespace GraphQL.API.Controllers
{
    [Route("reviews")]
    public class GraphQlController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> ReviewsAsync([FromBody] GraphQLQuery query)
        {
            var schema = new Schema { Query = new ReviewQuery() };
            var result = await new DocumentExecuter().ExecuteAsync(_ => { _.Schema = schema;
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