using System;
using System.Collections.Generic;
using System.Text;
using Grqphql.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Graphql.Data.EF
{
    public class ReviewsContext : DbContext
    {
        public ReviewsContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Review> Reviews { get; set; }
    }

}
