using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Grqphql.Core.Models;

namespace Graphql.Data.EF.Seed
{
    public static class ReviewsSeedData
    {
        public static void EnsureSeedData(this ReviewsContext db)
        {
            if (!db.Reviews.Any())
            {
                var review = new Review
                {
                    Body = "Graphql is awesome!",
                    Id = 0,
                    Rating = 5,
                    User = "dropacake@me.com"
                };
                db.Reviews.Add(review);
                db.SaveChangesAsync();
            }
        }
    }
}
