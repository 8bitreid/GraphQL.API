using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Graphql.Data.EF;
using Graphql.Data.EF.Seed;
using Graphql.Data.InMemory;
using GraphQL.API.Models;
using Grqphql.Core.data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GraphQL.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<ReviewQuery>();
            services.AddTransient<IReviewsRepository, ReviewsRepository>();
            services.AddDbContext<ReviewsContext>(options =>
                options.UseSqlServer(Configuration["ConnectionString:ReviewsDatabaseConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, ReviewsContext db)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            db.EnsureSeedData();
        }
    }
}
