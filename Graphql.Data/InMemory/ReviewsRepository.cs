using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grqphql.Core.data;
using Grqphql.Core.Models;

namespace Graphql.Data.InMemory
{
    public class ReviewsRepository : IReviewsRepository
    {
        private List<Review> _reviews = new List<Review>
        {
            new Review
            {
                Id = 0,
                User = "rmewborne@me.com",
                Rating = 5,
                Body = "GraphQL is pretty dope!"
            },
            new Review
            {
                Id = 1,
                User = "rbennett@cake.com",
                Rating = 4,
                Body = "But what does it do 'dough?"
            },
            new Review
            {
                Id = 2,
                User = "cakeDev",
                Rating = 5,
                Body = "Overall... this is really nice!"
            }
        };
        public Task<Review> Get(int id)
        {
            return Task.FromResult(_reviews.FirstOrDefault(r => r.Id == id));
        }
    }
}
