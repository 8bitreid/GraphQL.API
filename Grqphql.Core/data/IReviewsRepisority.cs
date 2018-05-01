using System.Threading.Tasks;
using Grqphql.Core.Models;

namespace Grqphql.Core.data
{
    public interface IReviewsRepisority
    {
         Task<Review> Get(int id);
    }
}