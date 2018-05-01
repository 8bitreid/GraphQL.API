using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grqphql.Core.data;
using Grqphql.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Graphql.Data.EF.Repositories
{
    class ReviewsRepository : IReviewsRepository
    {
        private ReviewsContext _dbContext { get; set; }

        public ReviewsRepository(ReviewsContext db)
        {
            _dbContext = db;
        }

        public Task<Review> Get(int id)
        {
            return _dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
